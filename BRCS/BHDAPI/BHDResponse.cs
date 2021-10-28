namespace BRCS.BHDAPI
{
    internal class BHDResponse
    {
        public int status_code { get; set; } // The status code of the post request. (0 = Failed and 1 = Success)
        public int page { get; set; } // The current page of results that you're on.
        public int total_pages { get; set; } // int The total number of pages of results matching your query.
        public int total_results { get; set; } // The total number of results matching your query.
        public bool success { get; set; } // The status of the call. (True = Success, False = Error)
        public BHDResult[] results { get; set; } // The results that match your query.
    }
}
