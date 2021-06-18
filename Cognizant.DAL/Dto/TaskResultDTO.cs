using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.DAL.Dto
{
    public class TaskResultDTO
    {
        public int TaskId { get; private set; }
        public string PlayerName { get; private set; }
        public bool IsSuccess { get; private set; }

        public TaskResultDTO(int taskId, string playerName, bool isSuccess)
        {
            TaskId = taskId;
            PlayerName = playerName;
            IsSuccess = isSuccess;
        }
    }
}
