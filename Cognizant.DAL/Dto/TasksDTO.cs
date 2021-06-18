using Cognizant.DAL.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.DAL.Dto
{
    public class TasksDTO
    {
        public int Id { get; private set; }
        public string Description { get; private set; }
        public string InputParameter { get; private set; }
        public string ExpectedOutput { get; private set; }
        public string Name { get; private set; }

        public static TasksDTO CreateDTO(Tasks task)
        {
            if (task != null)
                return new TasksDTO
                {
                    Description = task.Description,
                    ExpectedOutput = task.ExpectedOutPut,
                    InputParameter = task.InputParameter,
                    Id = task.Id,
                    Name = task.Name
                };
            return null;
        }
    }
}
