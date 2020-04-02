using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApiProject.ApiRequests.Models
{
    public class AvatarSetModel
    {
        [JsonProperty("avatar_id")]
        public string AvatarId { get; set; }
    }
}
