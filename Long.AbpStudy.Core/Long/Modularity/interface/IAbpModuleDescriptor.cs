using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Long.AbpStudy.Core.Long.Modularity
{
    /// <summary>
    /// 模块描述符
    /// </summary>
    public interface IAbpModuleDescriptor
    {
        Type Type { get; }

        Assembly Assembly { get; }

        IAbpModule Instance { get; }
        /// <summary>
        /// 作为插件加载
        /// </summary>
        bool IsLoadedAsPlugIn { get; }
        /// <summary>
        /// 依赖关系
        /// </summary>
        IReadOnlyList<IAbpModuleDescriptor> Dependencies { get; }
    }
}
