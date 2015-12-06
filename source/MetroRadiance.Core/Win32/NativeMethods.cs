﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MetroRadiance.Win32
{
	public static class NativeMethods
	{
		[DllImport("user32.dll", EntryPoint = "GetWindowLongA", SetLastError = true)]
		public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

		public static WS GetWindowLong(this IntPtr hWnd)
		{
			return (WS)GetWindowLong(hWnd, (int)GWL.STYLE);
		}
		public static WSEX GetWindowLongEx(this IntPtr hWnd)
		{
			return (WSEX)GetWindowLong(hWnd, (int)GWL.EXSTYLE);
		}

		
		[DllImport("user32.dll")]
		public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

		public static WS SetWindowLong(this IntPtr hWnd, WS dwNewLong)
		{
			return (WS)SetWindowLong(hWnd, (int)GWL.STYLE, (int)dwNewLong);
		}
		public static WSEX SetWindowLongEx(this IntPtr hWnd, WSEX dwNewLong)
		{
			return (WSEX)SetWindowLong(hWnd, (int)GWL.EXSTYLE, (int)dwNewLong);
		}

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, SWP flags);

		[DllImport("user32.dll")]
		public static extern bool SetWindowPlacement(IntPtr hWnd, [In] ref WINDOWPLACEMENT lpwndpl);

		[DllImport("user32.dll")]
		public static extern bool GetWindowPlacement(IntPtr hWnd, out WINDOWPLACEMENT lpwndpl);

		[DllImport("user32.dll")]
		public static extern bool GetClientRect(IntPtr hWnd, out RECT rect);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool PostMessage(IntPtr hwnd, uint msg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		public static extern IntPtr SendMessage(IntPtr hWnd, WM msg, IntPtr wParam, IntPtr lParam);

		public static ClassStyles GetClassLong(this IntPtr hwnd, ClassLongFlags flags)
		{
			if (IntPtr.Size == 8)
			{
				return (ClassStyles)GetClassLong64(hwnd, flags);
			}
			return (ClassStyles)GetClassLong32(hwnd, flags);
		}

		[DllImport("user32.dll", EntryPoint="GetClassLong")]
		public static extern IntPtr GetClassLong32(IntPtr hwnd, ClassLongFlags nIndex);

		[DllImport("user32.dll", EntryPoint="GetClassLongPtr")]
		public static extern IntPtr GetClassLong64(IntPtr hwnd, ClassLongFlags nIndex);

		public static ClassStyles SetClassLong(this IntPtr hwnd, ClassLongFlags flags, ClassStyles dwLong)
		{
			if (IntPtr.Size == 8)
			{
				return (ClassStyles)SetClassLong64(hwnd, flags, (IntPtr)dwLong);
			}
			return (ClassStyles)SetClassLong32(hwnd, flags, (IntPtr)dwLong);
		}

		[DllImport("user32.dll", EntryPoint="SetClassLong")]
		public static extern IntPtr SetClassLong32(IntPtr hWnd, ClassLongFlags nIndex, IntPtr dwNewLong);

		[DllImport("user32.dll", EntryPoint="SetClassLongPtr")]
		public static extern IntPtr SetClassLong64(IntPtr hWnd, ClassLongFlags nIndex, IntPtr dwNewLong);


		[DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern IntPtr MonitorFromWindow(IntPtr hwnd, MonitorDefaultTo dwFlags);

		[DllImport("SHCore.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
		public static extern void GetDpiForMonitor(IntPtr hmonitor, MonitorDpiType dpiType, ref uint dpiX, ref uint dpiY);

		[DllImport("user32.dll")]
		public static extern IntPtr GetActiveWindow();

		[DllImport("user32.dll")]
		public static extern IntPtr SetActiveWindow(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern bool IsZoomed(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern bool IsIconic(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern bool IsWindowVisible(IntPtr hWnd);

		[DllImport("user32.dll")]
		public static extern IntPtr SetParent(IntPtr hWnd, IntPtr hWndNewParent);

		[DllImport("user32.dll")]
		public static extern IntPtr GetParent(IntPtr hWnd);
	}
}
