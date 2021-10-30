using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BRCS.BHDAPI
{
    internal class BHDAPIClient
    {
        const string baseurl = "https://beyond-hd.me/api/torrents/";

        string _apiKey;
        string _rssKey;

        internal BHDAPIClient(string APIKey, string RSSKey)
        {
            _apiKey = APIKey;
            _rssKey = RSSKey;
        }

        internal async Task<BHDResponse> FindRescueableMoviesAsync(int page = 1)
        {
            Dictionary<string, string> postData = new Dictionary<string, string>
            {
                { BHDParams.action, "search" },
                { BHDParams.rsskey, _rssKey },
                { BHDParams.categories, "Movies" },
                { BHDParams.rescue, "1" },
                { BHDParams.seeding, "0" },
                { BHDParams.leeching, "0" },
                { BHDParams.sort, "seeders" },
                { BHDParams.order, "asc" },
                { BHDParams.page, page.ToString() }
            };

            var client = new HttpClient();
            var url = baseurl + _apiKey;
            var response = await client.PostAsync(url, new FormUrlEncodedContent(postData));

            string content = await response.Content.ReadAsStringAsync();
            var bhdResponse = JsonConvert.DeserializeObject<BHDResponse>(content);
            return bhdResponse;
        }
    }
}
