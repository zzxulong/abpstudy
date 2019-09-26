using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Long.Core.Modularity
{
    /// <summary>
    /// 模块容器
    /// </summary>
    public interface IModuleContainer
    {
        [NotNull]
        IReadOnlyList<IAbpModuleDescriptor> Modules { get; }
    }
}