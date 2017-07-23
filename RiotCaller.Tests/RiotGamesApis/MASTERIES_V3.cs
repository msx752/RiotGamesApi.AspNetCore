using RiotGamesApi.AspNetCore.Enums;
using RiotGamesApi.AspNetCore.Models;
using RiotGamesApi.AspNetCore.RiotApi.NonStaticEndPoints.Mastery;
using RiotGamesApi.Tests.Others;
using Xunit;

namespace RiotGamesApi.Tests.RiotGamesApis
{
    public class MASTERIES_V3 : BaseTestClass
    {
        [Fact]
        public void GetMasteriesBySumId()
        {
            var rit = new ApiCall()
                .SelectApi<MasteryPagesDto>(LolApiName.Platform)
                .For(LolApiMethodName.Masteries)
                .AddParameter(new ApiParameter(LolApiPath.BySummoner, SummonerId))
                .Build(Service_Platform)
                .Get();
            Assert.False(rit.HasError);
        }
    }
}