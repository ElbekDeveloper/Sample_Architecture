using Shared;
using Shared.Interfaces;
using System;

namespace ApplicationCore.Entities
{
    //As the application is using mongodb, the id field has guid datatype
    public class Vendor : BaseEntity<Guid>, IAggregateRoot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
        public bool IsActive { get; set; }
    }
}
