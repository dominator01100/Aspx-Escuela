using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace AppEscuela
{
    public class Operaciones_BD
    {
        SqlConnection conexion;
        SqlCommand comando;
        DataTable dtEstudiantes;
        DataSet dsFacultades;
        SqlDataAdapter adaptador;

        public Operaciones_BD ()
        {
            conexion = new SqlConnection();
            conexion.ConnectionString = "Server=DESKTOP-EB7VJH2;Database=AppEscuela;User Id=sa;Password=qozaba42;";
        }

        public DataTable CargarEstudiantes()
        {
            comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "CargarEstudiantes";
            adaptador = new SqlDataAdapter();
            dtEstudiantes = new DataTable();
            conexion.Open();
            adaptador.SelectCommand = comando;
            adaptador.Fill(dtEstudiantes);
            conexion.Close();
            return dtEstudiantes;
        }

        public void AgregarEstudiante(string nombre, DateTime fecha, int semestre, int facultad)
        {
            comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "AgregarEstudiantes";
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@FechaNacimiento", fecha);
            comando.Parameters.AddWithValue("@Semestre", semestre);
            comando.Parameters.AddWithValue("@Facultad", facultad);
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public DataSet CargarFacultades()
        {
            comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "CargarFacultades";
            adaptador = new SqlDataAdapter();
            dsFacultades = new DataSet();
            conexion.Open();
            adaptador.SelectCommand = comando;
            adaptador.Fill(dsFacultades);
            conexion.Close();
            return dsFacultades;
        }

        public DataTable CargarEstudiante(int matricula)
        {
            comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "CargarEstudiante";
            comando.Parameters.AddWithValue("@Matricula", matricula);
            adaptador = new SqlDataAdapter();
            dtEstudiantes = new DataTable();
            conexion.Open();
            adaptador.SelectCommand = comando;
            adaptador.Fill(dtEstudiantes);
            conexion.Close();
            return dtEstudiantes;
        }

        public void ModificarEstudiante(int matricula, string nombre, DateTime fecha, int semestre, int facultad)
        {
            comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "ModificarEstudiante";
            comando.Parameters.AddWithValue("@Matricula", matricula);
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@FechaNacimiento", fecha);
            comando.Parameters.AddWithValue("@Semestre", semestre);
            comando.Parameters.AddWithValue("@Facultad", facultad);
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }

        public void EliminarEstudiante(int matricula)
        {
            comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "EliminarEstudiante";
            comando.Parameters.AddWithValue("@Matricula", matricula);
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}