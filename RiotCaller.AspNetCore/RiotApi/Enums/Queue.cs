namespace RiotGamesApi.AspNetCore.RiotApi.Enums
{
    /// <summary>
    /// for matchlist and league queries 
    /// </summary>
    public enum Queue
    {
        /// <summary>
        /// use only matchlist query 
        /// </summary>
        TEAM_BUILDER_DRAFT_RANKED_5x5,

        RANKED_SOLO_5x5,

        RANKED_TEAM_5x5,

        /// <summary>
        /// use only matchlist query 
        /// </summary>
        TEAM_BUILDER_DRAFT_UNRANKED_5x5,

        RANKED_TEAM_3x3,

        RANKED_FLEX_SR,

        RANKED_FLEX_TT,
    }
}