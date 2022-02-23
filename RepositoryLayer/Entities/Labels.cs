using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entities
{

    public class Labels
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LabelID { get; set; }
        public string LabelName { get; set; }
        [ForeignKey("Note")]
        public int? NoteID { get; set; }
        [ForeignKey("User")]
        public int? userId { get; set; }
        public virtual User Users { get; set; }
        public virtual Note notes { get; set; }
        
    }
}
