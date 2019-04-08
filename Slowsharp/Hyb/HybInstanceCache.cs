﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slowsharp
{
    internal class HybInstanceCache
    {
        public static readonly HybInstance Zero = HybInstance.Int(0);
        public static readonly HybInstance One = HybInstance.Int(1);
        public static readonly HybInstance MinusOne = HybInstance.Int(-1);
    }
}
