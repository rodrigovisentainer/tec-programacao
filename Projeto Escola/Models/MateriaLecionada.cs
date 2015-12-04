using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Escola.Models
{
    public class MateriaLecionada
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MateriaLecionadaID { get; set; }
       
        public int Ano { get; set; }

        public int Semestre { get; set; }
        public String MateriaID { get; set; }

        public virtual Materia Materia { get; set; }
 
        public int ProfessorID { get; set; }

        public virtual Professor Professor { get; set; }
        
    }
}