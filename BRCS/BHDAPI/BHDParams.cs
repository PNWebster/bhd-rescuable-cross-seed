namespace BRCS.BHDAPI
{
    internal class BHDParams
    {
        internal const string action = "action"; // string - The torrents endpoint action you wish to perform. (search)
        internal const string rsskey = "rsskey"; // string - Your personal RSS key (RID) if you wish for results to include the uploaded_by and download_url fields
        internal const string page = "page"; // int - The page number of the results. Only if the result set has more than 100 total matches.

        internal const string search = "search"; // string - The torrent name. It does support !negative searching. Example: Christmas Movie
        internal const string info_hash = "info_hash"; // string - The torrent info_hash. This is an exact match.
        internal const string folder_name = "folder_name"; // string - The torrent folder name. This is an exact match.file_name string The torrent included file names. This is an exact match.
        internal const string size = "size"; // int - The torrent size. This is an exact match.
        internal const string uploaded_by = "uploaded_by"; // string - The uploaders username. Only non anonymous results will be returned.
        internal const string imdb_id = "imdb_id"; // int - The ID of the matching IMDB page.
        internal const string tmdb_id = "tmdb_id"; // int - The ID of the matching TMDB page.
        internal const string categories = "categories"; // string - Any categories separated by comma(s). TV, Movies)
        internal const string types = "types"; // string - Any types separated by comma(s). BD Remux, 1080p, etc.)
        internal const string sources = "sources"; // string - Any sources separated by comma(s). Blu-ray, WEB, DVD, etc.)
        internal const string genres = "genres"; // string - Any genres separated by comma(s). Action, Anime, StandUp, Western, etc.)
        internal const string groups = "groups"; // string - Any internal release groups separated by comma(s).FraMeSToR, BHDStudio, BeyondHD, RPG, iROBOT, iFT, ZR, MKVULTRA
        internal const string freeleech = "freeleech"; // int - The torrent freeleech status. 1 = Must match.
        internal const string limited = "limited"; // int - The torrent limited UL promo. 1 = Must match.
        internal const string promo25 = "promo25"; // int - The torrent 25% promo. 1 = Must match.
        internal const string promo50 = "promo50"; // int - The torrent 50% promo. 1 = Must match.
        internal const string promo75 = "promo75"; // int - The torrent 75% promo. 1 = Must match.
        internal const string refund = "refund"; // int - The torrent refund promo. 1 = Must match.
        internal const string rescue = "rescue"; // int - The torrent rescue promo. 1 = Must match.
        internal const string rewind = "rewind"; // int - The torrent rewind promo. 1 = Must match.
        internal const string stream = "stream"; // int - The torrent Stream Optimized flag. 1 = Must match.
        internal const string sd = "sd"; // int - The torrent SD flag. 1 = Must match.
        internal const string pack = "pack"; // int - The torrent TV pack flag. 1 = Must match.
        internal const string h264 = "h264"; // int - The torrent x264/h264 codec flag. 1 = Must match.
        internal const string h265 = "h265"; // int - The torrent x265/h265 codec flag. 1 = Must match.
        internal const string alive = "alive"; // int - The torrent has at least 1 seeder. 1 = Must match.
        internal const string dying = "dying"; // int - The torrent has less than 3 seeders. 1 = Must match.
        internal const string dead = "dead"; // int - The torrent has no seeders. 1 = Must match.
        internal const string reseed = "reseed"; // int - The torrent has no seeders and an active reseed request. 1 = Must match.
        internal const string seeding = "seeding"; // int - The torrent is seeded by you. 1 = Must match.
        internal const string leeching = "leeching"; // int - The torrent is being leeched by you. 1 = Must match.
        internal const string completed = "completed"; // int - The torrent has been completed by you. 1 = Must match.
        internal const string incomplete = "incomplete"; // int - The torrent has not been completed by you. 1 = Must match.
        internal const string notdownloaded = "notdownloaded"; // int - The torrent has not been downloaded you. 1 = Must match.
        internal const string min_bhd = "min_bhd"; // int - The minimum BHD rating.
        internal const string vote_bhd = "vote_bhd"; // int - The minimum number of BHD votes.
        internal const string min_imdb = "min_imdb"; // int - The minimum IMDb rating.
        internal const string vote_imdb = "vote_imdb"; // int - The minimum number of IMDb votes.
        internal const string min_tmdb = "min_tmdb"; // int - The minimum TMDb rating.
        internal const string vote_tmdb = "vote_tmdb"; // int - The minimum number of TDMb votes.
        internal const string min_year = "min_year"; // int - The earliest release year.
        internal const string max_year = "max_year"; // int - The latest release year.
        internal const string sort = "sort"; // string - Field to sort results by. (bumped_at, created_at, seeders, leechers, times_completed, size, name, imdb_rating, tmdb_rating, bhd_rating). Default is bumped_at
        internal const string order = "order"; // string - The direction of the sort of results. (asc, desc). Default is desc

        // Most of the comma separated fields are OR searches.
        internal const string features = "features"; // string - Any features separated by comma(s). DV, HDR10, HDR10P, Commentary)
        internal const string countries = "countries"; // string - Any production countries separated by comma(s). France, Japan, etc.)
        internal const string languages = "languages"; // string - Any spoken languages separated by comma(s). French, English, etc.)
        internal const string audios = "audios"; // string - Any audio tracks separated by comma(s). English, Japanese,etc.)
        internal const string subtitles = "subtitles"; // string - Any subtitles separated by comma(s). Dutch, Finnish, Swedish, etc.)

    }
}
