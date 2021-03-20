using System;
using System.ComponentModel.DataAnnotations;

namespace YapilacaklarWebApi.Records.Bases
{
    public abstract class RecordBase
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? UpdateDate { get; set; }
        [StringLength(50)]
        public string UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}