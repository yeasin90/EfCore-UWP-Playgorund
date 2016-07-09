using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGenericRepository
{
    public interface ISectionRepository : IRepository<Section>
    {

    }

    public class SectionRepository : Repository<Section>, ISectionRepository
    {

    }

    public interface IStudentRepository
    {

    }

    public class StudentRepository : Repository<Student>, IStudentRepository
    {

    }
}
