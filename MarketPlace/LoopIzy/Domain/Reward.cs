using Newtonsoft.Json;
using System.Collections.Generic;

namespace LoopIzy.Domain
{
    public class RewardResponse
    {
        [JsonProperty("rewards")]
        public List<Reward> Rewards { get; set; }
    }

    public class Reward
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("points_cost")]
        public int PointsCost { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("available_in_roulette")]
        public bool AvailableInRoulette { get; set; }
    }
}
