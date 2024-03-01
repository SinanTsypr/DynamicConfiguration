using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecilStore.ApplicationCore.Entities
{
    public class Configuration : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Value { get; set; } = null!;
        public bool IsActive { get; set; }
        public string ApplicationName { get; set; } = null!;
    }
}
