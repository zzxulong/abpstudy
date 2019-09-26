using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Long.AbpStudy.Core.Long.Modularity
{
    public class ServiceConfigurationContext
    {
        public IServiceCollection Services { get; }

        public IDictionary<string, object> Items { get; }

        /// <summary>
        /// Gets/sets arbitrary named objects those can be stored during
        /// the service registration phase and shared between modules.
        ///
        /// This is a shortcut usage of the <see cref="Items"/> dictionary.
        /// Returns null if given key is not found in the <see cref="Items"/> dictionary.
        /// 获取/设置可在服务注册阶段存储并在模块之间共享的任意命名对象
        /// 这是<see cref=“items”/>字典的快捷用法。
        ///如果在<see cref=“items”/>字典中找不到给定的键，则返回null。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object this[string key]
        {
            get => Items.GetOrDefault(key);
            set => Items[key] = value;
        }

        public ServiceConfigurationContext ([NotNull] IServiceCollection services)
        {
            Services = Check.NotNull(services, nameof(services));
            Items = new Dictionary<string, object>();
        }
    }
}
