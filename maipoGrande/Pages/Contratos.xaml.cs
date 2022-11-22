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
    /// Lógica de interacción para Contratos.xaml
    /// </summary>
    public partial class Contratos : Page
    {
        OracleConnection conn = null;

        public Contratos()
        {
            abrirConexion();
            InitializeComponent();
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

        private void cargarContrato()
        {
            try
            {
                OracleCommand comando = new OracleCommand("listar_contrato", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("registros", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable lista = new DataTable();
                adaptador.Fill(lista);

                listadoContrato.ItemsSource = lista.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Contrato en la lista");
            }
        }
        

        private void ListadoContrato_Loaded(object sender, RoutedEventArgs e)
        {
            cargarContrato();
        }


        private void AgreUpdateEventHandler(object sender, Addcontratos.UpdateEventArgs args)
        {
            cargarContrato();
        }
        private void ActuUpdateEventHandler(object sender, Updatecontratos.UpdateEventArgs args)
        {
            cargarContrato();
        }

        private void add_contratos(object sender, RoutedEventArgs e)
        {
            Addcontratos objaddcontratos = new Addcontratos(this);
            objaddcontratos.UpdateEventHandler += AgreUpdateEventHandler;
            objaddcontratos.Show();

        }

       

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Decimal id = (Decimal)((Button)sender).CommandParameter;
            //new Updateusuarios(Convert.ToInt32(id)).Show();
            Updatecontratos objupdusuarios = new Updatecontratos(Convert.ToInt32(id));
            objupdusuarios.UpdateEventHandler += ActuUpdateEventHandler;
            objupdusuarios.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Decimal id = (Decimal)((Button)sender).CommandParameter;
            try
            {
                OracleCommand comando = new OracleCommand("eliminar_contrato", conn);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("idp", OracleDbType.Int32).Value = id;
                comando.ExecuteNonQuery();
                MessageBox.Show("Usuario eliminado con exito");

                cargarContrato();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo ha salido mal al eliminar el usuario.");
            }
        }

        private void actualizar(object sender, RoutedEventArgs e)
        {
            cargarContrato();
        }
    }
}