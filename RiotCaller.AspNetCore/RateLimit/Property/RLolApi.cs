using RiotGamesApi.AspNetCore.Enums;
using System.Collections.Generic;
using System.Linq;

namespace RiotGamesApi.AspNetCore.RateLimit.Property
{
    public class RLolApi
    {
        private object _lock = new object();
        private List<RLolApiName> _names;

        public RLolApi(RLolApiName rlan) : this()
        {
            Add(rlan);
        }

        public RLolApi()
        {
            Names = new List<RLolApiName>();
        }

        public List<RLolApiName> Names
        {
            get
            {
                lock (_lock)
                    return _names;
            }
            set
            {
                lock (_lock)
                    _names = value;
            }
        }

        public void Add(RLolApiName val)
        {
            Names.Add(val);
        }

        public RLolApiName Find(LolApiName name)
        {
            return Enumerable.FirstOrDefault<RLolApiName>(Names, p => p.ContainsApiName(name));
        }
    }
}