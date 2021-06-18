using Cognizant.DAL.Contexts;
using Cognizant.DAL.Dto;
using Cognizant.DAL.Repositories.Abstracts;
using Cognizant.DAL.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.DAL.Repositories
{
    public class GameStatsRepository : IGameStatsRepository
    {
        private readonly ProgrammingTasksContext _dbContext;

        public GameStatsRepository(ProgrammingTasksContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> SaveChanges(TaskResultDTO taskResult)
        {
            var entity = new GameStats
            {
                TaskId = taskResult.TaskId,
                IsSuccess = taskResult.IsSuccess,
                PlayerName = taskResult.PlayerName
            };
            await _dbContext.GameStats.AddAsync(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<GameStatsTopNDTO>> GetTopN(int TopN)
        => await _dbContext.GameStats
                  .GroupBy(x => x.PlayerName)
                  .Select(g => new
                  {
                      PlayerName = g.Key,
                      TotalTasksTaken = g.Count(x => x.IsActive),
                      TasksPassed = g.Count(x => x.IsActive && x.IsSuccess),

                  }).Select(t => new GameStatsTopNDTO
                  {
                      PlayerName = t.PlayerName,
                      TotalTasksTaken = t.TotalTasksTaken,
                      TasksPassed = t.TasksPassed,
                      Average = ((float)t.TasksPassed / (float)t.TotalTasksTaken) * 100
                  }).Where(z => z.Average > 0).OrderByDescending(t => t.Average).Take(TopN).ToListAsync();
        public async Task<string> GetTaskLastSuccessDate(string player, int taskId)
           => (await _dbContext.GameStats
            .FirstOrDefaultAsync(x => x.TaskId == taskId && x.PlayerName == player && x.IsActive && x.IsSuccess))
            ?.CreatedDate.ToString("dd-MM-yyyy") ?? "";



    }
}
