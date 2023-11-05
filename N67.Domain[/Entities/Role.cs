using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N67.Domain_.Entities
{
    public class Role
    {
        public Guid UserId { get; set; }
        public string Name { get; set; } = default!;
    }
}
