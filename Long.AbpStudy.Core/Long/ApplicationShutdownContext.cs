﻿using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Long.Core
{
    public class ApplicationShutdownContext
    {
        public IServiceProvider ServiceProvider { get; }

        public ApplicationShutdownContext ([NotNull] IServiceProvider serviceProvider)
        {
            Check.NotNull(serviceProvider, nameof(serviceProvider));

            ServiceProvider = serviceProvider;
        }
    }
}