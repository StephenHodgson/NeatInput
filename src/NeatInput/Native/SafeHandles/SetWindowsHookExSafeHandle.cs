﻿using Microsoft.Win32.SafeHandles;

using System.Runtime.ConstrainedExecution;
using System.Security.Permissions;

namespace NeatInput.Native.SafeHandles
{
    [SecurityPermission(SecurityAction.InheritanceDemand, UnmanagedCode = true)]
    [SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
    public class SetWindowsHookExSafeHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private SetWindowsHookExSafeHandle()
            : base(true)
        {
        }

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        protected override bool ReleaseHandle()
        {
            return User32.UnhookWindowsHookEx(handle);
        }
    }
}
