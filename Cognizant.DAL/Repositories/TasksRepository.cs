using Cognizant.DAL.Contexts;
using Cognizant.DAL.Repositories.Abstracts;
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
    }
}
