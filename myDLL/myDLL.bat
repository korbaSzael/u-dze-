@echo off

if exist myDLL.obj del myDLL.obj
if exist myDLL.dll del myDLL.dll
if exist myDLL.exp del myDLL.exp
if exist myDLL.lib del myDLL.lib

\masm32\bin\ml /c /coff myDLL.asm
\masm32\bin\Link /SUBSYSTEM:WINDOWS /DLL /DEF:myDLL.def myDLL.obj

if exist myDLL.obj del myDLL.obj
if exist myDLL.exp del myDLL.exp
dir myDLL.*
pause