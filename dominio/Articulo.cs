using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace dominio
{
    public class Articulo
    {
        public int Id { get; set; }
        [DisplayName("Código")]
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }

        [DisplayName("Categoría")]
        public Categoria Categoria { get; set; }
        public Imagen Imagen { get; set; }
        public decimal Precio { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Articulo other = (Articulo)obj;
            return this.Id == other.Id; // Comparar por el ID del artículo
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode(); // Usar el hash code del ID del artículo
        }
    }
}
