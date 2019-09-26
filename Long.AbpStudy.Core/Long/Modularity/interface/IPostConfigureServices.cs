using System;
using System.Collections.Generic;
using System.Text;

namespace Long.Core.Modularity
{
    /// <summary>
    /// 后期配置服务
    /// </summary>
    public interface IPostConfigureServices
    {
        /// <summary>
        /// 后期配置服务
        /// </summary>
        /// <param name="context"></param>
        void PostConfigureServices (ServiceConfigurationContext context);
    }
}
