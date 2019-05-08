.386
.model flat, stdcall
option casemap :none
  include \masm32\include\windows.inc  
  include \masm32\include\user32.inc
  include \masm32\include\kernel32.inc

  includelib \masm32\lib\user32.lib
  includelib \masm32\lib\kernel32.lib
.data
  library db "myDLL",0
  myPROC db "myPROC",0
  handle dd 0
.code

START:
  invoke LoadLibrary,addr library
  mov handle, eax
  invoke GetProcAddress,handle,addr myPROC
  call eax
  invoke FreeLibrary,handle
  invoke ExitProcess,0
END START