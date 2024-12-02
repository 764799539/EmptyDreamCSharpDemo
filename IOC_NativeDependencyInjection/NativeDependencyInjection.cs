using Microsoft.Extensions.DependencyInjection;
using IOC_NativeDependencyInjection.Inject;
using IOC_NativeDependencyInjection.Inject.Repository;

namespace IOC_NativeDependencyInjection
{
    /// <summary>
    /// 原生依赖注入
    /// </summary>
    public class NativeDependencyInjection
    {
        /// <summary>
        /// 基础
        /// </summary>
        public void Base()
        {
            // 创建依赖注入容器（IOC容器）
            ServiceCollection Collection = new();

            // 单例（生命周期）注册ProductRepository
            Collection.AddSingleton<IRepository, Repository>();
            // 单例（生命周期）注册ProductService
            Collection.AddSingleton<IProductService, ProductService>();

            // 瞬时（生命周期）
            //Collection.AddTransient<>();
            // 作用域（生命周期） 
            //Collection.AddScoped<>(); 

            // 构造ServiceProvider
            var ServiceProvider = Collection.BuildServiceProvider();

            // 单例或瞬时 取对象
            IProductService Service = ServiceProvider.GetService<IProductService>();
            string Result = Service.GetProductList();
            Console.WriteLine(Result);

            // 作用域 取对象 
            //using (IServiceScope ServiceScope = ServiceProvider.CreateScope())
            //{
            //    IProductService Service = ServiceScope.ServiceProvider.GetRequiredService<IProductService>();
            //    string Result = Service.GetProductList();
            //    Console.WriteLine(Result);
            //}
        }

        /// <summary>
        /// 多个实现类
        /// </summary>
        public void MultipleImplementationClass()
        {
            ServiceCollection Collection = new();

            // 注册两个仓储实现
            Collection.AddSingleton<IRepository, Repository>();
            Collection.AddSingleton<IRepository, RedisRepository>();

            var ServiceProvider = Collection.BuildServiceProvider();

            // 获取实现类列表
            IEnumerable<IRepository> ServerList = ServiceProvider.GetServices<IRepository>();
            foreach (var item in ServerList)
            {
                Console.WriteLine(item.ToList());
            }
        }
    }
}
