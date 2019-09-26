using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Long.AbpStudy.Core.Long.Modularity
{
    public interface IModuleManager
    {
        void InitializeModules ([NotNull] ApplicationInitializationContext context);

        void ShutdownModules ([NotNull] ApplicationShutdownContext context);
    }
}
