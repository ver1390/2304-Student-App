using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamMongoDB.Models.Repositories
{
    public interface IProgrammeRepository
    {
        IEnumerable<Programme> GetAllProgrammes();
        Programme GetProgrammeById(string id);
    }
}
