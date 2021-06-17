using Cognizant.DAL.Contexts;
using Cognizant.DAL.Dto;
using Cognizant.DAL.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.DAL.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private readonly ProgrammingTasksContext _dbContext;

        public TasksRepository(ProgrammingTasksContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TasksDTO>> GetAllTasks()
        {
            return await _dbContext.Tasks.Where(x => x.IsActive).OrderBy(x=>x.Name)
                  .Select(y => TasksDTO.CreateDTO(y)).ToListAsync();
        }
    }
}
