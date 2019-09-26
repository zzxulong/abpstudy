using System;
using System.Collections.Generic;
using System.Text;

namespace Long.Core.Modularity
{
    /// <summary>
    /// 预配置服务
    /// </summary>
    public interface IPreConfigureServices
    {
        /// <summary>
        /// 预配置服务
        /// </summary>
        /// <param name="context"></param>
        void PreConfigureServices (ServiceConfigurationContext context);
    }
}
