using Long.AbpStudy.Core.Long.DependencyInjection;
using Long.AbpStudy.Core.Long.Options;
using Long.AbpStudy.Core.Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionPreConfigureExtensions
    {
        /// <summary>
        /// 预配置
        /// </summary>
        /// <typeparam name="TOptions"></typeparam>
        /// <param name="services"></param>
        /// <param name="optionsAction"></param>
        /// <returns></returns>
        public static IServiceCollection PreConfigure<TOptions> (this IServiceCollection services, Action<TOptions> optionsAction)
        {
            services.GetPreConfigureActions<TOptions>().Add(optionsAction);
            return services;
        }
        /// <summary>
        /// 执行配置动作
        /// </summary>
        /// <typeparam name="TOptions"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static TOptions ExecutePreConfiguredActions<TOptions> (this IServiceCollection services)
            where TOptions : new()
        {
            return services.ExecutePreConfiguredActions(new TOptions());
        }
        /// <summary>
        /// 执行配置动作
        /// </summary>
        /// <typeparam name="TOptions"></typeparam>
        /// <param name="services"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static TOptions ExecutePreConfiguredActions<TOptions> (this IServiceCollection services, TOptions options)
        {
            services.GetPreConfigureActions<TOptions>().Configure(options);
            return options;
        }
        /// <summary>
        /// 获取预配置
        /// </summary>
        /// <typeparam name="TOptions"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static PreConfigureActionList<TOptions> GetPreConfigureActions<TOptions> (this IServiceCollection services)
        {
            var actionList = services.GetSingletonInstanceOrNull<IObjectAccessor<PreConfigureActionList<TOptions>>>()?.Value;
            if (actionList == null)
            {
                actionList = new PreConfigureActionList<TOptions>();
                services.AddObjectAccessor(actionList);
            }

            return actionList;
        }
    }
}
