using Cognizant.DAL.Contexts;
using Cognizant.DAL.Dto;
using Cognizant.DAL.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cognizant.DAL.Repositories
{
    public class ProgrammingLanguagesRepository : IProgrammingLanguagesRepository
    {
        private readonly ProgrammingTasksContext _dbContext;

        public ProgrammingLanguagesRepository(ProgrammingTasksContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ProgrammingLanguagesDTO>> GetAll()
        {
            return await _dbContext.ProgrammingLanguages.Where(x => x.IsActive)
                    .OrderBy(x => x.Name)
                    .Select(y => ProgrammingLanguagesDTO.CreateDTO(y)).ToListAsync();
        }
    }
}
