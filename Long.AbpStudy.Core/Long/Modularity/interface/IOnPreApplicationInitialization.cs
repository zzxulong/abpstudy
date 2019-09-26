using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Long.AbpStudy.Core.Long.Modularity
{
    /// <summary>
    /// 应用前初始化
    /// </summary>
    public interface IOnPreApplicationInitialization
    {
        /// <summary>
        /// 应用前初始化
        /// </summary>
        /// <param name="context"></param>
        void OnPreApplicationInitialization ([NotNull] ApplicationInitializationContext context);
    }
}