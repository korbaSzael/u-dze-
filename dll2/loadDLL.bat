@echo off

if exist callDLL.obj del loadDLL.obj
if exist callDLL.exp del loadDLL.exp
if exist callDLL.lib del loadDLL.lib

\masm32\bin\ml /c /coff loadDLL.asm
\masm32\bin\Link /SUBSYSTEM:WINDOWS loadDLL.obj

if exist callDLL.obj del loadDLL.obj
if exist callDLL.exp del loadDLL.exp
if exist callDLL.lib del loadDLL.lib
dir loadDLL.*
pause