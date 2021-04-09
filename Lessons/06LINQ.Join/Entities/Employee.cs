//using System.Collections.Generic;

namespace LINQ.Join.Entities
{
    public record Employee : EntityBase
    {
        public int? DepartmentId { get; set; }
        // ДЛЯ EF
        //public IEnumerable<Department> Departments { get; set; }

        public int? BankId { get; set; }
        // ДЛЯ EF
        //public IEnumerable<Bank> Banks { get; set; }
    }
}
