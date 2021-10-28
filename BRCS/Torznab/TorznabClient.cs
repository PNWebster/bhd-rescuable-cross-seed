using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace BRCS.Torznab
{
    internal class TorznabClient
    {
        string _endpoint;
        string _apiKey;

        public TorznabClient(string endpoint, string apiKey)
        {
            _endpoint = endpoint;
            _apiKey = apiKey;
        }

        internal async Task<List<PTPRelease>> FindByImdbIdAsync(string imdbId)
        {
            HttpClient c = new HttpClient();
            var response = await c.GetAsync($"{_endpoint}?apikey={_apiKey}&imdbid={imdbId}");
            var content = await response.Content.ReadAsStringAsync();

            return ParsePTPTorznab(content);
        }

        static List<PTPRelease> ParsePTPTorznab(string torznabXml)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(torznabXml);

            List<PTPRelease> result = new List<PTPRelease>();

            foreach (var item in xdoc.SelectNodes("//rss/channel/item").Cast<XmlElement>())
            {
                var res = new PTPRelease
                {
                    DownloadURL = item.GetElementsByTagName("guid")[0].InnerText,
                    GroupAndRelease = item.GetElementsByTagName("comments")[0].InnerText,
                    Size = long.Parse(item.GetElementsByTagName("size")[0].InnerText)
                };

                result.Add(res);
            }

            return result;
        }

    }
}
