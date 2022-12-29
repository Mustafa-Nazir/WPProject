using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public interface IServiceModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}
