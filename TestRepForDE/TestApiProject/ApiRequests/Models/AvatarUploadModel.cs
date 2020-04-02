using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApiProject.ApiRequests.Models
{

    public class AvatarUploadModel
    {
        [JsonProperty("image")]
        public Image Image { get; set; }
    }
        public class Image
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("large")]
            public Url Large { get; set; }

            [JsonProperty("small")]
            public Url Small { get; set; }

            [JsonProperty("medium")]
            public Url Medium { get; set; }

            [JsonProperty("thumbnail")]
            public Url Thumbnail { get; set; }

            [JsonProperty("original")]
            public Url Original { get; set; }

            
        }
    public class Url
    {
        [JsonProperty("url")]
        public string url { get; set; }
    }


}
