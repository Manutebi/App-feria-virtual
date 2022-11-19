﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Data;
using maipoGrandeDatos;
using Microsoft.Win32;
using System.Windows.Navigation;

namespace maipoGrande.Pages
{
    /// <summary>
    /// Lógica de interacción para Solicitudes.xaml
    /// </summary>
    public partial class Solicitudes : Page
    {
        OracleConnection conn = null;
        int id_usuario;
        string nombre;
        string apellido;
        string email;
        string password;
        int run;
        int usuario_activo;
        int superuser;
        int ciudad;
        int rol;

        public Solicitudes(int id_usuario, string nombre, string apellido, string email, string password, int run, int usuario_activo, int superuser, int ciudad, int rol)
        {
            abrirConexion();
            InitializeComponent();
            this.id_usuario = id_usuario;
            this.nombre = nombre;
            this.apellido = apellido;
            this.email = email;
            this.password = password;
            this.run = run;
            this.usuario_activo = usuario_activo;
            this.superuser = superuser;
            this.ciudad = ciudad;
            this.rol = rol;

        }

        private void abrirConexion()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["oracleDB"].ConnectionString;
            conn = new OracleConnection(ConnectionString);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexion :O");
                throw new Exception("Error de conexion");
            }

        }

        private void add_ventas(object sender, RoutedEventArgs e)
        {
            Addventas objaddventas = new Addventas(id_usuario, nombre,  apellido,  email,  password,  run,  usuario_activo,  superuser,  ciudad,  rol);
            objaddventas.Show();
        }

        private void ListadoSolicitudCompra_Loaded(object sender, RoutedEventArgs e) 
        { 
        
            cargarSolicitudDG2();
        }

        private void cargarSolicitudDG2()
        {
            try
            {
                OracleCommand comando = new OracleCommand("LISTAR_SOLICITUD_COMPRA", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable lista = new DataTable();
                adaptador.Fill(lista);

                listadoSolicitudCompra.ItemsSource = lista.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer Solicitud");
            }
        }

        private void actualizar(object sender, RoutedEventArgs e)
        {
            cargarSolicitudDG2();
        }

        
    }
}