@ECHO OFF  
TITLE BAT脚本例子1  
echo -----------枚举C盘目录下所有文件-----------  
echo=  
echo=  
dir c:\*.*  
rem 输出到文本文件  
dir c:\*.* > example1.txt  
echo=  
echo=  
echo --------------------------------------------  
PAUSE