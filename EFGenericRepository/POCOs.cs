using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGenericRepository
{
    public class Section : Entity
    {
        public string SectionName { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }

    public class Student : Entity
    {
        public string Name { get; set; }
        public virtual Section Section { get; set; }
    }

    public interface IEntity
    {
        int Id { get; set; }
    }

    public class Entity : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
