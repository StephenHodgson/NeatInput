﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file for more information:
//      https://github.com/dotnet/winforms/blob/master/LICENSE.TXT

using NeatInput.Windows.Interop.Handles;

using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class User32
    {
        [DllImport(Libraries.User32, ExactSpelling = true, SetLastError = true)]
        internal static extern SetWindowsHookExSafeHandle SetWindowsHookExW(
            WH idHook,
            IntPtr lpfn,
            IntPtr hMod,
            uint dwThreadId);
    }
}