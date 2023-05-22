using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Integrante
    {
        public int Id { get; set; }
        public int Legajo { get; set; }
        public string Nombre { get; set;}
        public string Apellido { get; set; }
        public string Avatar { get; set; }
        public bool Activo { get; set; }
        public override string ToString()
        {
            return Avatar;
        }
    }
}
