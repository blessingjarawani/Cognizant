using Cognizant.DAL.Contexts;
using Cognizant.DAL.Dto;
using Cognizant.DAL.Repositories.Abstracts;
using Cognizant.DAL.Tables;
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
    }
}
