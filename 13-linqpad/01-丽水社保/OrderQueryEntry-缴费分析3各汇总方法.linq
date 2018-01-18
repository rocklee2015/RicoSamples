<Query Kind="Program" />


        public async Task<BootstrapTable> SelectPaymentAnalysisSummaryAsync(PaymentAnalysisFilter filter)
        {
            //sql 查询条件 （只计算 已支付和已完成 状态）
            string sqlWhereText = $" Where  (a.Status={(int)OrderStatus.Paid} or a.Status={(int)OrderStatus.Compeleted})";
            var sqlWhereList = new List<string>();
            if (filter.TimeFrom.HasValue)
            {
                sqlWhereList.Add($"a.CreateTime>=''{filter.TimeFrom.Value.ToString("yyyy-MM-dd")}''");
            }
            if (filter.TimeTo.HasValue)
            {
                sqlWhereList.Add($"a.CreateTime<=''{filter.TimeTo.Value.ToString("yyyy-MM-dd")}''");
            }
            if (filter.OrderItemProductCodes != null && filter.OrderItemProductCodes.Count > 0)
            {
                //缴费项 条件
                var itemProductCodeList = filter.OrderItemProductCodes.Select(a => $"''{a}''").ToList();
                sqlWhereList.Add($"b.ItemProductCode in({string.Join(",", itemProductCodeList)})");
            }
            if (filter.Platforms != null && filter.Platforms.Count > 0)
            {
                //支付平台 条件
                var platformIntList = filter.Platforms.Select(a => (int)a).ToList();
                sqlWhereList.Add($"a.PlatformType in({string.Join(",", platformIntList)})");
            }
            if (sqlWhereList.Any())
            {
                sqlWhereText += " And ";
                sqlWhereText += string.Join(" And ", sqlWhereList);
            }

            //统筹区域 过滤 ，如果空查询所有统筹区
            string innerWhereText = string.Empty;
            if (filter.CoordinateCodes.Count > 0)
            {
                var areas = filter.CoordinateCodes.Select(a => $"'{a}'").ToList();
                innerWhereText += $" And Code IN({string.Join(",", areas)})";
            }
            string sqlText = $@"
DECLARE @cmdText varchar(8000)
SET @cmdText = 'select CONVERT(varchar(100), c.CreateTime, 23) as 时间 ,'
SELECT @cmdText = @cmdText + 'sum(case c.AreaCode when ''' + Code + ''' then c.Fee else 0 end) as ''' + Name + ''',' + char(10)
FROM
  (SELECT Code,
          Name
   FROM Coordinate
   WHERE IsDeleted=0 {innerWhereText} ) T
SET @cmdText = left(@cmdText, len(@cmdText) - 2)

SET @cmdText = @cmdText + '
 from(
 select CONVERT(varchar(100), a.CreateTime, 23) as CreateTime, b.Fee, b.AreaCode
 from[Order] a
 inner join[OrderItem] b on a.Id = b.OrderId
 {sqlWhereText}
 ) c
 group by c.CreateTime
 order by c.CreateTime desc
 ' 
exec(@cmdText)";
            var result = new BootstrapTable();
            var connectionString = ConfigurationManager.ConnectionStrings["SiDbContext"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var cmd = new SqlCommand(sqlText, connection);
                var columnNames = new List<string>();
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    DataTable schemaTable = reader.GetSchemaTable();

                    if (schemaTable == null)
                    {
                        return result;
                    }

                    string firstColumnName = string.Empty;
                    string lastColumnName = "总额";
                    //动态构建表，添加列
                    columnNames.AddRange(from DataRow dr in schemaTable.Rows select dr[0].ToString());
                    columnNames.Add(lastColumnName);

                    Dictionary<string, decimal> areaMoney = new Dictionary<string, decimal>();
                    decimal moneyTotal = 0;

                    while (await reader.ReadAsync())
                    {
                        if (firstColumnName.IsNullOrEmpty())
                        {
                            firstColumnName = reader.GetName(0);
                        }
                        var dic = new Dictionary<string, string>();
                        decimal money = 0;
                        for (int i = 0; i < schemaTable.Rows.Count; i++)
                        {
                            var columnName = reader.GetName(i);
                            //第一列是时间不算
                            if (i != 0)
                            {
                                money += reader.GetDecimal(i);
                                if (areaMoney.ContainsKey(columnName))
                                {
                                    areaMoney[columnName] += reader.GetDecimal(i);
                                }
                                else
                                {
                                    areaMoney.Add(columnName, reader.GetDecimal(i));
                                }
                            }
                            dic.Add(columnName, reader[i].ToString());
                        }
                        moneyTotal += money;
                        dic.Add(lastColumnName, money.ToString(CultureInfo.InvariantCulture));
                        result.Rows.Add(dic);
                    }
                    var dicTotal = new Dictionary<string, string> { { firstColumnName, "合计" } };
                    foreach (var item in areaMoney)
                    {
                        dicTotal.Add(item.Key, item.Value.ToString(CultureInfo.InvariantCulture));
                    }
                    dicTotal.Add(lastColumnName, moneyTotal.ToString(CultureInfo.InvariantCulture));
                    result.Rows.Add(dicTotal);
                    result.Columns = columnNames;
                }
            }
            return result;
        }


        public async Task<ProductSummary> SelectPaymentAnalysisSummaryByProductAsync(PaymentAnalysisFilter filter)
        {
            //缴费项 字符串
            var itemProductEntitys = await BaseDataValueReponsitory.SelectMedicalExpenseByCodes(filter.OrderItemProductCodes);
            var itemProductNameList = itemProductEntitys.Select(a => a.Display).ToList();//缴费项名列表

            //统筹区 字符串
            var areaCodeEnitys = await CoordinateRepository.SelectByIds(filter.CoordinateCodes);
            var areaCodeNameList = areaCodeEnitys.Select(a => a.Name).ToList();//统筹区名列表

            //sql 查询条件 （只计算 已支付和已完成 状态）
            string sqlWhereText = $" Where  (a.Status={(int)OrderStatus.Paid} or a.Status={(int)OrderStatus.Compeleted})";
            var sqlWhereList = new List<string>();
            if (filter.TimeFrom.HasValue)
            {
                sqlWhereList.Add($"a.CreateTime>=''{filter.TimeFrom.Value.ToString("yyyy-MM-dd")}''");
            }
            if (filter.TimeTo.HasValue)
            {
                sqlWhereList.Add($"a.CreateTime<=''{filter.TimeTo.Value.ToString("yyyy-MM-dd")}''");
            }
            if (filter.Platforms != null && filter.Platforms.Count > 0)
            {
                //支付平台 条件
                var platformIntList = filter.Platforms.Select(a => (int)a).ToList();
                sqlWhereList.Add($"a.PlatformType in({string.Join(",", platformIntList)})");
            }
            if (filter.CoordinateCodes != null && filter.CoordinateCodes.Count > 0)
            {
                //统筹区 条件
                var areaCodeList = filter.CoordinateCodes.Select(a => $"''{a}''").ToList();
                sqlWhereList.Add($"b.AreaCode in({string.Join(",", areaCodeList)})");
            }
            if (filter.OrderItemProductCodes != null && filter.OrderItemProductCodes.Count > 0)
            {
                //缴费项 条件
                var itemProductCodeList = filter.OrderItemProductCodes.Select(a => $"''{a}''").ToList();
                sqlWhereList.Add($"b.ItemProductCode in({string.Join(",", itemProductCodeList)})");

            }
            if (sqlWhereList.Any())
            {
                sqlWhereText += " And ";
                sqlWhereText += string.Join(" And ", sqlWhereList);
            }
            //统筹区和缴费项 键值对(代码,显示名) 
            var codeDic = new Dictionary<string, string>();
            areaCodeEnitys.ForEach(a => { codeDic.Add(a.Code, a.Name); });
            itemProductEntitys.ForEach(a => { codeDic.Add(a.Value, a.Display); });

            // sql sum 拼接
            var sqlSumList = new List<string>();
            filter.CoordinateCodes.ForEach(a =>
            {
                filter.OrderItemProductCodes.ForEach(b =>
                {
                    sqlSumList.Add($"sum(case c.AreaProductCode when ''{a}-{b}'' then c.Fee else 0 end)  as ''{codeDic[a]}-{codeDic[b]}''");
                });
            });
            var sqlSumText = string.Join(",", sqlSumList);
            if (!sqlSumText.IsNullOrEmpty())
            {
                sqlSumText = $"SET @cmdText = @cmdText + ',{sqlSumText}'";
            }
            //sql 查询主体
            string sqlText = $@"
DECLARE @cmdText varchar(8000)
SET @cmdText = 'select CONVERT(varchar(100), c.CreateTime, 23) as 时间' 
{sqlSumText} 
SET @cmdText = @cmdText + ' from (
select CONVERT(varchar(100), a.CreateTime, 23) as CreateTime, b.Fee,b.AreaCode+''-''+b.ItemProductCode as AreaProductCode
from[Order] a
inner join[OrderItem] b on a.Id = b.OrderId
{sqlWhereText}
) c
group by c.CreateTime
order by c.CreateTime desc
' 
exec(@cmdText)";
            var result = new ProductSummary();
            var connectionString = ConfigurationManager.ConnectionStrings["SiDbContext"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var cmd = new SqlCommand(sqlText, connection);
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    //列集合
                    DataTable schemaTable = reader.GetSchemaTable();
                    var productDatas = new Dictionary<string, PriceData>();
                    while (await reader.ReadAsync())
                    {
                        var priceData = new PriceData();//一行显示内容
                        var dicSubTotal = new Dictionary<string, decimal>();//小计 
                        string firstColumnValue = string.Empty;//第一列时间
                        for (int i = 0; i < schemaTable.Rows.Count; i++)
                        {
                            var columnName = reader.GetName(i);
                            var columnAreaName = columnName.Split("-").ToArray()[0];//统筹区名
                            //非第一列 做小计累计
                            if (i != 0)
                            {
                                if (dicSubTotal.ContainsKey(columnAreaName))
                                {
                                    dicSubTotal[columnAreaName] += reader.GetDecimal(i);
                                }
                                else
                                {
                                    dicSubTotal.Add(columnAreaName, reader.GetDecimal(i));
                                }
                                priceData.TimeDatas.Add(columnName, reader.GetDecimal(i));
                            }
                            else
                            {
                                firstColumnValue = reader[i].ToString();
                            }
                        }
                        //各统筹区 缴费项小计计算
                        foreach (var item in dicSubTotal)
                        {
                            priceData.TimeDatas.Add(item.Key + "-小计", item.Value);
                        }
                        //一行数据计算完成
                        productDatas.Add(firstColumnValue, priceData);
                    }
                    //最终数据
                    result.ItemProductData = productDatas;
                    result.ProductAreaNames = areaCodeNameList;
                    itemProductNameList.Add("小计");//添加小计，页面上组合所用
                    result.ItemProducts = itemProductNameList;
                }
            }
            return result;
        }

        public async Task<PlatformSummary> SelectPaymentAnalysisSummaryByPlatformAsync(PaymentAnalysisFilter filter)
        {


            //统筹区 字符串
            var areaCodeEnitys = await CoordinateRepository.SelectByIds(filter.CoordinateCodes);
            var areaCodeNameList = areaCodeEnitys.Select(a => a.Name).ToList();//统筹区名列表

            //支付平台名 列表
            var platfromNameList = new List<string>();
            filter.Platforms.ForEach(a =>
            {
                platfromNameList.Add(a.ReadEnumDescription());
            });

            //sql 查询条件 （只计算 已支付和已完成 状态）
            string sqlWhereText = $" Where  (a.Status={(int)OrderStatus.Paid} or a.Status={(int)OrderStatus.Compeleted})";
            var sqlWhereList = new List<string>();
            if (filter.TimeFrom.HasValue)
            {
                sqlWhereList.Add($"a.CreateTime>=''{filter.TimeFrom.Value.ToString("yyyy-MM-dd")}''");
            }
            if (filter.TimeTo.HasValue)
            {
                sqlWhereList.Add($"a.CreateTime<=''{filter.TimeTo.Value.ToString("yyyy-MM-dd")}''");
            }
            if (filter.CoordinateCodes != null && filter.CoordinateCodes.Count > 0)
            {
                //统筹区 条件
                var areaCodeList = filter.CoordinateCodes.Select(a => $"''{a}''").ToList();
                sqlWhereList.Add($"b.AreaCode in({string.Join(",", areaCodeList)})");
            }
            if (filter.OrderItemProductCodes != null && filter.OrderItemProductCodes.Count > 0)
            {
                //缴费项 条件
                var itemProductCodeList = filter.OrderItemProductCodes.Select(a => $"''{a}''").ToList();
                sqlWhereList.Add($"b.ItemProductCode in({string.Join(",", itemProductCodeList)})");

            }
            if (sqlWhereList.Any())
            {
                sqlWhereText += " And ";
                sqlWhereText += string.Join(" And ", sqlWhereList);
            }
            //统筹区和缴费项 键值对(代码,显示名) 
            var codeDic = new Dictionary<string, string>();
            areaCodeEnitys.ForEach(a => { codeDic.Add(a.Code, a.Name); });
            if (filter.Platforms != null && filter.Platforms.Count > 0)
            {
                filter.Platforms.ForEach(a =>
                {
                    codeDic.Add(((int)a).ToString(), a.ReadEnumDescription());
                });
            }

            // sql sum 拼接
            var sqlSumList = new List<string>();
            filter.CoordinateCodes.ForEach(a =>
            {
                filter.Platforms.ForEach(b =>
                {
                    sqlSumList.Add($"sum(case c.AreaPlatform when ''{a}-{(int)b}'' then c.Fee else 0 end)  as ''{codeDic[a]}-{codeDic[((int)b).ToString()]}''");
                });
            });
            var sqlSumText = string.Join(",", sqlSumList);
            if (!sqlSumText.IsNullOrEmpty())
            {
                sqlSumText = $" SET @cmdText = @cmdText + ',{sqlSumText}'";
            }
            //sql 查询主体
            string sqlText = $@"
DECLARE @cmdText varchar(8000)
SET @cmdText = 'select CONVERT(varchar(100), c.CreateTime, 23) as 时间 '
{sqlSumText}
SET @cmdText = @cmdText + ' from (
select CONVERT(varchar(100), a.CreateTime, 23) as CreateTime, b.Fee,b.AreaCode+''-''+cast(a.PlatformType as nvarchar(2)) as AreaPlatform
from[Order] a
inner join[OrderItem] b on a.Id = b.OrderId
{sqlWhereText}
) c
group by c.CreateTime
order by c.CreateTime desc
' 
exec(@cmdText)";
            var result = new PlatformSummary();
            var connectionString = ConfigurationManager.ConnectionStrings["SiDbContext"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var cmd = new SqlCommand(sqlText, connection);
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    //列集合
                    DataTable schemaTable = reader.GetSchemaTable();
                    var productDatas = new Dictionary<string, PriceData>();
                    while (await reader.ReadAsync())
                    {
                        var priceData = new PriceData();//一行显示内容
                        var dicSubTotal = new Dictionary<string, decimal>();//小计 
                        string firstColumnValue = string.Empty;//第一列时间
                        for (int i = 0; i < schemaTable.Rows.Count; i++)
                        {
                            var columnName = reader.GetName(i);
                            var columnAreaName = columnName.Split("-").ToArray()[0];//统筹区名
                            //非第一列 做小计累计
                            if (i != 0)
                            {
                                if (dicSubTotal.ContainsKey(columnAreaName))
                                {
                                    dicSubTotal[columnAreaName] += reader.GetDecimal(i);
                                }
                                else
                                {
                                    dicSubTotal.Add(columnAreaName, reader.GetDecimal(i));
                                }
                                priceData.TimeDatas.Add(columnName, reader.GetDecimal(i));
                            }
                            else
                            {
                                firstColumnValue = reader[i].ToString();
                            }
                        }
                        //各统筹区 缴费项小计计算
                        foreach (var item in dicSubTotal)
                        {
                            priceData.TimeDatas.Add(item.Key + "-小计", item.Value);
                        }
                        //一行数据计算完成
                        productDatas.Add(firstColumnValue, priceData);
                    }
                    //最终数据
                    result.PlatformData = productDatas;
                    platfromNameList.Add("小计");//添加小计，页面上组合所用
                    result.PlatformTypes = platfromNameList;
                    result.PlatformAreaNames = areaCodeNameList;
                }
            }
            return result;
        }
// Define other methods and classes here
