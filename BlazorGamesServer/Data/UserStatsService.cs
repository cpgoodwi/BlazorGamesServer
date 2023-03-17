namespace BlazorGamesServer.Data
{
    public class UserStatsService
    {
        public int Count { get; set; }

        public Task<int> GetCountAsync()
        {
            return Task.FromResult(Count);
        }

        public Task IncreaseCountAsync()
        {
            Count++;
            return Task.CompletedTask;
        }
    }
}
