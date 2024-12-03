using IOC_Scrutor.Inject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC_NativeDependencyInjection.Inject
{
    public interface IProductService : ITransientDependency
    {
        string GetProductList();
    }
}
