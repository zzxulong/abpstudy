using JetBrains.Annotations;
using Long.AbpStudy.Core.Long.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Long.AbpStudy.Core.Long
{

    public class ApplicationInitializationContext : IServiceProviderAccessor
    {
        public IServiceProvider ServiceProvider { get; set; }

        public ApplicationInitializationContext ([NotNull] IServiceProvider serviceProvider)
        {
            Check.NotNull(serviceProvider, nameof(serviceProvider));

            ServiceProvider = serviceProvider;
        }
    }
}
