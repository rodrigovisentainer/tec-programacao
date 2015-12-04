using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Escola.Models
{
    
    public class Matricula
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MatriculaID { get; set; }    
        public int AlunoID { get; set; }
        public virtual Aluno Aluno { get; set; }

        public int MateriaLecionadaID { get; set; }

        public virtual MateriaLecionada MateriaLecionada { get; set; }
        public int Nota { get; set; }   
        


    }   

}
