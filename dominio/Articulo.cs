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
        [DisplayName("C�digo")]
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        [DisplayName("Descripci�n")]
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }

        [DisplayName("Categor�a")]
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
            return this.Id == other.Id; // Comparar por el ID del art�culo
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode(); // Usar el hash code del ID del art�culo
        }
    }
}
