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
using Zero.Service.Products;
using Zero.Service.News;


namespace Zero.Mvc.Manage.Infrastructure
{
    public class DependencyRegistrar
    {
        public void Registrar()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<ProductController>();
            builder.RegisterType<NewsController>();

            //service
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>));

            builder.RegisterType<ProductService>().As<IProductService>().InstancePerHttpRequest();

            builder.RegisterType<NewsService>().As<INewsService>().InstancePerHttpRequest();

            // then
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}