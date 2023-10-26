using E_CommerceAPI.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_CommerceAPI.Domain.Entities
{
    public class File:BaseEntity
    {
        public string FileName { get; set; }
        public string Path { get; set; }
        [NotMapped]
        public override DateTime UpdateDate { get => base.UpdateDate; set => base.UpdateDate = value; }
    }
}
