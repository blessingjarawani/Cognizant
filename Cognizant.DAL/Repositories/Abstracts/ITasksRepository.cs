using Cognizant.DAL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.DAL.Repositories.Abstracts
{
    public interface ITasksRepository
    {
        Task<IEnumerable<TasksDTO>> GetAllTasks();
        Task<TasksDTO> GetTaskById(int id);
    }
}
