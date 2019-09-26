using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Long.AbpStudy.Core.Long
{
    /// <summary>
    /// 应用程序关闭
    /// </summary>
    public interface IOnApplicationShutdown
    {
        /// <summary>
        /// 应用程序关闭
        /// </summary>
        /// <param name="context"></param>
        void OnApplicationShutdown ([NotNull] ApplicationShutdownContext context);
    }
}