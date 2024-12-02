using IOC_NativeDependencyInjection.Inject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_NativeDependencyInjection.Inject
{
    public class ProductService : IProductService
    {
        public ProductService(IRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        /// <summary>
        /// 需要被注入的依赖
        /// </summary>
        public required IRepository ProductRepository { get; set; }


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
