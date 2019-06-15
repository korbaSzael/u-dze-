@echo off

if exist callDLL.obj del callDLL.obj
if exist callDLL.exp del callDLL.exp
if exist callDLL.lib del callDLL.lib

\masm32\bin\ml /c /coff callDLL.asm
\masm32\bin\Link /SUBSYSTEM:WINDOWS callDLL.obj

if exist callDLL.obj del callDLL.obj
if exist callDLL.exp del callDLL.exp
if exist callDLL.lib del callDLL.lib
dir callDLL.*
pause