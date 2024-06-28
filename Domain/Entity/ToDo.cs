using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    [Table("Notes")]
    public class ToDo
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Note")]
        public string? Note { get; set; }

        [Column("Concluded")]
        public bool? Concluded { get; set; }
    }
}
