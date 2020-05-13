using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMovies.Data.Repository.Interfaces
{
    public interface IMaturityRepository
    {
        List<SelectListItem> GetMaturityItems();
    }
}
