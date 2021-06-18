using Cognizant.DAL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.DAL.Repositories.Abstracts
{
    public interface IGameStatsRepository
    {
        Task<bool> SaveChanges(TaskResultDTO taskResult);
        Task<IEnumerable<GameStatsTopNDTO>> GetTopN(int TopN);
    }
}
