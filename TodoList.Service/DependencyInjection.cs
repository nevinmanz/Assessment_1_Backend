using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TodoList.Service.Behaviours;
using TodoList.Data;

namespace TodoList.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTodoListAPIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

            services.AddDbContextPool<TodoContext>(options => options.UseSqlServer(configuration.GetConnectionString("TodoListDb")).UseLazyLoadingProxies(true));
            return services;
        }
    }
}
