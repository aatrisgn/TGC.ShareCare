using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace TGC.CareShare.WebAPI.Models.DataModels
{
    public class Expense : DTOBaseClass
    {
        public string Name { get; set; }
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
    }
}
