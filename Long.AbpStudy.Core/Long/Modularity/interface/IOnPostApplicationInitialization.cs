using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Long.Core.Modularity
{
    public interface IOnPostApplicationInitialization
    {
        void OnPostApplicationInitialization ([NotNull] ApplicationInitializationContext context);
    }
}