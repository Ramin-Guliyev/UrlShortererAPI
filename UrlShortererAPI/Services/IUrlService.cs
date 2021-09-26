using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortererAPI.Services
{
    public interface IUrlService
    {
        Task<string> AddAsync(Models.UrlModel url, string requestIp);
    }
}
