using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using NetCoreMovies.Data.Repository.Interfaces;
using System.Collections.Generic;

namespace NetCoreMovies.Data.Repository
{
    public class MaturityRepository : IMaturityRepository
    {
        private readonly IConfiguration _configuration;

        public MaturityRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<SelectListItem> GetMaturityItems()
        {
            var result = new List<SelectListItem>();

            var configMaturities = _configuration.GetSection("MaturityLevels").Get<List<string>>();
            foreach (var configMaturity in configMaturities)
            {
                result.Add(new SelectListItem()
                {
                    Value = configMaturity,
                    Text = configMaturity
                });
            }

            result.Insert(0, new SelectListItem
            {
                Value = "",
                Text = " - "
            });

            return result;
        }
    }
}
