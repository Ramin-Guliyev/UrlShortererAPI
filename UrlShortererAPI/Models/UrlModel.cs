using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortererAPI.Models
{
    public class UrlModel
    {
        [Url]
        [Required]
        public string UrlAddress { get; set; }
    }
}
