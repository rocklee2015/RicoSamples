@ECHO OFF  
TITLE BAT�ű�����2  
COLOR A  
echo -----------BAT�ű�����2-----------  
echo=  
echo=  
echo  ��ǰ����·��Ϊ��%cd%  
rem ����ļ�Ŀ¼������Ŀ¼  
TREE /f >tree_list.txt  
rem CD�л���ͬ�̷�ʱ����Ҫ����/d  
CD /D C:\  
echo  ��ǰ����·��Ϊ��%cd%  
DIR  
rem ����Ŀ¼bat_example2  
MD bat_example2  
DIR  
rem ����Ŀ¼ /s /e /y ˵�����ڸ����ļ���ͬʱҲ���ƿ�Ŀ¼����Ŀ¼�����Ŀ��·���Ѿ�����ͬ�ļ��ˣ�ʹ�ø��Ƿ�ʽ����������ʾ  
Xcopy C:\bat_example2 D:\bat_example2  /s /e /y  
  
rem ɾ��Ŀ¼bat_example2  
rem RD /Q /S bat_example2  
rem DIR  
echo=  
echo=  
echo --------------------------------------------  
PAUSE