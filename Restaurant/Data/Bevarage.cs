using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Primitives;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Data
{
    public class Bevarage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public string Type { get; set; }
        public string Description { get; set; }
       public string ImageUrl { get;set; }

        public int Litre { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }
        public int TypeBevarageId { get; set; }
        public TypeBevarage TypeBevarages { get; set; }


    }
}
