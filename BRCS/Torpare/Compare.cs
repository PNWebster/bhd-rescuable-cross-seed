using BencodeNET.Parsing;
using BencodeNET.Torrents;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BRCS.Torpare
{
    // Compare torrents
    public static class Compare
    {
        public static async Task<bool> AreSameAsync(string url1, string url2)
        {
            HttpClient client = new HttpClient();

            var response1 = await client.GetAsync(url1);
            var data1 = await response1.Content.ReadAsByteArrayAsync();

            var response2 = await client.GetAsync(url2);
            var data2 = await response2.Content.ReadAsByteArrayAsync();

            return AreSame(data1, data2);
        }

        public static bool AreSame(byte[] torA, byte[] torB)
        {
            var parser = new BencodeParser();
            Torrent torrentA = parser.Parse<Torrent>(torA);
            Torrent torrentB = parser.Parse<Torrent>(torB);

            if ((torrentA.File == null) != (torrentB.File == null))
                return false;

            if (torrentA.File != null && torrentB.File != null)
                return torrentA.File.FileName == torrentB.File.FileName &&
                torrentA.File.FileSize == torrentB.File.FileSize;

            Dictionary<string, long> filesA = torrentA.Files.ToDictionary(mfi => mfi.FullPath, mfi => mfi.FileSize);
            Dictionary<string, long> filesB = torrentB.Files.ToDictionary(mfi => mfi.FullPath, mfi => mfi.FileSize);

            List<string> uniqueInA = new List<string>();
            foreach (var item in filesA)
            {
                if (filesB.TryGetValue(item.Key, out long length))
                {
                    if (item.Value != length)
                        return false;
                }
                else
                {
                    uniqueInA.Add(item.Key);
                }
            }

            var uniqueInB = filesB.Keys.Except(filesA.Keys);
            if (uniqueInA.Any())
                return false;
            if (uniqueInB.Any())
                return false;

            return true;
        }
    }
}
