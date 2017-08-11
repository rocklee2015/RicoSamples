--1、获取当前日期GetDate
--getdate()函数以datetime数据类型的格式返回当前SQLServer服务器所在计算机的日期和时间。其语法格式为getdate()。
--返回值舍入到最近的秒小数部分，精度为.333秒数据库十七偏移量不包含在内。
select  getdate() --输出 2013-03-09 15:16:00.570

--2、GetUTCDate 获取UTC时间值
select  getutcdate()-- 2013-06-18 08:02:53.253

--3、获取年度信息YEAR
--year函数以int数据类型的格式返回特定日期的年度信息。
--其语法格式为YEAR(date数据)。其中的date数据时一个可以解析为time、date、smalldatetime、datetime、datetime2或datetimeoffset值的表达式，列表达式、用户定义的变量或字符串文字。

select year(getdate()) --输出 2013

--4、获取月份信息MONTH
--month函数以int数据类型的格式返回特定日期的月份信息。
--其语法格式为month(date数据)。其中的date数据时一个可以解析为time、date、smalldatetime、datetime、datetime2或datetimeoffset值的表达式，列表达式、用户定义的变量或字符串文字。
select month(getdate()) --输出 3