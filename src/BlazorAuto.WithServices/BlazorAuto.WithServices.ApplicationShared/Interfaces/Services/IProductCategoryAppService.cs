using BlazorAuto.WithServices.ApplicationShared.Handlers.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAuto.WithServices.ApplicationShared.Interfaces.Services
{
    public interface IProductCategoryAppService
    {
        ValueTask<IEnumerable<ProductCategoryResponse>> ReadAll();
    }
}
