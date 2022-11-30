 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maipoGrandeDatos
{
    public class Usuario
    {
        private int _id_usuario;
        private string _nombre;
        private string _apellido;
        private string _email;
        private string _password;
        private int _run;
        private int _usuario_activo;
        private int _superuser;
        private int _ciudad_id_ciudad;
        private int _rol_id_rol;

        public int Id_usuario { get => _id_usuario; set => _id_usuario = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Email { get => _email; set => _email = value; }
        public string Password { get => _password; set => _password = value; }
        public int Run { get => _run; set => _run = value; }
        public int Usuario_activo { get => _usuario_activo; set => _usuario_activo = value; }
        public int Superuser { get => _superuser; set => _superuser = value; }
        public int Ciudad_id_ciudad { get => _ciudad_id_ciudad; set => _ciudad_id_ciudad = value; }
        public int Rol_id_rol { get => _rol_id_rol; set => _rol_id_rol = value; }
    }
    public class Rol
    {
        private int _id_rol;
        private string _n_rol;

        public int Id_rol { get => _id_rol; set => _id_rol = value; }
        public string N_rol { get => _n_rol; set => _n_rol = value; }
    }
 
}
