using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DAL.Entities
{
    public class Logging
    {
        public int Id { get; set; }
        public int ActionBy { get; set; } = 1;
        public int EntityId { get; set; }
        public int ActionTypeId { get; set; }
        public int? AffectedRowId { get; set; }
        public string Action { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Default value in the entity
    }

}
