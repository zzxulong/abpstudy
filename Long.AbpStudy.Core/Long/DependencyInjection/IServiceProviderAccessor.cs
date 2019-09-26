using System;
using System.Collections.Generic;
using System.Text;

namespace Long.AbpStudy.Core.Long.DependencyInjection
{
    public interface IServiceProviderAccessor
    {
        IServiceProvider ServiceProvider { get; }
    }
}
