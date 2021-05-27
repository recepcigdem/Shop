using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<SalesManager>().As<ISalesService>();
            builder.RegisterType<EfSalesDal>().As<ISalesDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();


        }
    }
}
