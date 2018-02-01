//=============================================================================
// COPYRIGHT: Prosoft-Lanz
//=============================================================================
//
// $Workfile: WindowsHook.cs $
//
// PROJECT : CodeProject Components
// VERSION : 1.00
// CREATION : 19.02.2003
// AUTHOR : JCL
//
// DETAILS : This class implement the Windows hook mechanism.
//           From MSDN, Dino Esposito.
//
//-----------------------------------------------------------------------------
using System;
using System.Runtime.InteropServices;

namespace SharpLib.Forms
{


	/// Class used for hook event arguments.
	public class HookEventArgs : EventArgs
	{
		/// Event code parameter.
		public int code;
		/// wParam parameter.
		public IntPtr wParam;
		/// lParam parameter.
		public IntPtr lParam;

		internal HookEventArgs(int code, IntPtr wParam, IntPtr lParam)
		{
			this.code = code;
			this.wParam = wParam;
			this.lParam = lParam;
		}
	}
	

	/// <summary>
	/// Class to expose the windows hook mechanism.
	/// </summary>
	public class WindowsHook
	{
		// internal properties
		internal IntPtr hHook = IntPtr.Zero;
		internal Win32.HOOKPROC filterFunc = null;
		internal Win32.HookType hookType;

		/// <summary>
		/// Hook delegate method.
		/// </summary>
		public delegate void HookEventHandler(object sender, HookEventArgs e);

		/// <summary>
		/// Hook invoke event.
		/// </summary>
		public event HookEventHandler HookInvoke;

		internal void OnHookInvoke(HookEventArgs e)
		{
			if (HookInvoke != null)
				HookInvoke(this, e);
		}

		/// <summary>
		/// Construct a HookType hook.
		/// </summary>
		/// <param name="hook">Hook type.</param>
		public WindowsHook(Win32.HookType hook)
		{
			hookType = hook;
			filterFunc = new Win32.HOOKPROC(this.CoreHookProc);
		}
		/// <summary>
		/// Construct a HookType hook giving a hook filter delegate method.
		/// </summary>
		/// <param name="hook">Hook type</param>
		/// <param name="func">Hook filter event.</param>
		public WindowsHook(Win32.HookType hook, Win32.HOOKPROC func)
		{
			hookType = hook;
			filterFunc = func; 
		}

		// default hook filter function
		internal int CoreHookProc(int code, IntPtr wParam, IntPtr lParam)
		{
			if (code < 0)
				return Win32.Function.CallNextHookEx(hHook, code, wParam, lParam);

			// let clients determine what to do
			HookEventArgs e = new HookEventArgs(code, wParam, lParam);
			OnHookInvoke(e);

			// yield to the next hook in the chain
			return Win32.Function.CallNextHookEx(hHook, code, wParam, lParam);
		}

		/// <summary>
		/// Install the hook. 
		/// </summary>
		public void Install()
		{
			hHook = Win32.Function.SetWindowsHookEx(hookType, filterFunc, IntPtr.Zero, (int)AppDomain.GetCurrentThreadId());
		}

		
		/// <summary>
		/// Uninstall the hook.
		/// </summary>
 		public void Uninstall()
		{
			if (hHook != IntPtr.Zero)
			{
				Win32.Function.UnhookWindowsHookEx(hHook);
				hHook = IntPtr.Zero;
			}
		}


	}
}
