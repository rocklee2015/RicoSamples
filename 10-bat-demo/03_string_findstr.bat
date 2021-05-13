@echo off

rem way 1
set str=machine-order-service
set matchStr=order
::echo %str% | findstr "order" >nul && echo yes || echo no
echo %str% | findstr "order" &&(
    echo yes
)||(
    echo no
)
rem end way 1
pause