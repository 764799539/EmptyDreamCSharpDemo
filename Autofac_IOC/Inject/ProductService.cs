using Autofac_IOC.Inject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac_IOC.Inject
{
    public class ProductService : IProductService
    {
        /// <summary>
        /// 需要被注入的依赖(Autofac可以直接属性注入)
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
