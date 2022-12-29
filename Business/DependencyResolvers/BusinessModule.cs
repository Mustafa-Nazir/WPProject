using Business.Abstract;
using Business.Concrete;
using Core.Utilities.IoC;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers
{
    public class BusinessModule : IServiceModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IApplicationUserDal, EfApplicationUserDal>();
            serviceCollection.AddSingleton<IApplicationUserService, ApplicationUserManager>();
            serviceCollection.AddSingleton<IFollowerDal, EfFollowerDal>();
            serviceCollection.AddSingleton<IFollowerService, FollowerManager>();
            serviceCollection.AddSingleton<IImageDal, EfImageDal>();
            serviceCollection.AddSingleton<IImageService, ImageManager>();
        }
    }
}
