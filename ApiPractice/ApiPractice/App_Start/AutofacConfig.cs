using ApiPractice.Data;
using ApiPractice.Models;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace ApiPractice.App_Start
{
	public class AutofacConfig
	{
		public static void Configure()
		{
			var builder = new ContainerBuilder();
			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

			builder.RegisterType<PracticeCovidContext>().SingleInstance();

			builder.RegisterType<CovidRepository>()
			.As<ICovidRepository>()
			.SingleInstance();

			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new CovidStatsProfile());
			});

			builder.RegisterInstance(config.CreateMapper())
			.As<IMapper>()
			.SingleInstance();

			var container = builder.Build();

			var globalConfig = GlobalConfiguration.Configuration;
			globalConfig.DependencyResolver = new AutofacWebApiDependencyResolver(container);
		}
	}

}