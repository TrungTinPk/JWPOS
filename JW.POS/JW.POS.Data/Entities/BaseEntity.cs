using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JW.POS.Core.Entities
{
    public class BaseEntity
    {
        public long Id { get; set; }
    }

    public interface ICreatedEntity
    {
        public string CreatedId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }

    public interface IUpdatedEntity
    {
        public string UpdatedId { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
