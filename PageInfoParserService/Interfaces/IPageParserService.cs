using System.Threading.Tasks;
using PageInfoParserService.Models;

namespace PageInfoParserService.Interfaces
{
    public interface IPageParserService
    {
        Task<PageInfoModel> GetPagesInfoAsync(string url);
    }
}
