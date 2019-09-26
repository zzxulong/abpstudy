using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Long.AbpStudy.Core.Long.DependencyInjection
{
    /// <summary>
    /// 访问器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IObjectAccessor<out T>
    {
        [CanBeNull]
        T Value { get; }
    }
}
