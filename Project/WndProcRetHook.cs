//=============================================================================
// COPYRIGHT: Prosoft-Lanz
//=============================================================================
//
// $Workfile: WndProcRetHook.cs $
//
// PROJECT : CodeProject Components
// VERSION : 1.00
// CREATION : 19.02.2003
// AUTHOR : JCL
//
// DETAILS : This class implement the WH_CALLWNDPROCRET Windows hook mechanism.
//           From MSDN, Dino Esposito.
//
//           WindowCreate, WindowDestroye and WindowActivate user events.
//
//-----------------------------------------------------------------------------
using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace SharpLib.Forms
{


	/// Class used for WH_CALLWNDPROCRET hook event arguments.
	public class WndProcRetEventArgs : EventArgs
	{
		/// wParam parameter.
		public IntPtr wParam;
		/// lParam parameter.
		public IntPtr lParam;
		/// CWPRETSTRUCT structure.
		public Win32.CWPRETSTRUCT cw;

		internal WndProcRetEventArgs(IntPtr wParam, IntPtr lParam)
		{
			this.wParam = wParam;
			this.lParam = lParam;
			cw = new Win32.CWPRETSTRUCT();
			Marshal.PtrToStructure(lParam, cw);
		}
	}

	
	/// <summary>
	/// Class to expose the windows WH_CALLWNDPROCRET hook mechanism.
	/// </summary>
	public class WndProcRetHook : WindowsHook
	{
		/// <summary>
		/// WH_CALLWNDPROCRET hook delegate method.
		/// </summary>
		public delegate void WndProcEventHandler(object sender, WndProcRetEventArgs e);

		private IntPtr hWndHooked;

		/// <summary>
		/// Window procedure event.
		/// </summary>
		public event WndProcEventHandler WndProcRet;

		/// <summary>
		/// Construct a WH_CALLWNDPROCRET hook.
		/// </summary>
		/// <param name="hWndHooked">
		/// Handle of the window to be hooked. IntPtr.Zero to hook all window.
		/// </param>
		public WndProcRetHook(IntPtr hWndHooked) : base(Win32.HookType.WH_CALLWNDPROCRET)
		{
			this.hWndHooked = hWndHooked;
			this.HookInvoke += new HookEventHandler(WndProcRetHookInvoked);
		}
		/// <summary>
		/// Construct a WH_CALLWNDPROCRET hook giving a hook filter delegate method.
		/// </summary>
		/// <param name="hWndHooked">
		/// Handle of the window to be hooked. IntPtr.Zero to hook all window.
		/// </param>
		/// <param name="func">Hook filter event.</param>
		public WndProcRetHook(IntPtr hWndHooked, Win32.HOOKPROC func) : base(Win32.HookType.WH_CALLWNDPROCRET, func)
		{
			this.hWndHooked = hWndHooked;
			this.HookInvoke += new HookEventHandler(WndProcRetHookInvoked);
		}

		// handles the hook event
		private void WndProcRetHookInvoked(object sender, HookEventArgs e)
		{
			WndProcRetEventArgs wpe = new WndProcRetEventArgs(e.wParam, e.lParam);
			if ((hWndHooked == IntPtr.Zero || wpe.cw.hWnd == hWndHooked) && WndProcRet != null)
				WndProcRet(this, wpe);
			return;
		}
	}

}
