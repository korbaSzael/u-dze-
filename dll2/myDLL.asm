.386
.model flat, stdcall
option casemap :none
  include \masm32\include\windows.inc
  include \masm32\include\user32.inc
  include \masm32\include\kernel32.inc 
  includelib \masm32\lib\user32.lib 
  includelib \masm32\lib\kernel32.lib
.data
  msgATTACH db 'ATTACH',0
  msgDETACH db 'detach',0
  msgThreadATTACH db 'ThreadATTACH',0
  msgThreadDETACH db 'ThreadDETACH',0
.code

LibMain proc handle:DWORD, what:DWORD, nothing:DWORD
  .if what == DLL_PROCESS_ATTACH
    invoke MessageBox,0,addr msgATTACH,addr msgATTACH,MB_OK
    mov eax,TRUE ;0->noLOAD
  .elseif what == DLL_PROCESS_DETACH
    invoke MessageBox,0,addr msgDETACH,addr msgDETACH,MB_OK
  .elseif what == DLL_THREAD_ATTACH
    invoke MessageBox,0,addr msgThreadATTACH,addr msgThreadATTACH,MB_OK
  .elseif what == DLL_THREAD_DETACH
    invoke MessageBox,0,addr msgThreadDETACH,addr msgThreadDETACH,MB_OK
  .endif
RET
LibMain Endp

msg1 db "title",0
msg2 db "content",0
myPROC proc
  invoke MessageBox,0,addr msg2,addr msg1,MB_OK
RET
myPROC endp

End LibMain