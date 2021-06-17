using Cognizant.DAL.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.DAL.Repositories.Abstracts
{
    public interface IProgrammingLanguagesRepository
    {
        Task<IEnumerable<ProgrammingLanguagesDTO>> GetAll();
    }
}
