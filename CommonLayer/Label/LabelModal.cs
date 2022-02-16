using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Label
{
    public class LabelModal
    {
        [Required]
        public string LabelName { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
