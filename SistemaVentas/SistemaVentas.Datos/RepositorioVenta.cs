using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SistemaVentas.Entidades;

namespace SistemaVentas.Datos
{
    // Repositorio de ventas: todas las operaciones CRUD con ADO.NET y SQL puro
    public class RepositorioVenta
    {
        // Inserta una venta en la base de datos
        public int Insertar(Venta venta)
        {
            using (var conexion = ConexionBD.ObtenerConexion())
            {
                string sql = @"
                    INSERT INTO Ventas (Region, Pais, TipoProducto, CanalVenta, Prioridad,
                        FechaOrden, OrdenId, FechaEnvio, UnidadesVendidas, PrecioUnitario,
                        CostoUnitario, IngresoTotal, CostoTotal, GananciaTotal)
                    VALUES (@Region, @Pais, @TipoProducto, @CanalVenta, @Prioridad,
                        @FechaOrden, @OrdenId, @FechaEnvio, @UnidadesVendidas, @PrecioUnitario,
                        @CostoUnitario, @IngresoTotal, @CostoTotal, @GananciaTotal);
                    SELECT SCOPE_IDENTITY();";

                using (var cmd = new SqlCommand(sql, conexion))
                {
                    cmd.Parameters.AddWithValue("@Region", venta.Region);
                    cmd.Parameters.AddWithValue("@Pais", venta.Pais);
                    cmd.Parameters.AddWithValue("@TipoProducto", venta.TipoProducto);
                    cmd.Parameters.AddWithValue("@CanalVenta", venta.CanalVenta);
                    cmd.Parameters.AddWithValue("@Prioridad", venta.Prioridad);
                    cmd.Parameters.AddWithValue("@FechaOrden", venta.FechaOrden);
                    cmd.Parameters.AddWithValue("@OrdenId", venta.OrdenId);
                    cmd.Parameters.AddWithValue("@FechaEnvio", venta.FechaEnvio);
                    cmd.Parameters.AddWithValue("@UnidadesVendidas", venta.UnidadesVendidas);
                    cmd.Parameters.AddWithValue("@PrecioUnitario", venta.PrecioUnitario);
                    cmd.Parameters.AddWithValue("@CostoUnitario", venta.CostoUnitario);
                    cmd.Parameters.AddWithValue("@IngresoTotal", venta.IngresoTotal);
                    cmd.Parameters.AddWithValue("@CostoTotal", venta.CostoTotal);
                    cmd.Parameters.AddWithValue("@GananciaTotal", venta.GananciaTotal);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        // Insercion masiva de ventas (para cargar el CSV)
        public int InsertarMasivo(List<Venta> ventas)
        {
            int insertados = 0;
            using (var conexion = ConexionBD.ObtenerConexion())
            {
                using (var transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        foreach (var venta in ventas)
                        {
                            string sql = @"
                                INSERT INTO Ventas (Region, Pais, TipoProducto, CanalVenta, Prioridad,
                                    FechaOrden, OrdenId, FechaEnvio, UnidadesVendidas, PrecioUnitario,
                                    CostoUnitario, IngresoTotal, CostoTotal, GananciaTotal)
                                VALUES (@Region, @Pais, @TipoProducto, @CanalVenta, @Prioridad,
                                    @FechaOrden, @OrdenId, @FechaEnvio, @UnidadesVendidas, @PrecioUnitario,
                                    @CostoUnitario, @IngresoTotal, @CostoTotal, @GananciaTotal)";

                            using (var cmd = new SqlCommand(sql, conexion, transaccion))
                            {
                                cmd.Parameters.AddWithValue("@Region", venta.Region);
                                cmd.Parameters.AddWithValue("@Pais", venta.Pais);
                                cmd.Parameters.AddWithValue("@TipoProducto", venta.TipoProducto);
                                cmd.Parameters.AddWithValue("@CanalVenta", venta.CanalVenta);
                                cmd.Parameters.AddWithValue("@Prioridad", venta.Prioridad);
                                cmd.Parameters.AddWithValue("@FechaOrden", venta.FechaOrden);
                                cmd.Parameters.AddWithValue("@OrdenId", venta.OrdenId);
                                cmd.Parameters.AddWithValue("@FechaEnvio", venta.FechaEnvio);
                                cmd.Parameters.AddWithValue("@UnidadesVendidas", venta.UnidadesVendidas);
                                cmd.Parameters.AddWithValue("@PrecioUnitario", venta.PrecioUnitario);
                                cmd.Parameters.AddWithValue("@CostoUnitario", venta.CostoUnitario);
                                cmd.Parameters.AddWithValue("@IngresoTotal", venta.IngresoTotal);
                                cmd.Parameters.AddWithValue("@CostoTotal", venta.CostoTotal);
                                cmd.Parameters.AddWithValue("@GananciaTotal", venta.GananciaTotal);
                                cmd.ExecuteNonQuery();
                                insertados++;
                            }
                        }
                        transaccion.Commit();
                    }
                    catch
                    {
                        transaccion.Rollback();
                        throw;
                    }
                }
            }
            return insertados;
        }

        // Obtiene todas las ventas (o las primeras N)
        public List<Venta> ObtenerTodas(int cantidad = 500)
        {
            var lista = new List<Venta>();
            using (var conexion = ConexionBD.ObtenerConexion())
            {
                string sql = string.Format("SELECT TOP {0} * FROM Ventas ORDER BY Id DESC", cantidad);
                using (var cmd = new SqlCommand(sql, conexion))
                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        lista.Add(MapearVenta(lector));
                    }
                }
            }
            return lista;
        }

        // Busca ventas por pais
        public List<Venta> BuscarPorPais(string pais)
        {
            var lista = new List<Venta>();
            using (var conexion = ConexionBD.ObtenerConexion())
            {
                string sql = "SELECT * FROM Ventas WHERE Pais LIKE @Pais ORDER BY IngresoTotal DESC";
                using (var cmd = new SqlCommand(sql, conexion))
                {
                    cmd.Parameters.AddWithValue("@Pais", "%" + pais + "%");
                    using (var lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            lista.Add(MapearVenta(lector));
                        }
                    }
                }
            }
            return lista;
        }

        // Busca ventas por tipo de producto
        public List<Venta> BuscarPorProducto(string tipoProducto)
        {
            var lista = new List<Venta>();
            using (var conexion = ConexionBD.ObtenerConexion())
            {
                string sql = "SELECT * FROM Ventas WHERE TipoProducto LIKE @Tipo ORDER BY IngresoTotal DESC";
                using (var cmd = new SqlCommand(sql, conexion))
                {
                    cmd.Parameters.AddWithValue("@Tipo", "%" + tipoProducto + "%");
                    using (var lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            lista.Add(MapearVenta(lector));
                        }
                    }
                }
            }
            return lista;
        }

        // Elimina una venta por ID
        public bool Eliminar(int id)
        {
            using (var conexion = ConexionBD.ObtenerConexion())
            {
                string sql = "DELETE FROM Ventas WHERE Id = @Id";
                using (var cmd = new SqlCommand(sql, conexion))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // Cuenta el total de registros
        public int ContarTotal()
        {
            using (var conexion = ConexionBD.ObtenerConexion())
            {
                string sql = "SELECT COUNT(*) FROM Ventas";
                using (var cmd = new SqlCommand(sql, conexion))
                {
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        // Reporte agrupado por region
        public List<ReporteRegion> ReportePorRegion()
        {
            var lista = new List<ReporteRegion>();
            using (var conexion = ConexionBD.ObtenerConexion())
            {
                string sql = @"
                    SELECT Region, COUNT(*) AS TotalVentas,
                           SUM(IngresoTotal) AS IngresoTotal,
                           SUM(GananciaTotal) AS GananciaTotal
                    FROM Ventas
                    GROUP BY Region
                    ORDER BY IngresoTotal DESC";
                using (var cmd = new SqlCommand(sql, conexion))
                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        lista.Add(new ReporteRegion
                        {
                            Region = lector["Region"].ToString() ?? "",
                            TotalVentas = (int)lector["TotalVentas"],
                            IngresoTotal = (decimal)lector["IngresoTotal"],
                            GananciaTotal = (decimal)lector["GananciaTotal"]
                        });
                    }
                }
            }
            return lista;
        }

        // Reporte agrupado por tipo de producto
        public List<ReporteProducto> ReportePorProducto()
        {
            var lista = new List<ReporteProducto>();
            using (var conexion = ConexionBD.ObtenerConexion())
            {
                string sql = @"
                    SELECT TipoProducto, COUNT(*) AS TotalVentas,
                           SUM(UnidadesVendidas) AS UnidadesTotales,
                           SUM(IngresoTotal) AS IngresoTotal
                    FROM Ventas
                    GROUP BY TipoProducto
                    ORDER BY IngresoTotal DESC";
                using (var cmd = new SqlCommand(sql, conexion))
                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        lista.Add(new ReporteProducto
                        {
                            TipoProducto = lector["TipoProducto"].ToString() ?? "",
                            TotalVentas = (int)lector["TotalVentas"],
                            UnidadesTotales = (int)lector["UnidadesTotales"],
                            IngresoTotal = (decimal)lector["IngresoTotal"]
                        });
                    }
                }
            }
            return lista;
        }

        // Mapea un SqlDataReader a un objeto Venta
        private Venta MapearVenta(SqlDataReader lector)
        {
            return new Venta
            {
                Id = (int)lector["Id"],
                Region = lector["Region"].ToString() ?? "",
                Pais = lector["Pais"].ToString() ?? "",
                TipoProducto = lector["TipoProducto"].ToString() ?? "",
                CanalVenta = lector["CanalVenta"].ToString() ?? "",
                Prioridad = lector["Prioridad"].ToString() ?? "",
                FechaOrden = (DateTime)lector["FechaOrden"],
                OrdenId = (long)lector["OrdenId"],
                FechaEnvio = (DateTime)lector["FechaEnvio"],
                UnidadesVendidas = (int)lector["UnidadesVendidas"],
                PrecioUnitario = (decimal)lector["PrecioUnitario"],
                CostoUnitario = (decimal)lector["CostoUnitario"],
                IngresoTotal = (decimal)lector["IngresoTotal"],
                CostoTotal = (decimal)lector["CostoTotal"],
                GananciaTotal = (decimal)lector["GananciaTotal"]
            };
        }
    }
}
