@ECHO OFF  
TITLE BAT脚本例子2  
COLOR A  
echo -----------BAT脚本例子2-----------  
echo=  
echo=  
echo  当前工作路径为：%cd%  
rem 输出文件目录的树形目录  
TREE /f >tree_list.txt  
rem CD切换不同盘符时候需要加上/d  
CD /D C:\  
echo  当前工作路径为：%cd%  
DIR  
rem 创建目录bat_example2  
MD bat_example2  
DIR  
rem 拷贝目录 /s /e /y 说明：在复制文件的同时也复制空目录或子目录，如果目标路径已经有相同文件了，使用覆盖方式而不进行提示  
Xcopy C:\bat_example2 D:\bat_example2  /s /e /y  
  
rem 删除目录bat_example2  
rem RD /Q /S bat_example2  
rem DIR  
echo=  
echo=  
echo --------------------------------------------  
PAUSE