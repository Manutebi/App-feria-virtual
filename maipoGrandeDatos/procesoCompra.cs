using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maipoGrandeDatos
{
    public class procesoCompra
    {
        private int _id;
        private string _materia_prima;
        private string _foto;
        private string _fecha_inicio;
        private string _fecha_fin;
        private string _seleccion_transportista;
        private int _usuario_id;

        public int Id { get => _id; set => _id = value; }
        public string Materia_prima { get => _materia_prima; set => _materia_prima = value; }
        public string Foto { get => _foto; set => _foto = value; }
        public string Fecha_inicio { get => _fecha_inicio; set => _fecha_inicio = value; }
        public string Fecha_fin { get => _fecha_fin; set => _fecha_fin = value; }
        public string Seleccion_transportista { get => _seleccion_transportista; set => _seleccion_transportista = value; }
        public int Usuario_id { get => _usuario_id; set => _usuario_id = value; }

        public procesoCompra()
        {
        }
    }
}
