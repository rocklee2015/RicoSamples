chcp 65001
@echo off
set str1=This is string1
::设置str1中存储的字符串
set str2=%str1:~8,6%
set str3=%str1:~0,4%
set str4=%str1:~5%       ::后面5位
::字符串截取
echo 原字符串：
echo str1=%str1%
echo 截取得到的字符串：
echo str2=%str2%
echo str3=%str3%
echo str4=%str4%
::输出执行结果
echo 输出完毕，按任意键退出&&pause>nul&&exit