.386
.model flat, stdcall
option casemap :none
      include \masm32\include\windows.inc
      include \masm32\include\user32.inc
      include \masm32\include\kernel32.inc
      
      includelib \masm32\lib\user32.lib
      includelib \masm32\lib\kernel32.lib
      includelib myDLL.lib
      
      myPROC PROTO

.DATA
.CODE
START:
  invoke myPROC
  invoke ExitProcess,0
END START
