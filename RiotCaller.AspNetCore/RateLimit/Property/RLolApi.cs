using RiotGamesApi.AspNetCore.Enums;
using System.Collections.Generic;
using System.Linq;

namespace RiotGamesApi.AspNetCore.RateLimit.Property
{
    public class RLolApiName
    {
        private object _lock = new object();
        private List<RLolApiMethodName> _names;
        private LolApiName _name;

        public RLolApiName(RLolApiMethodName rlan) : this()
        {
            Add(rlan);
        }

        public RLolApiName()
        {
            Names = new List<RLolApiMethodName>();
        }

        public LolApiName Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public List<RLolApiMethodName> Names
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

        public void Add(LolApiName name, RLolApiMethodName val)
        {
            Names.Add(val);
        }

        public void Add(RLolApiMethodName val)
        {
            Names.Add(val);
        }

        public RLolApiMethodName Find(LolApiName name, LolApiMethodName? method = null)
        {
            return Enumerable.FirstOrDefault<RLolApiMethodName>(Names, p => p.ContainsApiName(name, method));
        }
    }
}