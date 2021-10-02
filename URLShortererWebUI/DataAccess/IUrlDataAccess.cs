using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refit;
using URLShortererWebUI.Models;

namespace URLShortererWebUI.DataAccess
{
    public interface IUrlDataAccess
    {
        [Post("/")]
        Task<string> ShortUrl([Body] UrlModelBlazor model);
    }
}
