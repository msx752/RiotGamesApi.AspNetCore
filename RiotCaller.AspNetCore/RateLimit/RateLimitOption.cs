using System;
using System.Collections.Generic;
using System.Text;

namespace RiotGamesApi.AspNetCore.RateLimit
{
    public interface IRateLimitAdd
    {
        IRateLimitCount AddEvery();
    }

    public interface IRateLimitCount
    {
        IRateLimitTime One();

        IRateLimitTime Two();

        IRateLimitTime Three();

        IRateLimitTime Four();

        IRateLimitTime Five();
    }

    public interface IRateLimitTime
    {
        void Seconds(int limit);

        void Minutes(int limit);

        void Hours(int limit);
    }

    public class RateLimitOption : IRateLimitAdd, IRateLimitTime, IRateLimitCount
    {
        public Dictionary<TimeSpan, int> Limits { get; set; } = new Dictionary<TimeSpan, int>();
        private int Times = 0;

        public IRateLimitCount AddEvery()
        {
            Times = 0;
            return this;
        }

        public void Seconds(int limit)
        {
            Limits[new TimeSpan(0, 0, Times)] = limit;
        }

        public void Minutes(int limit)
        {
            Limits[new TimeSpan(0, Times, 0)] = limit;
        }

        public void Hours(int limit)
        {
            Limits[new TimeSpan(Times, 0, 0)] = limit;
        }

        public IRateLimitTime One()
        {
            Times = 1;
            return this;
        }

        public IRateLimitTime Two()
        {
            Times = 2;
            return this;
        }

        public IRateLimitTime Three()
        {
            Times = 3;
            return this;
        }

        public IRateLimitTime Four()
        {
            Times = 4;
            return this;
        }

        public IRateLimitTime Five()
        {
            Times = 5;
            return this;
        }
    }
}