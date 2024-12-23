﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.GenericBoxOfInteger
{
    public class Box<T>
    {
        public Box(T value)
        {
            this.Value = value;
        }
        public T Value { get; set; }

        public override string ToString()
        {
            Type valueType = this.Value.GetType();
            string valueTypeFullName = valueType.FullName;

            return $"{valueTypeFullName}: {this.Value}";
        }
    }
}
