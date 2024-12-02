using NativeDependencyInjection_IOC.Inject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeDependencyInjection_IOC.Inject
{
    public class ProductService : IProductService
    {
        /// <summary>
        /// 需要被注入的依赖
        /// </summary>
        public required IRepository ProductRepository { get; set; }

        /// <summary>
        /// 原生依赖注入容器需要通过构造函数传入并赋值
        /// </summary>
        /// <param name="productRepository"></param>
        public ProductService(IRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <returns></returns>
        public string GetProductList()
        {
            return ProductRepository.ToList();
        }
    }
}
