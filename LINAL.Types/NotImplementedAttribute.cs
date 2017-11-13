using System;
using System.Collections.Generic;
using System.Text;

namespace LINAL.Types
{
    [System.AttributeUsage(AttributeTargets.Property | AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
    public sealed class NotImplementedAttribute : Attribute
    {
    }
}
