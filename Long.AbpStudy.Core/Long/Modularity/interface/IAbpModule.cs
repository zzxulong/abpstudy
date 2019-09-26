using System;
using System.Collections.Generic;
using System.Text;

namespace Long.Core.Modularity
{
    public interface IAbpModule
    {
        void ConfigureServices (ServiceConfigurationContext context);
    }
}