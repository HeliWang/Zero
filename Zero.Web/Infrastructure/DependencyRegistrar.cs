using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Autofac;
using Autofac.Integration.Mvc;
using Zero.Data;
using Zero.Web.Controllers;
using Zero.Service.Cates;
using Zero.Service.Products;
using Zero.Service.News;
using Zero.Service.Trades;
using Zero.Service.Customs;
using Zero.Domain.Cates;

namespace Zero.Web.Infrastructure
{
    public class DependencyRegistrar
    {
        public void Registrar()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<HomeController>();
            builder.RegisterType<ProductController>();

            builder.RegisterType<EfDbContext>().As<IDbContext>().InstancePerHttpRequest();

            //builder.Register<IDbContext>(c => new EfDbContext()).InstancePerLifetimeScope();

            //service
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>));

            builder.RegisterType<CateService>().As<ICateService<Cate>>().InstancePerHttpRequest();
            builder.RegisterType<CateAttrService>().As<ICateAttrService>().InstancePerHttpRequest();
            builder.RegisterType<AttrService>().As<IAttrService>().InstancePerHttpRequest();
            builder.RegisterType<AttrValueService>().As<IAttrValueService>().InstancePerHttpRequest();

            builder.RegisterType<ProductService>().As<IProductService>().InstancePerHttpRequest();

            builder.RegisterType<NewsService>().As<INewsService>().InstancePerHttpRequest();

            // then
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}