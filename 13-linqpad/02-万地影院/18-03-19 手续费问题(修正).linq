<Query Kind="Program">
  <Connection>
    <ID>8f35cbb5-7d32-4780-9466-d2ea7df6801a</ID>
    <Persist>true</Persist>
    <Server>192.168.1.218\mighost</Server>
    <SqlSecurity>true</SqlSecurity>
    <UserName>sa</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAABoybHsSXFUuz8AXaKmCqgAAAAAACAAAAAAAQZgAAAAEAACAAAAAY1L2xKXxTEwafKLsJIgRLp3lTtHAGIZJKfzP+Cm/fnQAAAAAOgAAAAAIAACAAAABFxQ3QIGCW+GW9ZwBRjYCQKjMVsx68ZWf41kU/8x/YExAAAADltx+Q8L+jR8smKtSA1KvTQAAAAAkFR+NNcSvAp0ax3jBbCKBrfQNaSCf3lR+Faqk/qDBA6Gqf9Zq2yxWWG/Dt5DcbvpxE6mq07V0vP7xoxwZR4r8=</Password>
    <Database>CinemaWd180317</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

void Main()
{
	var constr = @"Data Source=192.168.1.218\mighost;Initial Catalog=CinemaWd180317;Persist Security Info=True;User ID=sa;Password=1qaz~xsw2;multipleactiveresultsets=True;";
	var result = new List<OrderTicket>();
	using (SqlConnection con = new SqlConnection(constr))
	{
		//4.编写SQL语句
		string sql = "select Id,TicketPrice from OrderTicket  where createtime<='2018/3/7 20:06:10'";
		//5.创建一个执行sql语句的对象（命令对象）sqlcommand
		using (SqlCommand cmd = new SqlCommand(sql, con))
		{
			con.Open();
			using (SqlDataReader reader = cmd.ExecuteReader())
			{
				//接下来就是要通过reader对象一条一条获取数据
				//1.在获取数据前，先判断一下本次执行查询后，是否查到了数据
				if (reader.HasRows)//如果有数据为true,否则为false
				{
					//2.如果有数据，那么接下来就要一条条获取数据
					//每次获取数据之前，都要调用reader.Read()方法，向后移动一条数据，如果成功移动到了某条数据
					//上，则返回true，否则返回false
					while (reader.Read())
					{
						//获取当前reader指向的数据
						//reader.FieldCount可以获取当前查询语句查询到的列数
						result.Add(new OrderTicket
						{
							Id = reader[0].ToString(),
							TicketPrice = decimal.Parse(reader[1].ToString())
						});
					}
				}
				else
				{
					Console.WriteLine("没有查到数据");
				}
			}
		}



	}
	result.Count.Dump("总数量");
	constr = "Data Source=101.132.69.71;Initial Catalog=CinemaWd;Persist Security Info=True;User ID=sa;Password=Passw0rd@0909!;multipleactiveresultsets=True;";
    return;
	int count = 0;
	var failResult = new List<OrderTicket>();
	using (SqlConnection con = new SqlConnection(constr))
	{
		//5.打开链接
		con.Open();
		int index=1;
		foreach (var item in result)
		{
			//3.sql语句
			string sql = $"update OrderTicket set TicketPrice={item.TicketPrice} where id='{item.Id}'";
			//4.创建sqlcommand对象
			using (SqlCommand cmd = new SqlCommand(sql,con))
			{

				//6.执行
				int r = cmd.ExecuteNonQuery();
				if (r > 0)
				{
					$"{item.Id} 成功！{index++}/{result.Count}".Dump();
					count++;
				}
				else
				{
					$"{item.Id} 失败！ {index++}/{result.Count}".Dump();
					failResult.Add(item);
				}
			}
		}

	}
	$"更新成功：{count}，更新失败：{failResult.Count}".Dump();

	foreach (var element in failResult)
	{
		element.Dump();
	}
}
public class OrderTicket
{
	public string Id { get; set; }
	public decimal TicketPrice { get; set; }
}

// Define other methods and classes here
