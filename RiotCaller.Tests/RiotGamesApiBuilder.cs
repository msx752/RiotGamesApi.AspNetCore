using Newtonsoft.Json;
using RiotGamesApi.AspNetCore;
using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace RiotGamesApi.Tests
{
    public class RiotGamesApiBuilder : BaseTestClass
    {
        [Fact]
        public void ApiToStaticClass()
        {
            //RiotGamesApi.AspNetCore.Api auto cs generetor
            //after api developing use this method and change Api.cs with output
            string output = ApiSettings.GenerateApiClass();
        }
    }
}