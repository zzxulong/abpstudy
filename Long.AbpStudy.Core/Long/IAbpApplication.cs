using Long.AbpStudy.Core.Long.Modularity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Long.AbpStudy.Core.Long
{
    /// <summary>
    /// ABP应用
    /// </summary>
    public interface IAbpApplication : IModuleContainer, IDisposable
    {
        /// <summary>
        /// Type of the startup (entrance) module of the application.
        /// 应用程序的启动（入口）模块的类型
        /// </summary>
        Type StartupModuleType { get; }

        /// <summary>
        /// List of services registered to this application.
        /// Can not add new services to this collection after application initialize.
        /// 已注册到此应用程序的服务列表。应用程序初始化后无法将新服务添加到此集合
        /// </summary>
        IServiceCollection Services { get; }

        /// <summary>
        /// Reference to the root service provider used by the application.
        /// This can not be used before initialize the application.
        /// 对应用程序使用的根服务提供程序的引用。
        ///在初始化应用程序之前不能使用。
        /// </summary>
        IServiceProvider ServiceProvider { get; }

        /// <summary>
        /// Used to gracefully shutdown the application and all modules.
        /// 用于正常关闭应用程序和所有模块
        /// </summary>
        void Shutdown ();
    }
}
