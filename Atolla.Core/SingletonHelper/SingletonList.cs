﻿using System.Collections.Generic;

namespace Atolla.Core.SingletonHelper
{
    public class SingletonList<T> : Singleton<IList<T>>
    {
        static SingletonList()
        {
            Singleton<IList<T>>.Instance = new List<T>();
        }

        public new static IList<T> Instance => Singleton<IList<T>>.Instance;
    }
}
