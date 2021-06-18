namespace Cognizant.DAL.Dto
{
    public class GameStatsTopNDTO
    {
        public string PlayerName { get; set; }
        public int TotalTasksTaken { get; set; }
        public int TasksPassed { get; set; }
        public float Average { get; set; }
    }
}
