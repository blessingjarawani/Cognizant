using Cognizant.DAL.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cognizant.DAL.Dto
{
    public class ProgrammingLanguagesDTO
    {
        public string Name { get; private set; }
        public string KeyCode { get; private set; }
        public String BaseSolutionCode { get; private set; }

        public static ProgrammingLanguagesDTO CreateDTO(ProgrammingLanguages programmingLanguage)
        {
            if (programmingLanguage != null)
                return new ProgrammingLanguagesDTO
                {
                    BaseSolutionCode = programmingLanguage.BaseSolutionCode,
                    KeyCode = programmingLanguage.KeyCode,
                    Name = programmingLanguage.Name
                };
            return new ProgrammingLanguagesDTO { };

        }
    }
}
