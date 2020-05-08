using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace PH.Models.Automapper
{
    public static class ModelExtensions
    {
        /// <summary>
        /// 注册automapper服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddAutomapperService(this IServiceCollection services)
        {
            //将AutoMapper映射配置所在的程序集名称注册
            services.AddAutoMapper(Assembly.Load(Assembly.GetExecutingAssembly().GetName().Name));
            return services;
        }
    }
}
