using System;
using System.Collections.Generic;
using System.Text;

namespace Long.AbpStudy.Core.Long.Modularity
{
    public interface IAbpModule
    {
        void ConfigureServices (ServiceConfigurationContext context);
    }
}