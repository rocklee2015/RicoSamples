--1����ȡ��ǰ����GetDate
--getdate()������datetime�������͵ĸ�ʽ���ص�ǰSQLServer���������ڼ���������ں�ʱ�䡣���﷨��ʽΪgetdate()��
--����ֵ���뵽�������С�����֣�����Ϊ.333�����ݿ�ʮ��ƫ�������������ڡ�
select  getdate() --��� 2013-03-09 15:16:00.570

--2��GetUTCDate ��ȡUTCʱ��ֵ
select  getutcdate()-- 2013-06-18 08:02:53.253

--3����ȡ�����ϢYEAR
--year������int�������͵ĸ�ʽ�����ض����ڵ������Ϣ��
--���﷨��ʽΪYEAR(date����)�����е�date����ʱһ�����Խ���Ϊtime��date��smalldatetime��datetime��datetime2��datetimeoffsetֵ�ı��ʽ���б��ʽ���û�����ı������ַ������֡�

select year(getdate()) --��� 2013

--4����ȡ�·���ϢMONTH
--month������int�������͵ĸ�ʽ�����ض����ڵ��·���Ϣ��
--���﷨��ʽΪmonth(date����)�����е�date����ʱһ�����Խ���Ϊtime��date��smalldatetime��datetime��datetime2��datetimeoffsetֵ�ı��ʽ���б��ʽ���û�����ı������ַ������֡�
select month(getdate()) --��� 3