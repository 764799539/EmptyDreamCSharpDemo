using Microsoft.Extensions.DependencyInjection;
using Autofac_IOC.Inject;
using Autofac_IOC.Inject.Repository;
using Autofac;
using System.Reflection;

namespace Autofac_IOC
{
    /// <summary>
    /// Autofac依赖注入
    /// </summary>
    public class AutofacDependencyInjection
    {
        /// <summary>
        /// 
        /// </summary>
        public void Base()
        { 
            // 创建ContainerBuilder
            ContainerBuilder ContainerBuilder = new();

            // 注册各种当前程序集服务 （同样支持多实现） (课程中提到需要添加PropertiesAutowired才可以实现属性注入，但是此处发现不需要PropertiesAutowired依旧实现了属性注入，为什么？)
            // 错误：初步确认是因为ProductService类中来自C#11的required关键字影响了Autofac
            // 正确：从 Microsoft.Extensions.DependencyInjection 9.0.0 开始，框架原生支持了属性注入，所以Autofac的存在意义又下降了很多，使用Scrutor实现批量注册即可
            ContainerBuilder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                            //.Where(t => t.GetInterfaces().Any(x => x == typeof(IRepository))) // 实现注册过滤（也可使用特性过滤 ）
                            .AsImplementedInterfaces() // 只要实现了接口的都实现注册
                            .PropertiesAutowired();    // 开发属性依赖注入

            // 构造IOC容器
            var Container = ContainerBuilder.Build();

            // 取对象(Scope)
            using (var Scope = Container.BeginLifetimeScope())
            {
                IProductService ProductService = Scope.Resolve<IProductService>();
                var Result = ProductService.GetProductList();
                Console.WriteLine(Result);
            }
        }
    }
}
