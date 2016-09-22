using System;
using System.ComponentModel.DataAnnotations;

namespace CRMApi.Domain
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTimeOffset DtCreation { get; } = DateTime.Now;

        [DataType(DataType.DateTime)]
        public DateTimeOffset DtLastUpdate { get; set; }
    }
}