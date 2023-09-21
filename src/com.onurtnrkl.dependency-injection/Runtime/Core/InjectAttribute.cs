using System;
using UnityEngine.Scripting;

namespace DependencyInjection.Core
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class InjectAttribute : PreserveAttribute
    {
    }
}
