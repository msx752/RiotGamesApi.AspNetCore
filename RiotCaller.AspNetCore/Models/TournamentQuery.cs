using System;
using System.Collections.Generic;
using System.Text;
using RiotGamesApi.AspNetCore.Interfaces;

namespace RiotGamesApi.AspNetCore.Models
{
    public class TournamentQuery
    {
        private int _count;

        public int Count
        {
            get
            {
                if (_count == 0)
                    _count = 1;
                return _count;
            }
            set { _count = value; }
        }

        public int TournamentId { get; set; }
    }
}