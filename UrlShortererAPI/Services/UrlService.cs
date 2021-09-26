using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UrlShortererAPI.Data;
using UrlShortererAPI.Models;

namespace UrlShortererAPI.Services
{
    public class UrlService : IUrlService
    {
        private readonly ApplicationDbContext _context;

        public UrlService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddAsync(UrlModel url, string requestIp)
        {
            _context.UrlModels.Add(new Models.Url
            {
                FullUrl = url.UrlAddress,
                IpAddress = requestIp
            });

            await _context.SaveChangesAsync();

            var id = await _context.UrlModels.
                FirstOrDefaultAsync(x => x.FullUrl == url.UrlAddress);

            return Shorter.Encode(id.Id);
        }

        public async Task<string> GetUrl(string key)
        {
            int id = Shorter.Decode(key);
            var model = await _context.UrlModels.FindAsync(id);
            return model.FullUrl;
        }
    }
}
