using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class BaseClass
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public DateTime CreatedTime { get; set; } = DateTime.Now;
    }
}
