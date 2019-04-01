<Query Kind="Program" />

void Main()
{
urlconvertor(@"D:\00-baitu-tfs\TFS-2018\EiasOfLishui\src\master\Applications\EIA.FaceInWeb\WeXinVedio\2018112319192019_46545_best.jpg").Dump();
}
private string urlconvertor(string imagesurl1)
{
	string tmpRootDir =AppDomain.CurrentDomain.BaseDirectory;//获取程序根目录
	tmpRootDir.Dump();
	string imagesurl2 = imagesurl1.Replace(tmpRootDir, ""); //转换成相对路径
	imagesurl2 = imagesurl2.Replace(@"\", @"/");
	return "/"+imagesurl2;
}
// Define other methods and classes here