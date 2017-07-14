using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using RiotGamesApi.AspNetCore;
using RiotGamesApi.AspNetCore.Enums;
using Xunit;
using RiotGamesApi.AspNetCore.Extensions;

namespace RiotGamesApi.Tests
{
    public class RiotGamesApiBuilderJson : BaseTestClass
    {
        [Fact]
        public void RiotGamesApiToJson()
        {
            //RiotGamesApi.AspNetCore.Api auto cs generetor
            //after api developing use this method and change Api.cs with output
            string output = RiotGamesApiSettings.GenerateApiClass();
        }
    }
}