﻿using System;

namespace NeatInput.Domain.Native.Enums
{
    [Flags]
    public enum MSLLHOOKSTRUCTFlags : uint
    {
        LLMHF_INJECTED = 0x01,
        LLMHF_LOWER_IL_INJECTED = 0x02
    }
}
