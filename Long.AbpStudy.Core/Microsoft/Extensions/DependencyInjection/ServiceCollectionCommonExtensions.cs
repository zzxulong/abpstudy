using JetBrains.Annotations;
using Long.AbpStudy.Core.Long;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Long.AbpStudy.Core.Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 服务集合公共扩展
    /// </summary>
    public static class ServiceCollectionCommonExtensions
    {
        /// <summary>
        /// 添加的
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static bool IsAdded<T> (this IServiceCollection services)
        {
            return services.IsAdded(typeof(T));
        }
        /// <summary>
        /// 添加的
        /// </summary>
        /// <param name="services"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsAdded (this IServiceCollection services, Type type)
        {
            return services.Any(d => d.ServiceType == type);
        }
        /// <summary>
        /// 获取单实例或空
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static T GetSingletonInstanceOrNull<T> (this IServiceCollection services)
        {
            return (T)services
                .FirstOrDefault(d => d.ServiceType == typeof(T))
                ?.ImplementationInstance;
        }
        /// <summary>
        /// 获取单实例或空
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static T GetSingletonInstance<T> (this IServiceCollection services)
        {
            var service = services.GetSingletonInstanceOrNull<T>();
            if (service == null)
            {
                throw new InvalidOperationException("Could not find singleton service: " + typeof(T).AssemblyQualifiedName);
            }

            return service;
        }
        /// <summary>
        /// 从工厂生成服务提供程序
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceProvider BuildServiceProviderFromFactory ([NotNull] this IServiceCollection services)
        {
            Check.NotNull(services, nameof(services));

            foreach (var service in services)
            {
                var factoryInterface = service.ImplementationInstance?.GetType()
                    .GetTypeInfo()
                    .GetInterfaces()
                    .FirstOrDefault(i => i.GetTypeInfo().IsGenericType &&
                                         i.GetGenericTypeDefinition() == typeof(IServiceProviderFactory<>));

                if (factoryInterface == null)
                {
                    continue;
                }

                var containerBuilderType = factoryInterface.GenericTypeArguments[0];
                return (IServiceProvider)typeof(ServiceCollectionCommonExtensions)
                    .GetTypeInfo()
                    .GetMethods()
                    .Single(m => m.Name == nameof(BuildServiceProviderFromFactory) && m.IsGenericMethod)
                    .MakeGenericMethod(containerBuilderType)
                    .Invoke(null, new object[] { services, null });
            }

            return services.BuildServiceProvider();
        }
        /// <summary>
        /// 从工厂生成服务提供程序
        /// </summary>
        /// <typeparam name="TContainerBuilder"></typeparam>
        /// <param name="services"></param>
        /// <param name="builderAction"></param>
        /// <returns></returns>
        public static IServiceProvider BuildServiceProviderFromFactory<TContainerBuilder> ([NotNull] this IServiceCollection services, Action<TContainerBuilder> builderAction = null)
        {
            Check.NotNull(services, nameof(services));

            var serviceProviderFactory = services.GetSingletonInstanceOrNull<IServiceProviderFactory<TContainerBuilder>>();
            if (serviceProviderFactory == null)
            {
                throw new AbpException($"Could not find {typeof(IServiceProviderFactory<TContainerBuilder>).FullName} in {services}.");
            }

            var builder = serviceProviderFactory.CreateBuilder(services);
            builderAction?.Invoke(builder);
            return serviceProviderFactory.CreateServiceProvider(builder);
        }

        /// <summary>
        /// Resolves a dependency using given <see cref="IServiceCollection"/>.
        /// This method should be used only after dependency injection registration phase completed.
        /// 使用给定的<see cref=“iservicecollection”/>解析依赖关系。
        ///此方法只能在依赖项注入注册阶段完成后使用。
        /// </summary>
        internal static T GetService<T> (this IServiceCollection services)
        {
            return services
                .GetSingletonInstance<IAbpApplication>()
                .ServiceProvider
                .GetService<T>();
        }

        /// <summary>
        /// Resolves a dependency using given <see cref="IServiceCollection"/>.
        /// This method should be used only after dependency injection registration phase completed.
        /// 使用给定的<see cref=“iservicecollection”/>解析依赖关系。 
        ///此方法只能在依赖项注入注册阶段完成后使用。
        /// </summary>
        internal static object GetService (this IServiceCollection services, Type type)
        {
            return services
                .GetSingletonInstance<IAbpApplication>()
                .ServiceProvider
                .GetService(type);
        }

        /// <summary>
        /// Resolves a dependency using given <see cref="IServiceCollection"/>.
        /// Throws exception if service is not registered.
        /// This method should be used only after dependency injection registration phase completed.
        /// 使用给定的<see cref=“iservicecollection”/>解析依赖关系。 
        ///如果服务未注册，则引发异常。 
        ///此方法只能在依赖项注入注册阶段完成后使用。
        /// </summary>
        internal static T GetRequiredService<T> (this IServiceCollection services)
        {
            return services
                .GetSingletonInstance<IAbpApplication>()
                .ServiceProvider
                .GetRequiredService<T>();
        }

        /// <summary>
        /// Resolves a dependency using given <see cref="IServiceCollection"/>.
        /// Throws exception if service is not registered.
        /// This method should be used only after dependency injection registration phase completed.
        /// 使用给定的<see cref=“iservicecollection”/>解析依赖关系。 
        ///如果服务未注册，则引发异常。 
        ///此方法只能在依赖项注入注册阶段完成后使用。
        /// </summary>
        internal static object GetRequiredService (this IServiceCollection services, Type type)
        {
            return services
                .GetSingletonInstance<IAbpApplication>()
                .ServiceProvider
                .GetRequiredService(type);
        }

        /// <summary>
        /// Returns a <see cref="Lazy{T}"/> to resolve a service from given <see cref="IServiceCollection"/>
        /// once dependency injection registration phase completed.
        /// 返回a<see cref=“lazy{t}/>以从给定的解析服务 
        ///依赖注入注册阶段完成后。
        /// </summary>
        public static Lazy<T> GetServiceLazy<T> (this IServiceCollection services)
        {
            return new Lazy<T>(services.GetService<T>, true);
        }

        /// <summary>
        /// Returns a <see cref="Lazy{T}"/> to resolve a service from given <see cref="IServiceCollection"/>
        /// once dependency injection registration phase completed.
        /// 返回a<see cref=“lazy{t}/>，以便在依赖注入注册阶段完成后从给定的<see cref=“iservicecollection”/>解析服务。
        /// </summary>
        public static Lazy<object> GetServiceLazy (this IServiceCollection services, Type type)
        {
            return new Lazy<object>(() => services.GetService(type), true);
        }

        /// <summary>
        /// Returns a <see cref="Lazy{T}"/> to resolve a service from given <see cref="IServiceCollection"/>
        /// once dependency injection registration phase completed.
        /// 返回a<see cref=“lazy{t}/>，以便在依赖注入注册阶段完成后从给定的<see cref=“iservicecollection”/>解析服务。
        /// </summary>
        public static Lazy<T> GetRequiredServiceLazy<T> (this IServiceCollection services)
        {
            return new Lazy<T>(services.GetRequiredService<T>, true);
        }

        /// <summary>
        /// Returns a <see cref="Lazy{T}"/> to resolve a service from given <see cref="IServiceCollection"/>
        /// once dependency injection registration phase completed.
        /// 返回a<see cref=“lazy{t}/>，以便在依赖注入注册阶段完成后从给定的<see cref=“iservicecollection”/>解析服务。
        /// </summary>
        public static Lazy<object> GetRequiredServiceLazy (this IServiceCollection services, Type type)
        {
            return new Lazy<object>(() => services.GetRequiredService(type), true);
        }
    }
}
