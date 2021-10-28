using System;

namespace BRCS.BHDAPI
{
    internal class BHDResult
    {
        public int id { get; set; }
        public string name { get; set; }
        public string folder_name { get; set; }
        public string info_hash { get; set; }
        public long size { get; set; }
        public string uploaded_by { get; set; }
        public string category { get; set; }
        public string type { get; set; }
        public int seeders { get; set; }
        public int leechers { get; set; }
        public int times_completed { get; set; }
        public string imdb_id { get; set; }
        public string tmdb_id { get; set; }
        public decimal bhd_rating { get; set; }
        public decimal tmdb_rating { get; set; }
        public decimal imdb_rating { get; set; }
        public int tv_pack { get; set; }
        public int promo25 { get; set; }
        public int promo50 { get; set; }
        public int promo75 { get; set; }
        public int freeleech { get; set; }
        public int rewind { get; set; }
        public int refund { get; set; }
        public int limited { get; set; }
        public int rescue { get; set; }
        public DateTime bumped_at { get; set; }
        public DateTime created_at { get; set; }
        public string url { get; set; }
        public string download_url { get; set; }
    }
}
