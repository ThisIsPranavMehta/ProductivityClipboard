using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace learningForms
{
    internal static class KeyLogger
    {


        public static Dictionary<int,string> ChannelIdsToStrings = new Dictionary<int,string>();            // storing ascii values for here. 
        internal static int ChannelId = -1;
        public static void Initialise()
        {
            ChannelIdsToStrings[0] = "D0";
            ChannelIdsToStrings[1] = "D1";
            ChannelIdsToStrings[2] = "D2";
            ChannelIdsToStrings[3] = "D3";
            ChannelIdsToStrings[4] = "D4";
            ChannelIdsToStrings[5] = "D5";
            ChannelIdsToStrings[6] = "D6";
            ChannelIdsToStrings[7] = "D7";
            ChannelIdsToStrings[8] = "D8";
            ChannelIdsToStrings[9] = "D9";
            ChannelIdsToStrings[10] = "M";
            ChannelIdsToStrings[11] = "T";



            _hookID = SetHook(_proc);  //Set our hook
        }
        ///////////////////////////////////////////////////////////
        //A bunch of DLL Imports to set a low level keyboard hook
        ///////////////////////////////////////////////////////////
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        // for bringing the form to Foreground
        [DllImport("User32")]
        private static extern int SetForegroundWindow(IntPtr hwnd);



        private const int WH_KEYBOARD_LL = 13;                    //Type of Hook - Low Level Keyboard
        private const int WM_KEYDOWN = 0x0100;                    //Value passed on KeyDown
        private const int WM_KEYUP = 0x0101;                      //Value passed on KeyUp
        private static LowLevelKeyboardProc _proc = HookCallback; //The function called when a key is pressed
        private static IntPtr _hookID = IntPtr.Zero;
        private static bool CONTROL_DOWN = false;                 //Bool to use as a flag for control key
        
        internal static bool COPIED = false;                        // denotes whether the copy operation is performed
        internal static bool PASTE = false;
        
        private static bool ALREADY_OPEN_COPY = false;
        private static bool ALREADY_OPEN_PASTE = false;




        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }
        
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN) //A Key was pressed down
            {
                int vkCode = Marshal.ReadInt32(lParam);           //Get the keycode
                string theKey = ((Keys)vkCode).ToString();        //Name of the key
                Debug.WriteLine(theKey);                            //Display the name of the key
                if (theKey.Contains("ControlKey"))                //If they pressed control
                {
                    CONTROL_DOWN = true;                          //Flag control as down
                }
                else if (CONTROL_DOWN && theKey == "C")           //If they held CTRL and pressed B
                {
                    if (!ALREADY_OPEN_COPY)
                    {
                        ALREADY_OPEN_COPY = !ALREADY_OPEN_COPY;
                        SendKeys.Send("^c");
                        var f = new EnterKeyForCopy();
                        f.Show();
                        SetForegroundWindow(f.Handle);
                    }
                    else
                    {
                        ALREADY_OPEN_COPY = !ALREADY_OPEN_COPY;
                    }
                }
                else if (CONTROL_DOWN && theKey == "V")
                {
                    if (!ALREADY_OPEN_PASTE)
                    {
                        ALREADY_OPEN_PASTE=!ALREADY_OPEN_PASTE;
                        PASTE = true;

                        var f = new EnterKeyForPaste();
                        f.Show();
                        SetForegroundWindow(f.Handle);
                    }
                    else
                    {

                        ALREADY_OPEN_PASTE = !ALREADY_OPEN_PASTE;
                    }
                    //CONTROL_DOWN=false;
                    //SendKeys.Send("^v");
                }
                //else if (theKey == "Escape")                      //If they p
                //s escape
                //{
                //    UnhookWindowsHookEx(_hookID);                 //Release our hook
                //    Environment.Exit(0);                          //Exit our program
                //}
            }
            else if (nCode >= 0 && wParam == (IntPtr)WM_KEYUP) //KeyUP
            {
                int vkCode = Marshal.ReadInt32(lParam);        //Get Keycode
                string theKey = ((Keys)vkCode).ToString();     //Get Key name
                if (theKey.Contains("ControlKey"))             //If they let go of control
                {
                    CONTROL_DOWN = false;                      //Unflag control
                    COPIED = false;
                    PASTE = false;
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam); //Call the next hook
        }

    }
}
