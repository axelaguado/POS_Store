using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.CapaEntidad
{
    public class PersonaJuridica
    { 
        public int id_persona { get; set; }

        public string razon_social { get; set; }

        public string nombre_comercial { get; set; }

        public long cuit {  get; set; }

        //Propiedasdes de navegacion
        [ForeignKey("id_persona")]
        public Persona persona { get; set; } 
    }
}
