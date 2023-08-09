using System;
using UnityEngine.Scripting;

namespace DependencyInjection.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class InjectAttribute : PreserveAttribute
    {
    }
}
