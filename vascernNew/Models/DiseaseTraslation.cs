using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace vascernNew.Models
{
    public class DiseaseTraslation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CultureId { get; set; }
        public Culture Culture { get; set; }
        public int DiseaseId { get; set; }
        public Disease Disease { get; set; }
    }
}
