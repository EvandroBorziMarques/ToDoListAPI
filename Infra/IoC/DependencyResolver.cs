using Domain.Interface;
using Infra.Business;
using Infra.Repositories.Base;
using Infra.Repositories.ToDoRepository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.IoC
{
    public static class DependencyResolver
    {
        public static void RegisterRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IToDo, ToDoBusiness>();
            services.AddScoped<IBaseRepository, BaseRepository>();
            services.AddScoped<IToDoRepository, ToDoRepository>();
        }
    }
}
