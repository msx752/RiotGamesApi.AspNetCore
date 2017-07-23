using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Rune;
using RiotGamesApi.Tests.Others;
using Xunit;

namespace RiotGamesApi.Tests.RiotGamesApis
{
    public class RUNES_V3 : BaseTestClass
    {
        [Fact]
        public void GetRunesBySummoner()
        {
            var rit = new ApiCall()
                .SelectApi<RunePagesDto>(LolApiName.Platform)
                .For(LolApiMethodName.Runes)
                .AddParameter(new ApiParameter(LolApiPath.BySummoner, SummonerId))
                .Build(Service_Platform)
                .Get();
            Assert.False(rit.HasError);
        }
    }
}