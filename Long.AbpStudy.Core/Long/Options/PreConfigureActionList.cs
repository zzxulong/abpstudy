using System;
using System.Collections.Generic;
using System.Text;

namespace Long.AbpStudy.Core.Long.Options
{
    public class PreConfigureActionList<TOptions> : List<Action<TOptions>>
    {
        public void Configure (TOptions options)
        {
            foreach (var action in this)
            {
                action(options);
            }
        }
    }
}