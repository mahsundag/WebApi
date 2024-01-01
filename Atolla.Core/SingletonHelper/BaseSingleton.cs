﻿using System;
using System.Collections.Generic;

namespace Atolla.Core.SingletonHelper
{
    public class BaseSingleton
    {
        static BaseSingleton()
        {
            AllSingletons = new Dictionary<Type, object>();
        }
        public static IDictionary<Type, object> AllSingletons { get; }
    }
}
