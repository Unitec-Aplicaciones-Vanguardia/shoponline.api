using System;
using System.Collections.Generic;
using System.Text;

namespace shoponline.Core.Interfaces
{
    public interface IBuyerService
    {
        ServiceResult<string> GetBuyerId();
    }
}
