using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Long.Core
{
    /// <summary>
    /// On Application Initialization
    /// 应用初始化
    /// </summary>
    public interface IOnApplicationInitialization
    {
        /// <summary>
        /// On Application Initialization
        /// 应用初始化
        /// </summary>
        /// <param name="context"></param>
        void OnApplicationInitialization ([NotNull] ApplicationInitializationContext context);
    }
}