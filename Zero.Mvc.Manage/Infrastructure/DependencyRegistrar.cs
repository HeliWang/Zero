using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Autofac;
using Autofac.Integration.Mvc;
using Zero.Data;
using Zero.Mvc.Manage.Controllers.Products;
using Zero.Mvc.Manage.Controllers.News;
using Zero.Mvc.Manage.Controllers.Customs;
using Zero.Service.Products;
using Zero.Service.News;
using Zero.Service.Customs;


namespace Zero.Mvc.Manage.Infrastructure
{
    public class DependencyRegistrar
    {
        public void Registrar()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<ProductController>();
            builder.RegisterType<NewsController>();
            builder.RegisterType<CustomController>();

            //service
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>));

            builder.RegisterType<ProductService>().As<IProductService>().InstancePerHttpRequest();

            builder.RegisterType<NewsService>().As<INewsService>().InstancePerHttpRequest();

            builder.RegisterType<CustomService>().As<ICustomService>().InstancePerHttpRequest();

            // then
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}