using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entities
{
    public class Collab
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int CollabId { get; set; }

        public string collabEmail { get; set; }

        [ForeignKey("Note")]
        public int? NoteID { get; set; }
        [ForeignKey("User")]
        public int? userId { get; set; }
        public virtual Note Note { get; set; }
        public virtual User User { get; set; }
    }
}
