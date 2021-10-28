# bhd-rescuable-cross-seed
Finding rescuable crossseedable torrents on BHD

Uses the BHD API and a Jackett endpoint (only tested with PTP) to find rescuables movies on BHD that can be cross-seeded on PTP

Example usage:
BRCS.CLI.EXE -t http://localhost:9117/api/v2.0/indexers/yoursite/results/torznab/ -j jacketapikey -b beyondhdapikey -r beyondhdrsskey -a 10


Example output:
Match found!
        https://beyond-hd.me/torrents/amazingmovie1
        https://passthepopcorn.me/torrents.php?id=movie1
Match found!
        https://beyond-hd.me/torrents/amazingmovie2
        https://passthepopcorn.me/torrents.php?id=movie2
