using Microsoft.Extensions.DependencyInjection;
using IOC_NativeDependencyInjection.Inject;
using IOC_NativeDependencyInjection.Inject.Repository;
using IOC_Scrutor.Inject.Service;

namespace IOC_NativeDependencyInjection
{
    /// <summary>
    /// 原生依赖注入 + Scrutor批量注册
    /// </summary>
    public class NativeAndScrutor
    {
        /// <summary>
        /// 基础
        /// </summary>
        public void Base()
        {
            ServiceCollection Collection = new();

            // Scrutor批量注册
            Collection.Scan(Scan => Scan
                      .FromAssemblyOf<Program>()
                      .AddClasses(Classes => Classes.AssignableTo<ITransientDependency>())
                      .AsMatchingInterface()
                      .WithTransientLifetime()
                      .FromAssemblyOf<Program>()
                      .AddClasses(Classes => Classes.AssignableTo<ISingletonDependency>())
                      .AsMatchingInterface()
                      .WithSingletonLifetime()
                      .FromAssemblyOf<Program>()
                      .AddClasses(Classes => Classes.AssignableTo<IScopedDependency>())
                      .AsMatchingInterface()
                      .WithScopedLifetime());

            // 构造ServiceProvider
            var ServiceProvider = Collection.BuildServiceProvider();

            // 取对象
            IProductService Service = ServiceProvider.GetService<IProductService>();
            string Result = Service.GetProductList();
            Console.WriteLine(Result);
        }
    }
}
