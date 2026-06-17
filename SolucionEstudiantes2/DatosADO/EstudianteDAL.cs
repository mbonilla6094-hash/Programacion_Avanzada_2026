using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace DatosADO
{
    public class EstudianteDAL
    {
        // ══════════════════════════════════════════════
        //                  CREATE
        // ══════════════════════════════════════════════
        public static bool Insertar(Estudiante e)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(
                    DatosADO.Properties.Settings.Default.ConexionBDD);
                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection  = conexion;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"INSERT INTO Estudiantes
                                        (Cedula, Nombres, Apellidos, Email, Carrera)
                                    VALUES
                                        (@Cedula, @Nombres, @Apellidos, @Email, @Carrera)";

                cmd.Parameters.Add("@Cedula",    SqlDbType.VarChar, 10 ).Value = e.Cedula;
                cmd.Parameters.Add("@Nombres",   SqlDbType.VarChar, 100).Value = e.Nombres;
                cmd.Parameters.Add("@Apellidos", SqlDbType.VarChar, 100).Value = e.Apellidos;
                cmd.Parameters.Add("@Email",     SqlDbType.VarChar, 150).Value = e.Email;
                cmd.Parameters.Add("@Carrera",   SqlDbType.VarChar, 100).Value = e.Carrera;

                SqlTransaction tx = conexion.BeginTransaction();
                cmd.Transaction = tx;

                try
                {
                    int filas = cmd.ExecuteNonQuery();
                    tx.Commit();
                    conexion.Close();
                    return filas > 0;
                }
                catch
                {
                    tx.Rollback();
                    conexion.Close();
                    throw;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // ══════════════════════════════════════════════
        //              READ — Todos
        // ══════════════════════════════════════════════
        public static List<Estudiante> ObtenerTodos()
        {
            try
            {
                List<Estudiante> lista = new List<Estudiante>();

                SqlConnection conexion = new SqlConnection(
                    DatosADO.Properties.Settings.Default.ConexionBDD);
                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection  = conexion;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT [Id],[Cedula],[Nombres],[Apellidos],
                                           [Email],[Carrera],[FechaRegistro]
                                    FROM   [dbo].[Estudiantes]
                                    ORDER BY Apellidos, Nombres";

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Estudiante est    = new Estudiante();
                        est.Id            = Convert.ToInt32(dr["Id"].ToString());
                        est.Cedula        = dr["Cedula"].ToString();
                        est.Nombres       = dr["Nombres"].ToString();
                        est.Apellidos     = dr["Apellidos"].ToString();
                        est.Email         = dr["Email"].ToString();
                        est.Carrera       = dr["Carrera"].ToString();
                        est.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                        lista.Add(est);
                    }
                }

                conexion.Close();
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // ══════════════════════════════════════════════
        //              READ — Por ID
        // ══════════════════════════════════════════════
        public static Estudiante ObtenerPorId(int id)
        {
            try
            {
                Estudiante est = null;

                SqlConnection conexion = new SqlConnection(
                    DatosADO.Properties.Settings.Default.ConexionBDD);
                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection  = conexion;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT [Id],[Cedula],[Nombres],[Apellidos],
                                           [Email],[Carrera],[FechaRegistro]
                                    FROM   [dbo].[Estudiantes]
                                    WHERE  Id = @Id";

                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        est               = new Estudiante();
                        est.Id            = Convert.ToInt32(dr["Id"].ToString());
                        est.Cedula        = dr["Cedula"].ToString();
                        est.Nombres       = dr["Nombres"].ToString();
                        est.Apellidos     = dr["Apellidos"].ToString();
                        est.Email         = dr["Email"].ToString();
                        est.Carrera       = dr["Carrera"].ToString();
                        est.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                    }
                }

                conexion.Close();
                return est;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // ══════════════════════════════════════════════
        //              READ — Buscar
        // ══════════════════════════════════════════════
        public static List<Estudiante> Buscar(string termino)
        {
            try
            {
                List<Estudiante> lista = new List<Estudiante>();

                SqlConnection conexion = new SqlConnection(
                    DatosADO.Properties.Settings.Default.ConexionBDD);
                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection  = conexion;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT [Id],[Cedula],[Nombres],[Apellidos],
                                           [Email],[Carrera],[FechaRegistro]
                                    FROM   [dbo].[Estudiantes]
                                    WHERE  Nombres   LIKE @T
                                        OR Apellidos LIKE @T
                                        OR Cedula    LIKE @T
                                    ORDER BY Apellidos, Nombres";

                cmd.Parameters.Add("@T", SqlDbType.VarChar, 110).Value = "%" + termino + "%";

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Estudiante est = new Estudiante();
                        est.Id        = Convert.ToInt32(dr["Id"].ToString());
                        est.Cedula    = dr["Cedula"].ToString();
                        est.Nombres   = dr["Nombres"].ToString();
                        est.Apellidos = dr["Apellidos"].ToString();
                        est.Email     = dr["Email"].ToString();
                        est.Carrera   = dr["Carrera"].ToString();
                        lista.Add(est);
                    }
                }

                conexion.Close();
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // ══════════════════════════════════════════════
        //                  UPDATE
        // ══════════════════════════════════════════════
        public static bool Actualizar(Estudiante e)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(
                    DatosADO.Properties.Settings.Default.ConexionBDD);
                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection  = conexion;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"UPDATE [dbo].[Estudiantes]
                                    SET    Cedula    = @Cedula,
                                           Nombres   = @Nombres,
                                           Apellidos = @Apellidos,
                                           Email     = @Email,
                                           Carrera   = @Carrera
                                    WHERE  Id = @Id";

                cmd.Parameters.Add("@Id",        SqlDbType.Int        ).Value = e.Id;
                cmd.Parameters.Add("@Cedula",    SqlDbType.VarChar, 10 ).Value = e.Cedula;
                cmd.Parameters.Add("@Nombres",   SqlDbType.VarChar, 100).Value = e.Nombres;
                cmd.Parameters.Add("@Apellidos", SqlDbType.VarChar, 100).Value = e.Apellidos;
                cmd.Parameters.Add("@Email",     SqlDbType.VarChar, 150).Value = e.Email;
                cmd.Parameters.Add("@Carrera",   SqlDbType.VarChar, 100).Value = e.Carrera;

                SqlTransaction tx = conexion.BeginTransaction();
                cmd.Transaction = tx;

                try
                {
                    int filas = cmd.ExecuteNonQuery();
                    tx.Commit();
                    conexion.Close();
                    return filas > 0;
                }
                catch
                {
                    tx.Rollback();
                    conexion.Close();
                    throw;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // ══════════════════════════════════════════════
        //                  DELETE
        // ══════════════════════════════════════════════
        public static bool Eliminar(int id)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(
                    DatosADO.Properties.Settings.Default.ConexionBDD);
                conexion.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection  = conexion;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"DELETE FROM [dbo].[Estudiantes]
                                    WHERE Id = @Id";

                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                SqlTransaction tx = conexion.BeginTransaction();
                cmd.Transaction = tx;

                try
                {
                    int filas = cmd.ExecuteNonQuery();
                    tx.Commit();
                    conexion.Close();
                    return filas > 0;
                }
                catch
                {
                    tx.Rollback();
                    conexion.Close();
                    throw;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
