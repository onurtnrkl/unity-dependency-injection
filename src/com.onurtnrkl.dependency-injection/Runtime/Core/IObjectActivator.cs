﻿using System;

namespace DependencyInjection.Activators
{
    internal interface IObjectActivator
    {
        Type[] ParameterTypes { get; }
        void Activate(object uninitializedObject, params object[] parameters);
    }
}
