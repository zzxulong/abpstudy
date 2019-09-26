using System;
using System.Collections.Generic;
using System.Text;

namespace Long.Core.DependencyInjection
{
    public interface IServiceProviderAccessor
    {
        IServiceProvider ServiceProvider { get; }
    }
}
