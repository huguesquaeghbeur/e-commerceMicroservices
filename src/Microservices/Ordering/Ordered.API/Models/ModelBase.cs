﻿namespace Ordered.API.Models
{
    public class ModelBase
    {
        public int Id { get; protected set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }

        public DateTime LastModifiedOn { get; set; }
    }
}
