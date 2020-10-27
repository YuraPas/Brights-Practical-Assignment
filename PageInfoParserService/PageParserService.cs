using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PageInfoParserService.Interfaces;
using PageInfoParserService.Models;

namespace PageInfoParserService
{
    public class PageParserService : IPageParserService
    {
        private HttpClient _httpClient;
        public PageParserService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<PageInfoModel> GetPagesInfoAsync(string url)
        {
            try
            {
                ValidateUrl(url);

                var response = await _httpClient.GetAsync(url);

                return new PageInfoModel()
                {
                    StatusCode = (int) response.StatusCode,
                    Title = await GetTitleFromResponse(response)
                };
            }
            catch(Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        private static void ValidateUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("Incorrect url");
            }
        }

        private async Task<string> GetTitleFromResponse(HttpResponseMessage response)
        {
            var responseBody = await response.Content.ReadAsStringAsync();

            var match = Regex.Match(responseBody, @"<title\b[^>]*\>\s*(.+?)\s*</title>");

            return match.Success ? match.Groups[1].Value : "Unknown";
        }
    }
}
