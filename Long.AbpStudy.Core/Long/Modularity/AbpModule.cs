using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Long.Core.Modularity
{
    public abstract class AbpModule :
        IAbpModule,
        IOnPreApplicationInitialization,
        IOnApplicationInitialization,
        IOnPostApplicationInitialization,
        IOnApplicationShutdown,
        IPreConfigureServices,
        IPostConfigureServices
    {
        ///跳过自动服务注册
        protected internal bool SkipAutoServiceRegistration { get; protected set; }
        /// <summary>
        /// 上下文服务配置
        /// </summary>
        protected internal ServiceConfigurationContext ServiceConfigurationContext
        {
            get
            {
                if (_serviceConfigurationContext == null)
                {
                    throw new AbpException($"{nameof(ServiceConfigurationContext)} is only available in the {nameof(ConfigureServices)}, {nameof(PreConfigureServices)} and {nameof(PostConfigureServices)} methods.");
                }

                return _serviceConfigurationContext;
            }
            internal set => _serviceConfigurationContext = value;
        }

        private ServiceConfigurationContext _serviceConfigurationContext;

        /// <summary>
        /// 预配置服务
        /// </summary>
        /// <param name="context"></param>
        public virtual void PreConfigureServices (ServiceConfigurationContext context)
        {

        }

        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="context"></param>
        public virtual void ConfigureServices (ServiceConfigurationContext context)
        {

        }

        /// <summary>
        /// 后配置服务
        /// </summary>
        /// <param name="context"></param>
        public virtual void PostConfigureServices (ServiceConfigurationContext context)
        {

        }

        /// <summary>
        /// 应用前初始化
        /// </summary>
        /// <param name="context"></param>
        public virtual void OnPreApplicationInitialization (ApplicationInitializationContext context)
        {

        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="context"></param>
        public virtual void OnApplicationInitialization (ApplicationInitializationContext context)
        {

        }
        /// <summary>
        /// 应用后初始化
        /// </summary>
        /// <param name="context"></param>
        public virtual void OnPostApplicationInitialization (ApplicationInitializationContext context)
        {

        }
        /// <summary>
        /// 应用程序关闭
        /// </summary>
        /// <param name="context"></param>
        public virtual void OnApplicationShutdown (ApplicationShutdownContext context)
        {

        }

        /// <summary>
        /// 是ABP模块
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsAbpModule (Type type)
        {
            var typeInfo = type.GetTypeInfo();

            return
                typeInfo.IsClass &&
                !typeInfo.IsAbstract &&
                !typeInfo.IsGenericType &&
                typeof(IAbpModule).GetTypeInfo().IsAssignableFrom(type);
        }
        /// <summary>
        /// 检查ABP模块类型
        /// </summary>
        /// <param name="moduleType"></param>
        internal static void CheckAbpModuleType (Type moduleType)
        {
            if (!IsAbpModule(moduleType))
            {
                throw new ArgumentException("Given type is not an ABP module: " + moduleType.AssemblyQualifiedName);
            }
        }

        protected void Configure<TOptions> (Action<TOptions> configureOptions)
            where TOptions : class
        {
            ServiceConfigurationContext.Services.Configure(configureOptions);
        }

        protected void Configure<TOptions> (string name, Action<TOptions> configureOptions)
            where TOptions : class
        {
            ServiceConfigurationContext.Services.Configure(name, configureOptions);
        }

        protected void Configure<TOptions> (IConfiguration configuration)
            where TOptions : class
        {
            ServiceConfigurationContext.Services.Configure<TOptions>(configuration);
        }

        protected void Configure<TOptions> (IConfiguration configuration, Action<BinderOptions> configureBinder)
            where TOptions : class
        {
            ServiceConfigurationContext.Services.Configure<TOptions>(configuration, configureBinder);
        }

        protected void Configure<TOptions> (string name, IConfiguration configuration)
            where TOptions : class
        {
            ServiceConfigurationContext.Services.Configure<TOptions>(name, configuration);
        }
        /// <summary>
        /// 预配置
        /// </summary>
        /// <typeparam name="TOptions"></typeparam>
        /// <param name="configureOptions"></param>
        protected void PreConfigure<TOptions> (Action<TOptions> configureOptions)
            where TOptions : class
        {
            ServiceConfigurationContext.Services.PreConfigure(configureOptions);
        }
    }
}