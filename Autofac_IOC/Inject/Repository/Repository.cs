using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autofac_IOC.Inject.Repository
{
    public class Repository : IRepository
    {
        /// <summary>
        /// 列表查询
        /// </summary>
        /// <returns></returns>
        public string ToList() => "Repository取出的商品列表";
    }
}
