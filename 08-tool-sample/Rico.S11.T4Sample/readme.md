#### 功能介绍
> - S1: 简单的从XML读取数据
> - S2:
> - S3: 生成每个表的的增、删、改、查存储过程


#### T4 工具
>- [T4-Tagnible 模板编辑器 For Visual Studio 2015](http://t4-editor.tangible-engineering.com/Download_T4Editor_Plus_ModelingTools.html)


#### 项目来源：
>- [蒋金楠](http://www.cnblogs.com/artech/archive/2010/10/25/1860064.html)
>- [ EF学习笔记——生成自定义实体类](http://blog.csdn.net/leftfist/article/details/24889819)
>- [T4模版引擎之基础入门 ](http://www.cnblogs.com/lzrabbit/archive/2012/07/15/2591085.html)
>-  [你必须懂的 T4 模板：体系架构](http://blog.csdn.net/airingyuan/article/details/17240269)
>- [你必须懂的 T4 模板：深入浅出 ](http://www.cnblogs.com/guohu/p/4541418.html)
#### 遇到问题：
> - 在Template的InsertProcedureTemplate下关于System.Xml引用问题
在模板头部加如下代码：
<#@ assembly name="System.Xml" #>
<#@ import namespace="System.Xml" #>

> - 要给一个数据库和表，才能生成存储过程
  再有就是Server server=new Server();需要一个数据库实例；

> - 继承Template模板，需要引用T4Toolbox程序集
<#@ assembly name="C:\Users\Administrator\AppData\Local\Microsoft\VisualStudio\12.0\Extensions\ieh5mgg0.kxr\T4Toolbox.dll" #>