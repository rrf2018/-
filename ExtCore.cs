﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _03调用大漠插件
{

     public class ExtCore
    {
        private delegate bool WNDENUMPROC(IntPtr hWnd, int lParam); //IntPtr hWnd用int也可以

        [DllImport("user32.dll")]

        private static extern bool EnumWindows(WNDENUMPROC lpEnumFunc, int lParam);

        //获取窗口Text 
        [DllImport("user32.dll")]
        private static extern int GetWindowTextW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder lpString, int nMaxCount);

        //获取窗口类名 
        [DllImport("user32.dll")]
        private static extern int GetClassNameW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder lpString, int nMaxCount);

        //自定义一个类，用来保存句柄信息，在遍历的时候，随便也用空上句柄来获取些信息，呵呵 
        public struct WindowInfo
        {
            public IntPtr hWnd;
            public string szWindowName;
            public string szClassName;
        }

        public int GetAllDesktopWindows()
        {
            //用来保存窗口对象 列表
            List<WindowInfo> wndList = new List<WindowInfo>();

            //enum all desktop windows 
            EnumWindows(delegate (IntPtr hWnd, int lParam)
            {
                WindowInfo wnd = new WindowInfo();
                StringBuilder sb = new StringBuilder(256);

                //get hwnd 
                wnd.hWnd = hWnd;

                //get window name  
                GetWindowTextW(hWnd, sb, sb.Capacity);
                wnd.szWindowName = sb.ToString();

                //get window class 
                GetClassNameW(hWnd, sb, sb.Capacity);
                wnd.szClassName = sb.ToString();
                //if (sb.ToString().Contains("Qt5QWindowIcon"))
                //{
                //    UpdateLogAsync("ok");
                //    UpdateLogAsync(wnd.szWindowName);
                //}
                //add it into list 
                if (wnd.szWindowName.Contains("TelegramDesktop") && wnd.szClassName =="Qt51513QWindow")
                {
                    wndList.Add(wnd);
                }
                return true;
            }, 0);

            if (wndList.Count == 0) 
            {
                return 0;
            }
            return wndList[0].hWnd.ToInt32();
        }
    }
}
