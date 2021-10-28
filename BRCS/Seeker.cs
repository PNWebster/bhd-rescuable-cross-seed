using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BRCS
{
    public class Seeker
    {
        private readonly string _jackettUrl;
        private readonly string _jacketApiKey;
        private readonly string _bhdApiKey;
        private readonly string _bhdRssKey;

        public Seeker(string jackettUrl, string jacketApiKey, string bhdApiKey, string bhdRssKey)
        {
           _jackettUrl = jackettUrl;
           _jacketApiKey = jacketApiKey;
           _bhdApiKey = bhdApiKey;
           _bhdRssKey = bhdRssKey;
        }

        public async Task<List<CrossSeedableRescuable>> SearchAsync(int amount = 10)
        {
            List<CrossSeedableRescuable> result = new List<CrossSeedableRescuable>();

            var bhdClient = new BHDAPI.BHDAPIClient(_bhdApiKey, _bhdRssKey);
            var jackettClient = new Torznab.TorznabClient(_jackettUrl, _jacketApiKey);
            var httpClient = new HttpClient();

            var page = 1;

            while (result.Count < amount)
            {
                var responses = await bhdClient.FindRescueableMoviesAsync(page);
                if (responses.results.Length == 0)
                    break;

                page++;
                var movies = responses.results.GroupBy(tor => tor.imdb_id);

                foreach (var movie in movies)
                {
                    var ptpReleases = await jackettClient.FindByImdbIdAsync(movie.Key);

                    foreach (var format in movie)
                    {
                        var match = ptpReleases.FirstOrDefault(rel => rel.Size == format.size);
                        if (match != null)
                        {
                            bool probablySame = await Torpare.Compare.AreSameAsync(match.DownloadURL, format.download_url);

                            if (probablySame)
                            {
                                result.Add(new CrossSeedableRescuable
                                {
                                    BHDDetails = format.url,
                                    BHDDownloadUrl = format.download_url,
                                    PTPDetails = match.GroupAndRelease,
                                    PTPDownloadUrl = match.DownloadURL
                                });

                                if (result.Count == amount)
                                    return result;
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}
