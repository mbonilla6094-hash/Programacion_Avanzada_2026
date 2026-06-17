# 🚀 Masterclass de C# .NET: Arquitectura N-Capas, LINQ y Patrones de Diseño

> **Guía de Estudio Definitiva para el Examen de Programación Avanzada**
> *Documentación superdetallada paso a paso de los proyectos del semestre.*

Bienvenidos a la documentación más completa jamás creada sobre el desarrollo de software empresarial en C#. Este README no solo documenta el código, sino que **enseña cómo pensar y estructurar** aplicaciones modernas.

Todo el contenido está basado en los proyectos reales desarrollados durante el semestre (disponibles en este mismo directorio), enfocándose exclusivamente en **Arquitectura de 4 Capas** y manipulación avanzada de datos con **LINQ**.

---

## 📑 Índice de Contenidos

1. [Arquitectura N-Capas (4 Capas)](#1-arquitectura-n-capas-4-capas)
2. [El Flujo de Vida de un Dato (CRUD)](#2-el-flujo-de-vida-de-un-dato-crud)
3. [Acceso a Datos: ADO.NET vs Entity Framework](#3-acceso-a-datos-adonet-vs-entity-framework)
4. [Patrones Avanzados: Repository y Unit of Work](#4-patrones-avanzados-repository-y-unit-of-work)
5. [Mastering LINQ (Language Integrated Query)](#5-mastering-linq-language-integrated-query)
6. [Diseño de Base de Datos (Modelo Entidad-Relación)](#6-diseño-de-base-de-datos-modelo-entidad-relación)
7. [Directorio de Proyectos](#7-directorio-de-proyectos)

---

## 1. Arquitectura N-Capas (4 Capas)

El objetivo principal de la arquitectura N-Capas es la **Separación de Responsabilidades (Separation of Concerns)**. Un proyecto que mezcla la interfaz gráfica con las consultas SQL es imposible de mantener. Por eso, dividimos el sistema en componentes aislados.

![Arquitectura N-Capas](./imagenes/arquitectura_n_capas.png)

### Las 4 Capas Fundamentales:

1. 💻 **Presentación / Vista (UI):** 
   - **Qué hace:** Interactúa con el usuario. Muestra formularios, botones, tablas (DataGrid).
   - **Regla de oro:** ¡No contiene NUNCA código de base de datos ni validaciones de negocio complejas! Solo captura eventos y llama a la capa de Negocio.
2. ⚙️ **Lógica de Negocio (BLL - Business Logic Layer):**
   - **Qué hace:** Es el "Cerebro" de la aplicación. Valida reglas (ej: *Un estudiante debe tener cédula válida*, *El porcentaje de avance no puede pasar 100%*).
   - **Regla de oro:** Si la validación pasa, llama a la Capa de Datos. Si falla, devuelve un error a la Presentación.
3. 🗄️ **Acceso a Datos (DAL - Data Access Layer):**
   - **Qué hace:** Es la única capa autorizada para hablar con SQL Server. Ejecuta los `SELECT`, `INSERT`, `UPDATE`, `DELETE`.
   - **Regla de oro:** No le importa de dónde vienen los datos ni para qué se usan, solo los guarda o recupera.
4. 📦 **Entidades (Modelos / POCOs):**
   - **Qué hace:** Define la estructura de los datos. Son simples clases de C# con propiedades (`get; set;`).
   - **Regla de oro:** Esta capa es compartida por TODAS las demás capas. Es el "idioma común" con el que se comunican.

#### Ejemplo de una Entidad (`Estudiante.cs`)
```csharp
namespace Entidades
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombres { get; set; }
        // Las entidades solo tienen propiedades, no tienen lógica.
    }
}
```

---

## 2. El Flujo de Vida de un Dato (CRUD)

¿Qué pasa exactamente cuando un usuario hace clic en el botón "Guardar"? El dato viaja a través de todas las capas.

![Flujo CRUD](./imagenes/crud_flujo.png)

### Anatomía de un Flujo Completo (Ejemplo: Guardar Estudiante)

**Paso 1: La Vista (Formulario)** captura los textos y arma la Entidad.
```csharp
// Dentro del evento btnGuardar_Click en el Formulario
Estudiante nuevo = new Estudiante();
nuevo.Cedula = txtCedula.Text;
nuevo.Nombres = txtNombres.Text;

// La Vista le pasa la pelota a la Capa de Negocio
Respuesta r = EstudianteNEG.Insertar(nuevo);
MessageBox.Show(r.Mensaje);
```

**Paso 2: La Lógica de Negocio (`EstudianteNEG.cs`)** recibe el objeto y lo interroga.
```csharp
public static Respuesta Insertar(Estudiante e)
{
    // 1. Validar reglas del negocio (RegEx, nulos, longitudes)
    if (e.Cedula.Length != 10) return Respuesta.Error("Cédula inválida");
    
    // 2. Si todo está bien, delegar el trabajo sucio a la capa de Datos
    bool exito = EstudianteDAL.Insertar(e);
    
    // 3. Empaquetar la respuesta para que la Vista sepa qué pasó
    return exito ? Respuesta.Ok("Guardado") : Respuesta.Error("Falló DB");
}
```

**Paso 3: El Acceso a Datos (`EstudianteDAL.cs`)** abre la conexión y ejecuta SQL.
```csharp
public static bool Insertar(Estudiante e)
{
    // Conecta con SQL Server
    using(SqlConnection cx = new SqlConnection(cadena))
    {
        SqlCommand cmd = new SqlCommand("INSERT INTO Estudiantes (Cedula) VALUES (@c)", cx);
        cmd.Parameters.AddWithValue("@c", e.Cedula);
        cx.Open();
        return cmd.ExecuteNonQuery() > 0;
    }
}
```

---

## 3. Acceso a Datos: ADO.NET vs Entity Framework

Durante el semestre utilizamos dos enfoques diferentes para la Capa de Datos. Entender la diferencia es clave para el examen.

![ADO.NET vs EF Core](./imagenes/adonet_vs_ef.png)

### Enfoque 1: ADO.NET Puro (Proyecto: `SolucionEstudiantes2`)
Es el método clásico y manual. Te da el control absoluto sobre el SQL, pero requiere escribir mucho código repetitivo (Boilerplate).

- 🔧 **Herramientas:** `SqlConnection`, `SqlCommand`, `SqlDataReader`.
- ⚠️ **Riesgos:** Debes mapear cada columna manualmente: `est.Nombre = dr["Nombres"].ToString();`. Un error de tipeo en el nombre de la columna rompe el programa en tiempo de ejecución.
- 🛡️ **Seguridad:** Siempre usar parámetros (`@param`) para evitar Inyección SQL.

### Enfoque 2: Entity Framework / ORM (Proyecto: `ProyectoTesis_4Capas`)
Un ORM (Object-Relational Mapper) convierte automáticamente tus clases de C# en tablas de base de datos, y tus consultas LINQ en código SQL.

- 🔧 **Herramientas:** `DbContext`, `DbSet<T>`.
- ⚡ **Ventaja:** Te olvidas de escribir cadenas de texto con SQL. Consultas la base de datos usando programación orientada a objetos puro.
- 🔄 **Tracking:** EF rastrea los cambios que le haces a un objeto en memoria y cuando llamas a `SaveChanges()`, él mismo genera los comandos `UPDATE` necesarios.

---

## 4. Patrones Avanzados: Repository y Unit of Work

En proyectos más complejos como `ProyectoTesis_4Capas` y `SistemaVentas`, usar clases estáticas para el acceso a datos (como hacíamos al inicio) se vuelve insostenible. Aquí entran los patrones de diseño empresarial.

![Patrón Repositorio](./imagenes/repository_pattern.png)

### El Patrón Repositorio (Repository Pattern)
Crea una abstracción (una capa intermedia) entre el código de negocio y Entity Framework. 

**¿Por qué lo usamos?**
En lugar de escribir los métodos de inserción, actualización y borrado 50 veces (una por cada tabla), creamos un **Repositorio Genérico** (`RepositorioBase<T>`) que hace todo el trabajo para cualquier Entidad.

```csharp
// Un solo archivo hace el CRUD para TODA LA BASE DE DATOS
public class RepositorioBase<T> : IRepositorio<T> where T : class
{
    protected readonly DbContext _context;
    protected readonly DbSet<T> _dbSet;
    
    // Método universal para obtener por ID
    public T ObtenerPorId(int id) => _dbSet.Find(id);
    
    // Método universal para agregar
    public void Agregar(T entidad) => _dbSet.Add(entidad);
}
```

Luego, si una tabla necesita métodos específicos, hereda del base:
```csharp
public class EstudianteRepositorio : RepositorioBase<Estudiante>
{
    // Solo escribo lo que es único de Estudiantes
    public IEnumerable<Estudiante> ObtenerPorProfesor(int profeId)
    {
        return Buscar(e => e.ProfesorId == profeId);
    }
}
```

### El Patrón Unit of Work
Asegura que **múltiples repositorios compartan la misma conexión a la base de datos** (`DbContext`) y que las transacciones sean atómicas. Todo se guarda junto, o nada se guarda.

```csharp
// Así se usa en la Capa de Negocio
using (var uow = new UnitOfWork())
{
    // Saco los repositorios desde el Unit of Work
    uow.EstudianteRepositorio.Agregar(nuevoEstudiante);
    uow.HistorialRepositorio.Agregar(nuevoHistorial);
    
    // Esto ejecuta todas las queries pendientes en 1 sola transacción
    uow.Guardar(); 
}
```

---

## 5. Mastering LINQ (Language Integrated Query)

LINQ es, sin duda, la característica más poderosa de C#. Permite tratar colecciones de datos (Listas, Arrays o Bases de Datos vía Entity Framework) como si fueran tablas SQL, pero con validación de sintaxis en tiempo de compilación.

![Operadores LINQ](./imagenes/linq_operadores.png)
![Cheat Sheet LINQ](./imagenes/linq_referencia.png)

### Las Expresiones Lambda (`=>`)
LINQ funciona mediante expresiones Lambda, que son funciones anónimas cortas. Se leen como "Dado X, haz Y".
`x => x.Edad >= 18` se lee: *"Dado el elemento x, retorna verdadero si su Edad es mayor o igual a 18"*.

### Arsenal de Operadores LINQ (Para el examen)

1. 🔍 **Filtrado (`.Where`)**
   Retorna TODOS los elementos que cumplan una condición.
   ```csharp
   // Dame la lista de todos los estudiantes aprobados
   var aprobados = lista.Where(e => e.Estado == "Aprobado").ToList();
   ```

2. 🎯 **Proyección (`.Select`)**
   Transforma o extrae partes de los datos. (Es equivalente a un `SELECT columna1, columna2 FROM...` en SQL).
   ```csharp
   // Solo quiero una lista de strings con los correos, nada más
   List<string> correos = lista.Select(e => e.Email).ToList();
   ```

3. 🥇 **Búsqueda Exacta (`.FirstOrDefault`)**
   Busca el PRIMER elemento que cumpla la condición. Si no encuentra nada, devuelve `null` (no lanza error). Es vital para buscar por ID.
   ```csharp
   var juan = lista.FirstOrDefault(e => e.Cedula == "1711223344");
   if (juan != null) { /* Lo encontré */ }
   ```

4. 📊 **Ordenamiento (`.OrderBy` y `.OrderByDescending`)**
   Ordena colecciones. Puedes encadenar ordenamientos con `.ThenBy`.
   ```csharp
   var ordenados = lista.OrderBy(e => e.Apellidos)
                        .ThenBy(e => e.Nombres).ToList();
   ```

5. 🧮 **Agregación y Cuantificadores (`.Count`, `.Sum`, `.Any`)**
   ```csharp
   int total = lista.Count(e => e.Carrera == "Sistemas");
   bool hayReprobados = lista.Any(e => e.Promedio < 7);
   ```

6. 🔗 **Carga Ansiosa (`.Include`) - Solo en Entity Framework**
   Obliga a EF a traer los datos de tablas relacionadas (JOIN en SQL).
   ```csharp
   // Trae al estudiante Y TAMBIÉN sus informes relacionados
   var est = db.Estudiante.Include(e => e.InformeCabecera).FirstOrDefault(e => e.Id == 1);
   ```

### 🤯 Ejemplo Avanzado (Unión de múltiples métodos)
Extracto real del `EstudianteRepositorio` aplicando filtros dinámicos:
```csharp
// Se arranca con la consulta base
var query = db.Estudiante.Include(e => e.Profesor).Where(e => e.ProfesorId == profeId);

// Se van agregando condicionales "WHERE" dinámicamente
if (!string.IsNullOrWhiteSpace(nombre))
    query = query.Where(e => e.Nombres.Contains(nombre));

if (fechaDesde.HasValue)
    query = query.Where(e => e.FechaRegistro >= fechaDesde.Value);

// Al final se ejecuta el SELECT en SQL ordenando los resultados
return query.OrderByDescending(e => e.FechaRegistro).ToList();
```

---

## 6. Diseño de Base de Datos (Modelo Entidad-Relación)

Para que Entity Framework y ADO.NET funcionen, la base de datos debe estar normalizada.

![Diagrama Entidad-Relación](./imagenes/entidad_relacion.png)

**Conceptos clave aplicados:**
- **Claves Primarias (PK):** Campos únicos como `Id`. En EF, si la propiedad se llama `Id` o `EstudianteId`, EF asume automáticamente que es la PK y es Autonumérica (Identity).
- **Claves Foráneas (FK):** Relacionan tablas. Por ejemplo, `ProfesorId` dentro de la tabla `Estudiante` indica de quién es alumno.
- **Relaciones Uno a Muchos (1:N):** Un Profesor tiene múltiples Estudiantes (`ICollection<Estudiante>`). Un Estudiante pertenece a un solo Profesor (`public virtual Profesor Profesor`). El modificador `virtual` en C# le dice a Entity Framework que habilite la *Carga Diferida* (Lazy Loading).

---

## 7. Directorio de Proyectos

Esta carpeta (`AllProjects`) contiene la colección definitiva de los desarrollos clave del semestre. Úsalos como material de consulta:

| Proyecto | Descripción Principal | Tecnologías Destacadas |
|----------|----------------------|-----------------------|
| 📂 **`ProyectoTesis_4Capas`** | Sistema de gestión de tesis universitarias. | **EF Core, Repositories, Unit of Work**, 4 Capas, LINQ avanzado, UI compleja. |
| 📂 **`SolucionEstudiantes2`** | CRUD completo de estudiantes desde cero. | **ADO.NET puro**, 4 Capas estáticas, Transacciones SQL manuales. |
| 📂 **`SistemaVentas`** | Punto de venta y facturación. | 4 Capas, LINQ. |
| 📂 **`SolucionBiblioteca`** | Gestión de préstamos y libros. | 4 Capas, LINQ. |
| 📂 **`TaxiFarePredictor`** | Predicción de tarifas (IA). | **ML.NET**, EF Core, SQL Server, async/await. |
| 📂 **`FarmaciaPresentacion`** | (DeCENTAFAREN_Farmacia) Gestión médica. | LINQ, **Impresión Tickets, QR, Código de Barras.** |
| 📂 **`ControlEstudiantes_APE1/2`** | Ejercicios base UI. | LINQ básico, WinForms. |
| 📂 **`EJERCICIOS`** | Lógicas aisladas y algoritmos. | Colecciones genéricas y LINQ intensivo. |

---

*👩‍💻 Documentación generada para lograr la excelencia en el examen de Programación Avanzada.*
*📌 "El código es como el humor. Cuando tienes que explicarlo, es malo." - Cory House (Pero para el examen, sí hay que explicarlo todo).*

---

# 📚 ANEXO DE ESTUDIO INTENSIVO: CÓDIGO FUENTE LÍNEA POR LÍNEA

> **NOTA PARA EL ESTUDIANTE:** 
> A continuación se presenta el código fuente completo de los componentes más críticos de la arquitectura N-Capas y las implementaciones de LINQ. Este anexo ha sido generado para que no tengas que abrir Visual Studio al repasar. Todo el código que necesitas para el examen está aquí mismo.


## 📝 Archivo: $nombreRelativo
**Ubicación:** $(EstudianteDAL.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace DatosADO
{
    public class EstudianteDAL
    {
        // â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•
        //                  CREATE
        // â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•
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

        // â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•
        //              READ â€” Todos
        // â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•
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

        // â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•
        //              READ â€” Por ID
        // â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•
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

        // â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•
        //              READ â€” Buscar
        // â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•
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

        // â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•
        //                  UPDATE
        // â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•
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

        // â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•
        //                  DELETE
        // â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•â•
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

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(RepositorioVenta.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;
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

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(PdfServicio.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProyectoTesis.Entidades;
using ProyectoTesis.Logica.Interfaces;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace ProyectoTesis.Logica.Servicios
{
    public class PdfServicio : IPdfServicio
    {
        public PdfServicio()
        {
            QuestPDF.Settings.License = LicenseType.Community;
        }

        public byte[] GenerarInformeMensual(InformeCabecera informe, List<InformeDetalle> actividades, string rutaLogo)
        {
            using (var ms = new MemoryStream())
            {
                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(30);
                        page.DefaultTextStyle(x => x.FontSize(10));

                        page.Header().Element(c => CabeceraInforme(c, informe, rutaLogo));
                        page.Content().Element(c => CuerpoInforme(c, informe, actividades));
                        page.Footer().AlignCenter().Text($"Generado el {DateTime.Now:dd/MM/yyyy HH:mm}").FontSize(8).FontColor(Colors.Grey.Medium);
                    });
                }).GeneratePdf(ms);

                return ms.ToArray();
            }
        }

        public byte[] GenerarInformeFinal(Estudiante estudiante, List<HistorialProgresion> listaHistorial, string rutaLogo)
        {
            using (var ms = new MemoryStream())
            {
                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(30);
                        page.DefaultTextStyle(x => x.FontSize(10));

                        page.Header().Element(c => CabeceraFinal(c, estudiante, rutaLogo));
                        page.Content().Element(c => CuerpoFinal(c, estudiante, listaHistorial));
                        page.Footer().AlignCenter().Text($"Generado el {DateTime.Now:dd/MM/yyyy HH:mm}").FontSize(8).FontColor(Colors.Grey.Medium);
                    });
                }).GeneratePdf(ms);

                return ms.ToArray();
            }
        }

        private void CabeceraInforme(IContainer container, InformeCabecera informe, string rutaLogo)
        {
            container.Column(col =>
            {
                if (File.Exists(rutaLogo))
                    col.Item().Width(100).Image(rutaLogo);

                col.Item().AlignCenter().Text("UNIVERSIDAD").SemiBold().FontSize(16);
                col.Item().AlignCenter().Text("SISTEMA DE SEGUIMIENTO DE TESIS").FontSize(12);
                col.Item().AlignCenter().Text($"INFORME DE AVANCE {informe.NumeroInforme}").SemiBold().FontSize(14);
                col.Item().PaddingVertical(5);
            });
        }

        private void CuerpoInforme(IContainer container, InformeCabecera informe, List<InformeDetalle> actividades)
        {
            container.Column(col =>
            {
                col.Item().Row(row =>
                {
                    row.RelativeItem().Column(c =>
                    {
                        c.Item().Text($"Estudiante: {informe.Estudiante?.Nombres} {informe.Estudiante?.Apellidos}").SemiBold();
                        c.Item().Text($"Carrera: {informe.Estudiante?.Carrera}");
                        c.Item().Text($"Titulo: {informe.Estudiante?.TituloTesis}");
                        c.Item().Text($"Resolucion: {informe.Estudiante?.NumeroResolucion}");
                    });
                    row.RelativeItem().Column(c =>
                    {
                        c.Item().Text($"Fecha: {informe.FechaEmision:dd/MM/yyyy}");
                        c.Item().Text($"Estado: {informe.Estado}");
                        c.Item().Text($"% Acumulado: {informe.PorcentajeAcumulado}%");
                        c.Item().Text($"Profesor: {informe.Profesor?.Nombres} {informe.Profesor?.Apellidos}");
                    });
                });

                col.Item().PaddingVertical(10);
                col.Item().Text("ACTIVIDADES REALIZADAS").SemiBold().FontSize(12);
                col.Item().PaddingVertical(5);

                col.Item().Table(table =>
                {
                    table.ColumnsDefinition(c =>
                    {
                        c.ConstantColumn(40);
                        c.RelativeColumn();
                        c.ConstantColumn(60);
                        c.ConstantColumn(100);
                    });

                    table.Header(header =>
                    {
                        header.Cell().Border(1).Background(Colors.Grey.Lighten3).AlignCenter().Text("#").SemiBold();
                        header.Cell().Border(1).Background(Colors.Grey.Lighten3).AlignCenter().Text("Actividad").SemiBold();
                        header.Cell().Border(1).Background(Colors.Grey.Lighten3).AlignCenter().Text("%").SemiBold();
                        header.Cell().Border(1).Background(Colors.Grey.Lighten3).AlignCenter().Text("Observacion").SemiBold();
                    });

                    foreach (var act in actividades)
                    {
                        table.Cell().Border(1).AlignCenter().Text(act.NumeroActividad.ToString());
                        table.Cell().Border(1).Text(act.DescripcionActividad);
                        table.Cell().Border(1).AlignCenter().Text($"{act.PorcentajeActividad}%");
                        table.Cell().Border(1).Text(act.Observacion ?? "");
                    }
                });

                col.Item().PaddingVertical(10);
                col.Item().AlignRight().Text($"Total: {informe.PorcentajeAcumulado}%").SemiBold().FontSize(12);

                if (informe.EsFinal == true)
                {
                    col.Item().PaddingVertical(10);
                    col.Item().Background(Colors.Green.Lighten4).Padding(10).AlignCenter().Text(
                        "TESIS APROBADA - 100% COMPLETADO").SemiBold().FontSize(14).FontColor(Colors.Green.Darken3);
                }
            });
        }

        private void CabeceraFinal(IContainer container, Estudiante estudiante, string rutaLogo)
        {
            container.Column(col =>
            {
                if (File.Exists(rutaLogo))
                    col.Item().Width(100).Image(rutaLogo);

                col.Item().AlignCenter().Text("UNIVERSIDAD").SemiBold().FontSize(16);
                col.Item().AlignCenter().Text("SISTEMA DE SEGUIMIENTO DE TESIS").FontSize(12);
                col.Item().AlignCenter().Text("INFORME FINAL DE TESIS").SemiBold().FontSize(14);
                col.Item().PaddingVertical(5);
            });
        }

        private void CuerpoFinal(IContainer container, Estudiante estudiante, List<HistorialProgresion> historial)
        {
            container.Column(col =>
            {
                col.Item().Row(row =>
                {
                    row.RelativeItem().Column(c =>
                    {
                        c.Item().Text($"Estudiante: {estudiante.Nombres} {estudiante.Apellidos}").SemiBold();
                        c.Item().Text($"Cedula: {estudiante.Cedula}");
                        c.Item().Text($"Carrera: {estudiante.Carrera}");
                        c.Item().Text($"Titulo: {estudiante.TituloTesis}");
                        c.Item().Text($"Resolucion: {estudiante.NumeroResolucion} - {estudiante.FechaResolucion:dd/MM/yyyy}");
                    });
                    row.RelativeItem().Column(c =>
                    {
                        c.Item().Text($"Estado Final: {estudiante.Estado}");
                        c.Item().Text($"% Final: {estudiante.PorcentajeAvance}%");
                        c.Item().Text($"Registro: {estudiante.FechaRegistro:dd/MM/yyyy}");
                    });
                });

                col.Item().PaddingVertical(15);
                col.Item().Text("HISTORIAL DE PROGRESION").SemiBold().FontSize(12);
                col.Item().PaddingVertical(5);

                col.Item().Table(table =>
                {
                    table.ColumnsDefinition(c =>
                    {
                        c.ConstantColumn(30);
                        c.RelativeColumn();
                        c.ConstantColumn(50);
                        c.ConstantColumn(70);
                        c.ConstantColumn(80);
                    });

                    table.Header(header =>
                    {
                        header.Cell().Border(1).Background(Colors.Grey.Lighten3).AlignCenter().Text("#").SemiBold();
                        header.Cell().Border(1).Background(Colors.Grey.Lighten3).AlignCenter().Text("Actividades").SemiBold();
                        header.Cell().Border(1).Background(Colors.Grey.Lighten3).AlignCenter().Text("%").SemiBold();
                        header.Cell().Border(1).Background(Colors.Grey.Lighten3).AlignCenter().Text("Estado").SemiBold();
                        header.Cell().Border(1).Background(Colors.Grey.Lighten3).AlignCenter().Text("Fecha").SemiBold();
                    });

                    int i = 1;
                    foreach (var h in historial)
                    {
                        table.Cell().Border(1).AlignCenter().Text(i.ToString());
                        table.Cell().Border(1).Text(h.ResumenActividades ?? "");
                        table.Cell().Border(1).AlignCenter().Text($"{h.PorcentajeEnInforme}%");
                        table.Cell().Border(1).AlignCenter().Text(h.EstadoEnInforme);
                        table.Cell().Border(1).AlignCenter().Text($"{h.FechaInforme:dd/MM/yyyy}");
                        i++;
                    }
                });

                col.Item().PaddingVertical(15);
                col.Item().Background(Colors.Green.Lighten4).Padding(10).AlignCenter().Text(
                    "TESIS APROBADA AL 100%").SemiBold().FontSize(16).FontColor(Colors.Green.Darken3);

                col.Item().PaddingVertical(20);
                col.Item().Row(row =>
                {
                    row.RelativeItem().AlignCenter().Column(c =>
                    {
                        c.Item().PaddingTop(30).Width(200).LineHorizontal(1);
                        c.Item().AlignCenter().Text($"{estudiante.Profesor?.Nombres} {estudiante.Profesor?.Apellidos}");
                        c.Item().AlignCenter().Text("Profesor Asesor");
                    });
                });
            });
        }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(InformeServicio.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;
using System.Collections.Generic;
using System.Linq;
using ProyectoTesis.Entidades;
using ProyectoTesis.Logica.Interfaces;

namespace ProyectoTesis.Logica.Servicios
{
    public class InformeServicio : IInformeServicio
    {
        private readonly IHistorialServicio _historialServicio;
        private readonly IPdfServicio _pdfServicio;

        public InformeServicio()
        {
            _historialServicio = new HistorialServicio();
            _pdfServicio = new PdfServicio();
        }

        private InformeCabecera MapDatosAEntidad(ProyectoTesis.Datos.InformeCabecera i)
        {
            if (i == null) return null;
            var entidad = new InformeCabecera
            {
                InformeCabeceraId = i.InformeCabeceraId,
                EstudianteId = i.EstudianteId,
                ProfesorId = i.ProfesorId,
                NumeroInforme = i.NumeroInforme,
                FechaEmision = i.FechaEmision,
                PorcentajeAcumulado = i.PorcentajeAcumulado,
                Estado = i.Estado,
                EsFinal = i.EsFinal,
                InformeDetalle = i.InformeDetalle?.Select(d => new InformeDetalle
                {
                    InformeDetalleId = d.InformeDetalleId,
                    InformeCabeceraId = d.InformeCabeceraId,
                    NumeroActividad = d.NumeroActividad,
                    DescripcionActividad = d.DescripcionActividad,
                    PorcentajeActividad = d.PorcentajeActividad,
                    Observacion = d.Observacion
                }).ToList()
            };
            if (i.Estudiante != null)
            {
                entidad.Estudiante = new Estudiante
                {
                    EstudianteId = i.Estudiante.EstudianteId,
                    ProfesorId = i.Estudiante.ProfesorId,
                    Nombres = i.Estudiante.Nombres,
                    Apellidos = i.Estudiante.Apellidos,
                    Cedula = i.Estudiante.Cedula,
                    Carrera = i.Estudiante.Carrera,
                    TituloTesis = i.Estudiante.TituloTesis,
                    NumeroResolucion = i.Estudiante.NumeroResolucion,
                    FechaResolucion = i.Estudiante.FechaResolucion,
                    Estado = i.Estudiante.Estado,
                    PorcentajeAvance = i.Estudiante.PorcentajeAvance,
                    FechaRegistro = i.Estudiante.FechaRegistro
                };
            }
            if (i.Profesor != null)
            {
                entidad.Profesor = new Profesor
                {
                    ProfesorId = i.Profesor.ProfesorId,
                    Nombres = i.Profesor.Nombres,
                    Apellidos = i.Profesor.Apellidos,
                    Usuario = i.Profesor.Usuario,
                    Contrasena = i.Profesor.Contrasena,
                    Email = i.Profesor.Email,
                    Activo = i.Profesor.Activo
                };
            }
            return entidad;
        }

        public InformeCabecera CrearInforme(int estudianteId, int profesorId, List<InformeDetalle> actividades)
        {
            using (var uow = new ProyectoTesis.Datos.UnitOfWork())
            {
                var estudiante = uow.EstudianteRepositorio.ObtenerPorId(estudianteId);
                if (estudiante == null)
                    throw new ArgumentException("El estudiante no existe");

                int totalPorcentaje = actividades.Sum(a => a.PorcentajeActividad);
                if (totalPorcentaje > 100)
                    throw new ArgumentException("La suma de porcentajes no puede exceder 100%");

                int nuevoNumero = uow.InformeCabeceraRepositorio.ObtenerUltimoNumeroInforme(estudianteId) + 1;
                int porcentajeActual = estudiante.PorcentajeAvance ?? 0;
                int porcentajeAcumulado = porcentajeActual + totalPorcentaje;
                if (porcentajeAcumulado > 100) porcentajeAcumulado = 100;

                var informe = new ProyectoTesis.Datos.InformeCabecera
                {
                    EstudianteId = estudianteId,
                    ProfesorId = profesorId,
                    NumeroInforme = $"INF-{nuevoNumero:D3}",
                    FechaEmision = DateTime.Now,
                    PorcentajeAcumulado = porcentajeAcumulado,
                    Estado = porcentajeAcumulado >= 100 ? "Aprobado" : "En Proceso",
                    EsFinal = porcentajeAcumulado >= 100
                };

                uow.InformeCabeceraRepositorio.Agregar(informe);
                uow.Guardar();

                var detalles = actividades.Select(act => new ProyectoTesis.Datos.InformeDetalle
                {
                    InformeCabeceraId = informe.InformeCabeceraId,
                    NumeroActividad = act.NumeroActividad,
                    DescripcionActividad = act.DescripcionActividad,
                    PorcentajeActividad = act.PorcentajeActividad,
                    Observacion = act.Observacion
                }).ToList();

                uow.InformeDetalleRepositorio.AgregarRango(detalles);

                estudiante.PorcentajeAvance = porcentajeAcumulado;
                estudiante.Estado = porcentajeAcumulado >= 100 ? "Aprobado" : estudiante.Estado;
                uow.EstudianteRepositorio.Actualizar(estudiante);
                uow.Guardar();

                var informeCompletoDatos = uow.InformeCabeceraRepositorio.ObtenerConDetalles(informe.InformeCabeceraId);
                var informeCompleto = MapDatosAEntidad(informeCompletoDatos);
                _historialServicio.RegistrarProgresion(informeCompleto);

                return informeCompleto;
            }
        }

        public IEnumerable<InformeCabecera> ObtenerInformesPorEstudiante(int estudianteId)
        {
            using (var uow = new ProyectoTesis.Datos.UnitOfWork())
            {
                return uow.InformeCabeceraRepositorio.ObtenerPorEstudiante(estudianteId)
                    .Select(i => MapDatosAEntidad(i)).ToList();
            }
        }

        public InformeCabecera ObtenerInformeConDetalles(int informeId)
        {
            using (var uow = new ProyectoTesis.Datos.UnitOfWork())
            {
                return MapDatosAEntidad(uow.InformeCabeceraRepositorio.ObtenerConDetalles(informeId));
            }
        }

        public byte[] GenerarPdfInforme(int informeId, string rutaLogo)
        {
            var informe = ObtenerInformeConDetalles(informeId);
            if (informe == null)
                throw new ArgumentException("El informe no existe");

            return _pdfServicio.GenerarInformeMensual(informe, informe.InformeDetalle.ToList(), rutaLogo);
        }

        public byte[] GenerarPdfInformeFinal(int estudianteId, string rutaLogo)
        {
            using (var uow = new ProyectoTesis.Datos.UnitOfWork())
            {
                var estudianteDatos = uow.EstudianteRepositorio.ObtenerConHistorial(estudianteId);
                if (estudianteDatos == null)
                    throw new ArgumentException("El estudiante no existe");

                var historialDatos = uow.HistorialRepositorio.ObtenerPorEstudiante(estudianteId).ToList();

                var estudiante = new Estudiante
                {
                    EstudianteId = estudianteDatos.EstudianteId,
                    ProfesorId = estudianteDatos.ProfesorId,
                    Nombres = estudianteDatos.Nombres,
                    Apellidos = estudianteDatos.Apellidos,
                    Cedula = estudianteDatos.Cedula,
                    Carrera = estudianteDatos.Carrera,
                    TituloTesis = estudianteDatos.TituloTesis,
                    NumeroResolucion = estudianteDatos.NumeroResolucion,
                    FechaResolucion = estudianteDatos.FechaResolucion,
                    ArchivoResolucion = estudianteDatos.ArchivoResolucion,
                    Estado = estudianteDatos.Estado,
                    PorcentajeAvance = estudianteDatos.PorcentajeAvance,
                    FechaRegistro = estudianteDatos.FechaRegistro
                };

                if (estudianteDatos.Profesor != null)
                {
                    estudiante.Profesor = new Profesor
                    {
                        ProfesorId = estudianteDatos.Profesor.ProfesorId,
                        Nombres = estudianteDatos.Profesor.Nombres,
                        Apellidos = estudianteDatos.Profesor.Apellidos,
                        Usuario = estudianteDatos.Profesor.Usuario,
                        Contrasena = estudianteDatos.Profesor.Contrasena,
                        Email = estudianteDatos.Profesor.Email,
                        Activo = estudianteDatos.Profesor.Activo
                    };
                }

                var historial = historialDatos.Select(h => new HistorialProgresion
                {
                    HistorialId = h.HistorialId,
                    EstudianteId = h.EstudianteId,
                    InformeCabeceraId = h.InformeCabeceraId,
                    FechaInforme = h.FechaInforme,
                    PorcentajeEnInforme = h.PorcentajeEnInforme,
                    EstadoEnInforme = h.EstadoEnInforme,
                    ResumenActividades = h.ResumenActividades
                }).ToList();

                return _pdfServicio.GenerarInformeFinal(estudiante, historial, rutaLogo);
            }
        }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(FormPrincipal.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace Presentacion
{
    public partial class FormPrincipal : Form
    {
        private bool _modoEdicion = false;

        public FormPrincipal()
        {
            InitializeComponent();
            ConfigurarGrid();
            CargarEstudiantes();
        }

        // â”€â”€ Configuracion del DataGridView â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        private void ConfigurarGrid()
        {
            dgvEstudiantes.AutoGenerateColumns = false;
            dgvEstudiantes.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
            dgvEstudiantes.ReadOnly            = true;
            dgvEstudiantes.AllowUserToAddRows  = false;
            dgvEstudiantes.BackgroundColor     = Color.White;
            dgvEstudiantes.RowHeadersVisible   = false;
            dgvEstudiantes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255);

            dgvEstudiantes.Columns.Add(new DataGridViewTextBoxColumn { Name = "colId",        HeaderText = "ID",        DataPropertyName = "Id",            Width = 45  });
            dgvEstudiantes.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCedula",    HeaderText = "Cedula",    DataPropertyName = "Cedula",        Width = 100 });
            dgvEstudiantes.Columns.Add(new DataGridViewTextBoxColumn { Name = "colNombres",   HeaderText = "Nombres",   DataPropertyName = "Nombres",       Width = 120 });
            dgvEstudiantes.Columns.Add(new DataGridViewTextBoxColumn { Name = "colApellidos", HeaderText = "Apellidos", DataPropertyName = "Apellidos",     Width = 120 });
            dgvEstudiantes.Columns.Add(new DataGridViewTextBoxColumn { Name = "colEmail",     HeaderText = "Email",     DataPropertyName = "Email",         Width = 180 });
            dgvEstudiantes.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCarrera",   HeaderText = "Carrera",   DataPropertyName = "Carrera",       Width = 180 });
            dgvEstudiantes.Columns.Add(new DataGridViewTextBoxColumn { Name = "colFecha",     HeaderText = "Fecha",     DataPropertyName = "FechaRegistro", Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } });
        }

        // â”€â”€ Cargar todos â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        private void CargarEstudiantes()
        {
            try
            {
                Respuesta resp = EstudianteNEG.ObtenerTodos();
                if (resp.Exitoso)
                {
                    List<Estudiante> lista = resp.Data as List<Estudiante>;
                    dgvEstudiantes.DataSource = lista;
                    lblConteo.Text = "Total registros: " + lista.Count;
                }
                else
                {
                    MostrarError(resp.Mensaje);
                }
            }
            catch (Exception ex) { MostrarError(ex.Message); }
        }

        // â”€â”€ Buscar â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Respuesta resp = EstudianteNEG.Buscar(txtBuscar.Text.Trim());
                if (resp.Exitoso)
                {
                    List<Estudiante> lista = resp.Data as List<Estudiante>;
                    dgvEstudiantes.DataSource = lista;
                    lblConteo.Text = "Resultados: " + lista.Count;
                }
                else { MostrarError(resp.Mensaje); }
            }
            catch (Exception ex) { MostrarError(ex.Message); }
        }

        // â”€â”€ Seleccionar fila â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        private void dgvEstudiantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow fila = dgvEstudiantes.Rows[e.RowIndex];
            txtId.Text        = fila.Cells["colId"].Value.ToString();
            txtCedula.Text    = fila.Cells["colCedula"].Value.ToString();
            txtNombres.Text   = fila.Cells["colNombres"].Value.ToString();
            txtApellidos.Text = fila.Cells["colApellidos"].Value.ToString();
            txtEmail.Text     = fila.Cells["colEmail"].Value.ToString();
            txtCarrera.Text   = fila.Cells["colCarrera"].Value.ToString();

            _modoEdicion         = true;
            btnGuardar.Text      = "Actualizar";
            btnEliminar.Enabled  = true;
        }

        // â”€â”€ Guardar / Actualizar â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Estudiante est = new Estudiante();
                est.Cedula    = txtCedula.Text.Trim();
                est.Nombres   = txtNombres.Text.Trim();
                est.Apellidos = txtApellidos.Text.Trim();
                est.Email     = txtEmail.Text.Trim();
                est.Carrera   = txtCarrera.Text.Trim();

                Respuesta resp;
                if (_modoEdicion)
                {
                    est.Id = int.Parse(txtId.Text);
                    resp   = EstudianteNEG.Actualizar(est);
                }
                else
                {
                    resp = EstudianteNEG.Insertar(est);
                }

                if (resp.Exitoso) { MostrarExito(resp.Mensaje); LimpiarFormulario(); CargarEstudiantes(); }
                else              { MostrarError(resp.Mensaje); }
            }
            catch (Exception ex) { MostrarError(ex.Message); }
        }

        // â”€â”€ Eliminar â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text)) return;

            DialogResult confirm = MessageBox.Show(
                "Seguro desea eliminar a " + txtNombres.Text + " " + txtApellidos.Text + "?",
                "Confirmar Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                Respuesta resp = EstudianteNEG.Eliminar(int.Parse(txtId.Text));
                if (resp.Exitoso) { MostrarExito(resp.Mensaje); LimpiarFormulario(); CargarEstudiantes(); }
                else              { MostrarError(resp.Mensaje); }
            }
            catch (Exception ex) { MostrarError(ex.Message); }
        }

        // â”€â”€ Nuevo / Limpiar â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
        private void btnNuevo_Click(object sender, EventArgs e)   { LimpiarFormulario(); }
        private void btnLimpiar_Click(object sender, EventArgs e) { LimpiarFormulario(); }

        private void LimpiarFormulario()
        {
            txtId.Clear(); txtCedula.Clear(); txtNombres.Clear();
            txtApellidos.Clear(); txtEmail.Clear(); txtCarrera.Clear();
            txtBuscar.Clear();
            _modoEdicion         = false;
            btnGuardar.Text      = "Guardar";
            btnEliminar.Enabled  = false;
        }

        private void MostrarExito(string msg) =>
            MessageBox.Show(msg, "Exito",  MessageBoxButtons.OK, MessageBoxIcon.Information);
        private void MostrarError(string msg) =>
            MessageBox.Show(msg, "Error",  MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(FormularioPrincipal.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using PredictorTarifa.Negocio;

namespace PredictorTarifa.Vista
{
    // Capa de Vista: Formulario principal de Windows Forms
    // Este archivo contiene SOLO los eventos y la logica de presentacion
    // Los controles visuales estan definidos en FormularioPrincipal.Designer.cs
    public partial class FormularioPrincipal : Form
    {
        // El gestor puede ser null cuando el Disenador de VS carga el formulario
        private GestorViaje? _gestorViaje;

        public FormularioPrincipal()
        {
            InitializeComponent();

            // Verificar si estamos en modo diseÃ±o (Visual Studio Designer)
            // Si es modo diseÃ±o, NO conectamos a BD ni a ML para evitar errores
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime && !DesignMode)
            {
                _gestorViaje = new GestorViaje();
                CargarHistorial();
            }
        }

        // =====================================================
        // EVENTO: Boton Entrenar Modelo
        // =====================================================
        private async void BtnEntrenar_Click(object sender, EventArgs e)
        {
            if (_gestorViaje == null) return;

            btnEntrenar.Enabled = false;
            btnEntrenar.Text = "Entrenando... por favor espere";
            barraProgreso.MarqueeAnimationSpeed = 30;
            lblEstadoModelo.Text = "Procesando archivo CSV con miles de registros...";
            lblEstadoModelo.ForeColor = Color.FromArgb(100, 116, 139);

            string resultado = await Task.Run(() => _gestorViaje.EntrenarModelo());

            barraProgreso.MarqueeAnimationSpeed = 0;
            btnEntrenar.Enabled = true;
            btnEntrenar.Text = "Entrenar con Datos Historicos (CSV)";

            if (resultado.StartsWith("ERROR"))
            {
                lblEstadoModelo.ForeColor = Color.Red;
                lblEstadoModelo.Text = resultado;
                MessageBox.Show(resultado, "Error de Entrenamiento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                lblEstadoModelo.ForeColor = Color.FromArgb(22, 163, 74);
                lblEstadoModelo.Text = "Modelo listo. " + resultado.Split('\n')[0];
                btnEntrenar.BackColor = Color.FromArgb(22, 163, 74);
                lblEstadoConexion.Text = "Modelo entrenado correctamente | SQL Server conectado";
            }
        }

        // =====================================================
        // EVENTO: Boton Predecir y Guardar
        // =====================================================
        private async void BtnPredecir_Click(object sender, EventArgs e)
        {
            if (_gestorViaje == null) return;

            string empresa = cmbEmpresa.SelectedItem?.ToString() ?? "CMT";
            float pasajeros = (float)numPasajeros.Value;
            float distancia = (float)numDistancia.Value;
            float duracion = (float)numDuracion.Value;
            string tipoPago = cmbTipoPago.SelectedIndex == 0 ? "CRD" : "CSH";

            btnPredecir.Enabled = false;
            btnPredecir.Text = "Procesando...";
            lblTarifaPredicha.Text = "$ ...";
            panelResultado.BackColor = Color.FromArgb(240, 253, 244);

            var resultado = await Task.Run(() =>
                _gestorViaje.PredecirYGuardar(empresa, 1f, pasajeros, duracion, distancia, tipoPago)
            );

            btnPredecir.Enabled = true;
            btnPredecir.Text = "Predecir Tarifa y Guardar en BD";

            if (resultado.Exitoso)
            {
                lblTarifaPredicha.Text = "$" + resultado.TarifaPredicha.ToString("F2");
                lblMensajeGuardado.Text = "Guardado en SQL Server con ID: " + resultado.ViajeId;
                panelResultado.BackColor = Color.FromArgb(240, 253, 244);
                CargarHistorial();
            }
            else
            {
                lblTarifaPredicha.Text = "Error";
                lblMensajeGuardado.Text = resultado.Mensaje;
                panelResultado.BackColor = Color.FromArgb(254, 242, 242);
            }
        }

        // =====================================================
        // EVENTO: Boton Refrescar Historial
        // =====================================================
        private void BtnRefrescarHistorial_Click(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        // =====================================================
        // METODO: Cargar historial desde SQL Server via EF Core
        // =====================================================
        private void CargarHistorial()
        {
            if (_gestorViaje == null) return;

            try
            {
                var viajes = _gestorViaje.ObtenerHistorial(100);
                int total = _gestorViaje.TotalViajesGuardados();

                lblTotalViajes.Text = "Total en BD: " + total + " viajes";
                lblEstadoConexion.Text = "SQL Server conectado | " + total + " registros en PredictorTarifaDB";

                gridHistorial.DataSource = null;
                gridHistorial.Columns.Clear();
                gridHistorial.DataSource = viajes;

                // Renombrar encabezados de columnas al espanol
                if (gridHistorial.Columns.Count > 0)
                {
                    gridHistorial.Columns["Id"].HeaderText = "ID";
                    gridHistorial.Columns["Empresa"].HeaderText = "Empresa";
                    gridHistorial.Columns["CodigoTarifa"].HeaderText = "Codigo";
                    gridHistorial.Columns["NumeroPasajeros"].HeaderText = "Pasajeros";
                    gridHistorial.Columns["DuracionSegundos"].HeaderText = "Duracion (s)";
                    gridHistorial.Columns["DistanciaMillas"].HeaderText = "Distancia (mi)";
                    gridHistorial.Columns["TipoPago"].HeaderText = "Pago";
                    gridHistorial.Columns["TarifaReal"].HeaderText = "Tarifa Real";
                    gridHistorial.Columns["TarifaPredicha"].HeaderText = "Tarifa IA ($)";
                    gridHistorial.Columns["FechaRegistro"].HeaderText = "Fecha Registro";

                    // Formatos de presentacion
                    gridHistorial.Columns["TarifaPredicha"].DefaultCellStyle.Format = "F2";
                    gridHistorial.Columns["TarifaReal"].DefaultCellStyle.Format = "F2";
                    gridHistorial.Columns["FechaRegistro"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    gridHistorial.Columns["Id"].Width = 40;
                    gridHistorial.Columns["Empresa"].Width = 65;
                    gridHistorial.Columns["CodigoTarifa"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                lblEstadoConexion.Text = "Error de conexion a SQL Server: " + ex.Message;
                lblTotalViajes.Text = "Error al cargar datos";
            }
        }

        private void gridHistorial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grupoHistorial_Enter(object sender, EventArgs e)
        {

        }

        private void FormularioPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(Class1.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;
using System.Collections.Generic;
using System.Linq;
using SolucionBiblioteca.Entidades;

namespace Datos
{
    public class Repositorio
    {
        private static Repositorio _instancia;
        public static Repositorio Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new Repositorio();
                return _instancia;
            }
        }

        private Repositorio() { }

        
        private Categoria Mapear(Categorias c)
        {
            if (c == null) return null;
            return new Categoria
            {
                CategoriaID = c.CategoriaID,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion,
                Activo = c.Activo ?? true
            };
        }

        private Libro Mapear(Libros l)
        {
            if (l == null) return null;
            return new Libro
            {
                LibroID = l.LibroID,
                ISBN = l.ISBN,
                Titulo = l.Titulo,
                Autor = l.Autor,
                Editorial = l.Editorial,
                AnioPublicacion = l.AnioPublicacion ?? 0,
                EjemplaresTotales = l.EjemplaresTotales,
                EjemplaresDisponibles = l.EjemplaresDisponibles,
                CategoriaID = l.CategoriaID ?? 0,
                Activo = l.Activo ?? true
            };
        }

        private Estudiante Mapear(Estudiantes e)
        {
            if (e == null) return null;
            return new Estudiante
            {
                EstudianteID = e.EstudianteID,
                Matricula = e.Matricula,
                Nombre = e.Nombre,
                Apellido = e.Apellido,
                Carrera = e.Carrera,
                Semestre = e.Semestre ?? 1,
                Email = e.Email,
                Telefono = e.Telefono,
                Activo = e.Activo ?? true
            };
        }

        private Prestamo Mapear(Prestamos p)
        {
            if (p == null) return null;
            return new Prestamo
            {
                PrestamoID = p.PrestamoID,
                LibroID = p.LibroID ?? 0,
                EstudianteID = p.EstudianteID ?? 0,
                FechaPrestamo = p.FechaPrestamo,
                FechaDevolucionEsperada = p.FechaDevolucionEsperada ?? DateTime.Now,
                FechaDevolucionReal = p.FechaDevolucionReal,
                Estado = p.Estado,
                DiasRetraso = p.DiasRetraso ?? 0,
                MontoMulta = p.MontoMulta ?? 0
            };
        }

        // PROPIEDADES (GETTERS)
        public List<Categoria> Categorias
        {
            get
            {
                using (var db = new BibliotecaDBEntities())
                {
                    return db.Categorias.ToList().Select(Mapear).ToList();
                }
            }
        }

        public List<Libro> Libros
        {
            get
            {
                using (var db = new BibliotecaDBEntities())
                {
                    return db.Libros.ToList().Select(Mapear).ToList();
                }
            }
        }

        public List<Estudiante> Estudiantes
        {
            get
            {
                using (var db = new BibliotecaDBEntities())
                {
                    return db.Estudiantes.ToList().Select(Mapear).ToList();
                }
            }
        }

        public List<Prestamo> Prestamos
        {
            get
            {
                using (var db = new BibliotecaDBEntities())
                {
                    return db.Prestamos.ToList().Select(Mapear).ToList();
                }
            }
        }

        // ADD METHODS
        public void AgregarCategoria(Categoria c)
        {
            using (var db = new BibliotecaDBEntities())
            {
                db.Categorias.Add(new Categorias
                {
                    Nombre = c.Nombre,
                    Descripcion = c.Descripcion,
                    Activo = c.Activo
                });
                db.SaveChanges();
            }
        }

        public void AgregarLibro(Libro l)
        {
            using (var db = new BibliotecaDBEntities())
            {
                db.Libros.Add(new Libros
                {
                    ISBN = l.ISBN,
                    Titulo = l.Titulo,
                    Autor = l.Autor,
                    Editorial = l.Editorial,
                    AnioPublicacion = l.AnioPublicacion == 0 ? (int?)null : l.AnioPublicacion,
                    EjemplaresTotales = l.EjemplaresTotales,
                    EjemplaresDisponibles = l.EjemplaresDisponibles,
                    CategoriaID = l.CategoriaID == 0 ? (int?)null : l.CategoriaID,
                    Activo = l.Activo
                });
                db.SaveChanges();
            }
        }

        public void AgregarEstudiante(Estudiante e)
        {
            using (var db = new BibliotecaDBEntities())
            {
                db.Estudiantes.Add(new Estudiantes
                {
                    Matricula = e.Matricula,
                    Nombre = e.Nombre,
                    Apellido = e.Apellido,
                    Carrera = e.Carrera,
                    Semestre = e.Semestre,
                    Email = e.Email,
                    Telefono = e.Telefono,
                    Activo = e.Activo
                });
                db.SaveChanges();
            }
        }

        public void RegistrarPrestamo(Prestamo p)
        {
            using (var db = new BibliotecaDBEntities())
            {
                db.Prestamos.Add(new Prestamos
                {
                    LibroID = p.LibroID,
                    EstudianteID = p.EstudianteID,
                    FechaPrestamo = p.FechaPrestamo,
                    FechaDevolucionEsperada = p.FechaDevolucionEsperada,
                    Estado = p.Estado,
                    DiasRetraso = p.DiasRetraso,
                    MontoMulta = p.MontoMulta
                });
                
                var libroDb = db.Libros.Find(p.LibroID);
                if (libroDb != null)
                {
                    libroDb.EjemplaresDisponibles--;
                }
                
                db.SaveChanges();
            }
        }

        public void ActualizarPrestamoYLibro(Prestamo p, Libro l)
        {
            using (var db = new BibliotecaDBEntities())
            {
                var prestamoDb = db.Prestamos.Find(p.PrestamoID);
                if (prestamoDb != null)
                {
                    prestamoDb.FechaDevolucionReal = p.FechaDevolucionReal;
                    prestamoDb.Estado = p.Estado;
                    prestamoDb.DiasRetraso = p.DiasRetraso;
                    prestamoDb.MontoMulta = p.MontoMulta;
                }

                if (l != null)
                {
                    var libroDb = db.Libros.Find(l.LibroID);
                    if (libroDb != null)
                    {
                        libroDb.EjemplaresDisponibles = l.EjemplaresDisponibles;
                    }
                }

                db.SaveChanges();
            }
        }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(UcEstudiantes.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ProyectoTesis.Entidades;
using ProyectoTesis.Logica.Interfaces;
using ProyectoTesis.Logica.Servicios;
using ProyectoTesis.Presentacion.Formularios;

namespace ProyectoTesis.Presentacion.Controles
{
    public partial class UcEstudiantes : UserControl
    {
        private readonly Profesor _profesor;
        private readonly FormPrincipal _principal;
        private readonly IEstudianteServicio _estudianteServicio;
        private readonly IInformeServicio _informeServicio;

        public UcEstudiantes(Profesor profesor, FormPrincipal principal)
        {
            InitializeComponent();
            _profesor = profesor;
            _principal = principal;
            _estudianteServicio = new EstudianteServicio();
            _informeServicio = new InformeServicio();
        }

        private void UcEstudiantes_Load(object sender, EventArgs e)
        {
            cboEstado.Items.AddRange(new object[] { "Todos", "En Proceso", "Aprobado" });
            cboEstado.SelectedIndex = 0;
            CargarEstudiantes();
        }

        private void CargarEstudiantes()
        {
            try
            {
                var lista = _estudianteServicio.ObtenerPorProfesor(_profesor.ProfesorId);
                dgvEstudiantes.DataSource = lista.ToList();
                ConfigurarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnas()
        {
            if (dgvEstudiantes.Columns.Count == 0) return;

            var ocultar = new[] { "ProfesorId", "Profesor", "ArchivoResolucion", "HistorialProgresion", "InformeCabecera" };
            foreach (var col in ocultar)
                if (dgvEstudiantes.Columns[col] != null)
                    dgvEstudiantes.Columns[col].Visible = false;

            if (dgvEstudiantes.Columns["EstudianteId"] != null)
                dgvEstudiantes.Columns["EstudianteId"].Visible = false;

            var headerText = new System.Collections.Generic.Dictionary<string, string>
            {
                {"Nombres","Nombres"},{"Apellidos","Apellidos"},{"Cedula","Cedula"},
                {"Carrera","Carrera"},{"TituloTesis","Titulo Tesis"},{"NumeroResolucion","N.Resolucion"},
                {"FechaResolucion","Fecha Res."},{"Estado","Estado"},{"PorcentajeAvance","% Avance"},
                {"FechaRegistro","Fecha Reg."}
            };
            foreach (var kv in headerText)
                if (dgvEstudiantes.Columns[kv.Key] != null)
                    dgvEstudiantes.Columns[kv.Key].HeaderText = kv.Value;

            dgvEstudiantes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string estado = cboEstado.SelectedIndex > 0 ? cboEstado.SelectedItem.ToString() : null;
                DateTime? fd = chkFecha.Checked ? dtpFechaDesde.Value : (DateTime?)null;
                DateTime? fh = chkFecha.Checked ? dtpFechaHasta.Value : (DateTime?)null;

                var lista = _estudianteServicio.BuscarConFiltros(
                    _profesor.ProfesorId, txtNombre.Text.Trim(), txtApellido.Text.Trim(),
                    txtCarrera.Text.Trim(), estado, fd, fh);

                dgvEstudiantes.DataSource = lista.ToList();
                ConfigurarColumnas();
                lblResultados.Text = $"Resultados: {lista.Count()}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en busqueda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear(); txtApellido.Clear(); txtCarrera.Clear();
            cboEstado.SelectedIndex = 0;
            chkFecha.Checked = false;
            lblResultados.Text = "";
            CargarEstudiantes();
        }

        private void ChkFecha_CheckedChanged(object sender, EventArgs e)
        {
            dtpFechaDesde.Enabled = chkFecha.Checked;
            dtpFechaHasta.Enabled = chkFecha.Checked;
        }

        private void BtnNuevoInforme_Click(object sender, EventArgs e)
        {
            if (dgvEstudiantes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un estudiante", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var est = (Estudiante)dgvEstudiantes.SelectedRows[0].DataBoundItem;
            _principal.AbrirControl(new UcNuevoInforme(est, _profesor, _principal));
        }

        private void BtnVerHistorial_Click(object sender, EventArgs e)
        {
            if (dgvEstudiantes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un estudiante", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var est = (Estudiante)dgvEstudiantes.SelectedRows[0].DataBoundItem;
            _principal.AbrirControl(new UcHistorialProgresion(est, _principal));
        }

        private void BtnVerPdf_Click(object sender, EventArgs e)
        {
            if (dgvEstudiantes.SelectedRows.Count == 0) return;
            var est = (Estudiante)dgvEstudiantes.SelectedRows[0].DataBoundItem;

            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Logo PNG|*.png";
                ofd.Title = "Seleccionar logo de la universidad";
                if (ofd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    byte[] pdf;
                    if ((est.PorcentajeAvance ?? 0) >= 100)
                        pdf = _informeServicio.GenerarPdfInformeFinal(est.EstudianteId, ofd.FileName);
                    else
                    {
                        var informes = _informeServicio.ObtenerInformesPorEstudiante(est.EstudianteId).ToList();
                        if (informes.Count == 0)
                        {
                            MessageBox.Show("El estudiante no tiene informes", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        pdf = _informeServicio.GenerarPdfInforme(informes[0].InformeCabeceraId, ofd.FileName);
                    }

                    string ruta = Path.Combine(Path.GetTempPath(), $"Informe_{est.Nombres}_{est.Apellidos}_{DateTime.Now:yyyyMMdd}.pdf");
                    File.WriteAllBytes(ruta, pdf);
                    System.Diagnostics.Process.Start(ruta);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al generar PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(FormularioPrincipal.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;
using System.ComponentModel;
using System.Windows.Forms;
using SistemaVentas.LogicaNegocio;

namespace SistemaVentas.Vista
{
    public partial class FormularioPrincipal : Form
    {
        private GestorVentas? _gestor;

        public FormularioPrincipal()
        {
            InitializeComponent();

            // No ejecutar logica en modo disenador de Visual Studio
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime && !DesignMode)
            {
                _gestor = new GestorVentas();
                this.Load += FormularioPrincipal_Load;
            }
        }

        private void FormularioPrincipal_Load(object? sender, EventArgs e)
        {
            InicializarSistema();
        }

        private void InicializarSistema()
        {
            try
            {
                if (_gestor == null) return;
                int total = _gestor.TotalRegistros();
                lblTotalRegistros.Text = "Total en BD: " + total + " registros";
                lblBarraEstado.Text = "SQL Server conectado | Base de datos: SistemaVentasDB | " + total + " registros";
                if (total > 0) CargarGrid();
            }
            catch (Exception ex)
            {
                lblBarraEstado.Text = "Error al conectar: " + ex.Message;
            }
        }

        // Boton: Ver todas las ventas
        private void BtnVerTodas_Click(object sender, EventArgs e)
        {
            CargarGrid();
            lblEstado.Text = "Mostrando las ultimas 500 ventas";
        }

        // Boton: Reporte por Region
        private void BtnReporteRegion_Click(object sender, EventArgs e)
        {
            if (_gestor == null) return;
            try
            {
                var reporte = _gestor.ObtenerReportePorRegion();
                gridDatos.DataSource = null;
                gridDatos.DataSource = reporte;
                lblEstado.Text = "Reporte agrupado por region - " + reporte.Count + " regiones";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Boton: Reporte por Producto
        private void BtnReporteProducto_Click(object sender, EventArgs e)
        {
            if (_gestor == null) return;
            try
            {
                var reporte = _gestor.ObtenerReportePorProducto();
                gridDatos.DataSource = null;
                gridDatos.DataSource = reporte;
                lblEstado.Text = "Reporte agrupado por producto - " + reporte.Count + " productos";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Boton: Buscar por pais
        private void BtnBuscarPais_Click(object sender, EventArgs e)
        {
            if (_gestor == null || string.IsNullOrWhiteSpace(txtBuscar.Text)) return;
            try
            {
                var ventas = _gestor.BuscarPorPais(txtBuscar.Text.Trim());
                gridDatos.DataSource = null;
                gridDatos.DataSource = ventas;
                lblEstado.Text = "Resultados para pais '" + txtBuscar.Text + "': " + ventas.Count + " ventas";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Boton: Buscar por producto
        private void BtnBuscarProducto_Click(object sender, EventArgs e)
        {
            if (_gestor == null || string.IsNullOrWhiteSpace(txtBuscar.Text)) return;
            try
            {
                var ventas = _gestor.BuscarPorProducto(txtBuscar.Text.Trim());
                gridDatos.DataSource = null;
                gridDatos.DataSource = ventas;
                lblEstado.Text = "Resultados para producto '" + txtBuscar.Text + "': " + ventas.Count + " ventas";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Carga las ventas en el DataGridView
        private void CargarGrid()
        {
            if (_gestor == null) return;
            try
            {
                var ventas = _gestor.ObtenerVentas(500);
                gridDatos.DataSource = null;
                gridDatos.DataSource = ventas;
                int total = _gestor.TotalRegistros();
                lblTotalRegistros.Text = "Total en BD: " + total + " registros";
            }
            catch (Exception ex)
            {
                lblBarraEstado.Text = "Error: " + ex.Message;
            }
        }

        // Boton: Prediccion ML.NET
        private void BtnPrediccionML_Click(object sender, EventArgs e)
        {
            if (_gestor == null) return;
            try
            {
                lblEstado.Text = "Entrenando modelo de IA con 10,000 registros... Por favor espere.";
                Application.DoEvents();

                string pais = string.IsNullOrWhiteSpace(txtBuscar.Text) ? "Mexico" : txtBuscar.Text.Trim();
                string region = "Central America and the Caribbean";
                string producto = "Cosmetics";

                var listaPais = _gestor.BuscarPorPais(pais);
                if (listaPais.Count > 0)
                {
                    region = listaPais[0].Region;
                    producto = listaPais[0].TipoProducto;
                }

                float prediccion = _gestor.PredecirVentasFuturas(region, pais, producto);
                lblEstado.Text = "Prediccion completada.";

                MessageBox.Show($"[ PREDICCION INTELIGENCIA ARTIFICIAL ]\n\n" +
                                $"Pais Analizado: {pais}\n" +
                                $"Region Estimada: {region}\n" +
                                $"Categoria: {producto}\n\n" +
                                $"El modelo ML.NET proyecta que la proxima orden tendra:\n" +
                                $"*** {Math.Round(prediccion)} Unidades Vendidas ***",
                                "Machine Learning ML.NET", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ML.NET: " + ex.Message, "Error");
            }
        }

        private void lblSubtitulo_Click(object sender, EventArgs e)
        {

        }

        private void panelEncabezado_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblBarraEstado_Click(object sender, EventArgs e)
        {

        }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(EstudianteServicio.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;
using System.Collections.Generic;
using System.Linq;
using ProyectoTesis.Entidades;
using ProyectoTesis.Logica.Interfaces;

namespace ProyectoTesis.Logica.Servicios
{
    public class EstudianteServicio : IEstudianteServicio
    {
        private Estudiante MapDatosAEntidad(ProyectoTesis.Datos.Estudiante e)
        {
            if (e == null) return null;
            return new Estudiante
            {
                EstudianteId = e.EstudianteId,
                ProfesorId = e.ProfesorId,
                Nombres = e.Nombres,
                Apellidos = e.Apellidos,
                Cedula = e.Cedula,
                Carrera = e.Carrera,
                TituloTesis = e.TituloTesis,
                NumeroResolucion = e.NumeroResolucion,
                FechaResolucion = e.FechaResolucion,
                ArchivoResolucion = e.ArchivoResolucion,
                Estado = e.Estado,
                PorcentajeAvance = e.PorcentajeAvance,
                FechaRegistro = e.FechaRegistro,
                Profesor = e.Profesor != null ? new Profesor
                {
                    ProfesorId = e.Profesor.ProfesorId,
                    Nombres = e.Profesor.Nombres,
                    Apellidos = e.Profesor.Apellidos,
                    Usuario = e.Profesor.Usuario,
                    Contrasena = e.Profesor.Contrasena,
                    Email = e.Profesor.Email,
                    Activo = e.Profesor.Activo
                } : null
            };
        }

        private ProyectoTesis.Datos.Estudiante MapEntidadADatos(Estudiante e)
        {
            if (e == null) return null;
            return new ProyectoTesis.Datos.Estudiante
            {
                EstudianteId = e.EstudianteId,
                ProfesorId = e.ProfesorId,
                Nombres = e.Nombres,
                Apellidos = e.Apellidos,
                Cedula = e.Cedula,
                Carrera = e.Carrera,
                TituloTesis = e.TituloTesis,
                NumeroResolucion = e.NumeroResolucion,
                FechaResolucion = e.FechaResolucion,
                ArchivoResolucion = e.ArchivoResolucion,
                Estado = e.Estado,
                PorcentajeAvance = e.PorcentajeAvance,
                FechaRegistro = e.FechaRegistro
            };
        }

        private List<ProyectoTesis.Datos.InformeCabecera> MapInformesEntidadADatos(ICollection<InformeCabecera> informes)
        {
            if (informes == null) return null;
            return informes.Select(i => new ProyectoTesis.Datos.InformeCabecera
            {
                InformeCabeceraId = i.InformeCabeceraId,
                EstudianteId = i.EstudianteId,
                ProfesorId = i.ProfesorId,
                NumeroInforme = i.NumeroInforme,
                FechaEmision = i.FechaEmision,
                PorcentajeAcumulado = i.PorcentajeAcumulado,
                Estado = i.Estado,
                EsFinal = i.EsFinal
            }).ToList();
        }

        public IEnumerable<Estudiante> ObtenerPorProfesor(int profesorId)
        {
            using (var uow = new ProyectoTesis.Datos.UnitOfWork())
            {
                return uow.EstudianteRepositorio.ObtenerPorProfesor(profesorId)
                    .Select(e => MapDatosAEntidad(e)).ToList();
            }
        }

        public Estudiante ObtenerPorId(int estudianteId)
        {
            using (var uow = new ProyectoTesis.Datos.UnitOfWork())
            {
                return MapDatosAEntidad(uow.EstudianteRepositorio.ObtenerPorId(estudianteId));
            }
        }

        public IEnumerable<Estudiante> BuscarConFiltros(int profesorId, string nombre = null, string apellido = null, string carrera = null, string estado = null, DateTime? fechaDesde = null, DateTime? fechaHasta = null)
        {
            using (var uow = new ProyectoTesis.Datos.UnitOfWork())
            {
                return uow.EstudianteRepositorio.BuscarConFiltros(profesorId, nombre, apellido, carrera, estado, fechaDesde, fechaHasta)
                    .Select(e => MapDatosAEntidad(e)).ToList();
            }
        }

        public void Agregar(Estudiante estudiante)
        {
            using (var uow = new ProyectoTesis.Datos.UnitOfWork())
            {
                estudiante.FechaRegistro = DateTime.Now;
                estudiante.Estado = "En Proceso";
                if (!estudiante.PorcentajeAvance.HasValue)
                    estudiante.PorcentajeAvance = 0;
                var datos = MapEntidadADatos(estudiante);
                uow.EstudianteRepositorio.Agregar(datos);
                uow.Guardar();
            }
        }

        public void Actualizar(Estudiante estudiante)
        {
            using (var uow = new ProyectoTesis.Datos.UnitOfWork())
            {
                var existente = uow.EstudianteRepositorio.ObtenerPorId(estudiante.EstudianteId);
                if (existente != null)
                {
                    existente.Nombres = estudiante.Nombres;
                    existente.Apellidos = estudiante.Apellidos;
                    existente.Carrera = estudiante.Carrera;
                    existente.TituloTesis = estudiante.TituloTesis;
                    existente.NumeroResolucion = estudiante.NumeroResolucion;
                    existente.FechaResolucion = estudiante.FechaResolucion;
                    if (estudiante.ArchivoResolucion != null)
                        existente.ArchivoResolucion = estudiante.ArchivoResolucion;
                    uow.EstudianteRepositorio.Actualizar(existente);
                    uow.Guardar();
                }
            }
        }

        public void Eliminar(int estudianteId)
        {
            using (var uow = new ProyectoTesis.Datos.UnitOfWork())
            {
                uow.EstudianteRepositorio.Eliminar(estudianteId);
                uow.Guardar();
            }
        }

        public void ActualizarEstado(int estudianteId, string estado, int porcentaje)
        {
            using (var uow = new ProyectoTesis.Datos.UnitOfWork())
            {
                var est = uow.EstudianteRepositorio.ObtenerPorId(estudianteId);
                if (est != null)
                {
                    est.Estado = estado;
                    est.PorcentajeAvance = porcentaje;
                    uow.EstudianteRepositorio.Actualizar(est);
                    uow.Guardar();
                }
            }
        }

        public bool CedulaDisponible(string cedula, int? excluirId = null)
        {
            using (var uow = new ProyectoTesis.Datos.UnitOfWork())
            {
                if (excluirId.HasValue)
                    return !uow.EstudianteRepositorio.Existe(e => e.Cedula == cedula && e.EstudianteId != excluirId.Value);
                return !uow.EstudianteRepositorio.Existe(e => e.Cedula == cedula);
            }
        }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(Form1.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;
using System.Linq;
using System.Windows.Forms;
using LogicaNegocio;
using SolucionBiblioteca.Entidades;

namespace SolucionBiblioteca
{
    public partial class Form1 : Form
    {
        private BibliotecaLogica _logica;

        public Form1()
        {
            InitializeComponent();
            _logica = new BibliotecaLogica();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ActualizarListas();
        }

        private void ActualizarListas()
        {
            dgvLibros.DataSource = null;
            dgvLibros.DataSource = _logica.ObtenerLibros();

            dgvCategorias.DataSource = null;
            dgvCategorias.DataSource = _logica.ObtenerCategorias();

            dgvEstudiantes.DataSource = null;
            dgvEstudiantes.DataSource = _logica.ObtenerEstudiantes();

            dgvPrestamos.DataSource = null;
            dgvPrestamos.DataSource = _logica.ObtenerPrestamos();

            ActualizarComboBoxes();
            CargarGrafica();
        }

        private void ActualizarComboBoxes()
        {
            cmbEstudiante.DataSource = null;
            cmbEstudiante.DataSource = _logica.ObtenerEstudiantes();
            cmbEstudiante.DisplayMember = "NombreCompleto";
            cmbEstudiante.ValueMember = "EstudianteID";

            cmbLibro.DataSource = null;
            cmbLibro.DataSource = _logica.ObtenerLibros().Where(l => l.TieneDisponibilidad()).ToList();
            cmbLibro.DisplayMember = "Titulo";
            cmbLibro.ValueMember = "LibroID";
        }

        private void CargarGrafica()
        {
            var estadisticas = _logica.ObtenerEstadisticasPrestamos();
            chartPrestamos.Series[0].Points.Clear();
            
            foreach (var kvp in estadisticas)
            {
                chartPrestamos.Series[0].Points.AddXY(kvp.Key, kvp.Value);
            }
        }
        
        private void btnAgregarLibro_Click(object sender, EventArgs e)
        {
            try
            {
                var libro = new Libro
                {
                    ISBN = txtISBN.Text,
                    Titulo = txtTitulo.Text,
                    Autor = txtAutor.Text,
                    EjemplaresTotales = (int)numEjemplares.Value,
                    EjemplaresDisponibles = (int)numEjemplares.Value
                };
                
                _logica.RegistrarLibro(libro);
                MessageBox.Show("Libro agregado exitosamente");
                ActualizarListas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

       
        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                var categoria = new Categoria(txtCatNombre.Text, txtCatDesc.Text);
                _logica.RegistrarCategoria(categoria);
                
                MessageBox.Show("CategorÃ­a agregada exitosamente");
                ActualizarListas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        
        private void btnAgregarEstudiante_Click(object sender, EventArgs e)
        {
            try
            {
                var estudiante = new Estudiante(txtMatricula.Text, txtEstNombre.Text, txtEstApellido.Text, txtCarrera.Text, (int)numSemestre.Value);
                _logica.RegistrarEstudiante(estudiante);
                
                MessageBox.Show("Estudiante agregado exitosamente");
                ActualizarListas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        // PRESTAMOS
        private void btnPrestar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbLibro.SelectedValue == null || cmbEstudiante.SelectedValue == null)
                    throw new Exception("Debe seleccionar un estudiante y un libro");

                int libroId = (int)cmbLibro.SelectedValue;
                int estudianteId = (int)cmbEstudiante.SelectedValue;

                _logica.PrestarLibro(libroId, estudianteId);
                MessageBox.Show("PrÃ©stamo registrado exitosamente");
                ActualizarListas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPrestamos.CurrentRow == null)
                    throw new Exception("Seleccione un prÃ©stamo de la tabla para devolver");

                var prestamo = (Prestamo)dgvPrestamos.CurrentRow.DataBoundItem;
                if (prestamo.Estado != "ACTIVO")
                    throw new Exception("Este prÃ©stamo ya fue devuelto o procesado");

                _logica.DevolverLibro(prestamo.PrestamoID);
                
                string mensaje = "Libro devuelto exitosamente. ";
                if (prestamo.MontoMulta > 0)
                    mensaje += $"El estudiante tiene una multa de ${prestamo.MontoMulta}";
                    
                MessageBox.Show(mensaje, "DevoluciÃ³n");
                ActualizarListas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void chartPrestamos_Click(object sender, EventArgs e)
        {

        }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(UcNuevoInforme.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ProyectoTesis.Entidades;
using ProyectoTesis.Logica.Interfaces;
using ProyectoTesis.Logica.Servicios;

namespace ProyectoTesis.Presentacion.Controles
{
    public partial class UcNuevoInforme : UserControl
    {
        private readonly Estudiante _estudiante;
        private readonly Profesor _profesor;
        private readonly FormPrincipal _principal;
        private readonly IInformeServicio _informeServicio;
        private BindingSource _bsDetalles;

        public UcNuevoInforme(Estudiante estudiante, Profesor profesor, FormPrincipal principal)
        {
            InitializeComponent();
            _estudiante = estudiante;
            _profesor = profesor;
            _principal = principal;
            _informeServicio = new InformeServicio();
        }

        private void UcNuevoInforme_Load(object sender, EventArgs e)
        {
            lblEstudiante.Text = $"{_estudiante.Nombres} {_estudiante.Apellidos} - {_estudiante.TituloTesis}";
            _bsDetalles = new BindingSource();
            AgregarFilaVacia();
            ActualizarTotal();
        }

        private void AgregarFilaVacia()
        {
            var lista = _bsDetalles.DataSource as List<InformeDetalleViewModel>;
            if (lista == null) lista = new List<InformeDetalleViewModel>();
            lista.Add(new InformeDetalleViewModel());
            _bsDetalles.DataSource = lista;
            dgvActividades.DataSource = _bsDetalles;
            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            if (dgvActividades.Columns.Count == 0) return;
            dgvActividades.Columns["DescripcionActividad"].HeaderText = "Actividad";
            dgvActividades.Columns["DescripcionActividad"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvActividades.Columns["PorcentajeActividad"].HeaderText = "% Avance";
            dgvActividades.Columns["PorcentajeActividad"].Width = 90;
        }

        private void BtnAgregarActividad_Click(object sender, EventArgs e)
        {
            AgregarFilaVacia();
        }

        private void BtnQuitarActividad_Click(object sender, EventArgs e)
        {
            if (dgvActividades.CurrentRow == null) return;
            var lista = (List<InformeDetalleViewModel>)_bsDetalles.DataSource;
            if (lista.Count <= 1) return;
            int idx = dgvActividades.CurrentRow.Index;
            if (idx >= 0 && idx < lista.Count)
            {
                lista.RemoveAt(idx);
                _bsDetalles.ResetBindings(false);
            }
        }

        private void DgvActividades_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ActualizarTotal();
        }

        private void DgvActividades_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void ActualizarTotal()
        {
            var lista = _bsDetalles?.DataSource as List<InformeDetalleViewModel>;
            if (lista == null) return;
            int total = lista.Where(x => x.PorcentajeActividad.HasValue).Sum(x => x.PorcentajeActividad.Value);
            lblTotal.Text = $"Total: {total}%";
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            var modelos = _bsDetalles.DataSource as List<InformeDetalleViewModel>;
            if (modelos == null || modelos.Count == 0 ||
                modelos.Any(d => string.IsNullOrWhiteSpace(d.DescripcionActividad) ||
                                 !d.PorcentajeActividad.HasValue ||
                                 d.PorcentajeActividad < 0 || d.PorcentajeActividad > 100))
            {
                MessageBox.Show("Complete todas las actividades con % entre 0 y 100", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (modelos.Sum(d => d.PorcentajeActividad.Value) > 100)
            {
                MessageBox.Show("La suma de porcentajes no puede superar 100%", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var detalles = new List<InformeDetalle>();
                for (int i = 0; i < modelos.Count; i++)
                {
                    detalles.Add(new InformeDetalle
                    {
                        NumeroActividad = i + 1,
                        DescripcionActividad = modelos[i].DescripcionActividad,
                        PorcentajeActividad = modelos[i].PorcentajeActividad.Value
                    });
                }

                _informeServicio.CrearInforme(_estudiante.EstudianteId, _profesor.ProfesorId, detalles);

                MessageBox.Show("Informe guardado correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _principal.AbrirControl(new UcEstudiantes(_profesor, _principal));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            _principal.AbrirControl(new UcEstudiantes(_profesor, _principal));
        }
    }

    public class InformeDetalleViewModel
    {
        public string DescripcionActividad { get; set; }
        public int? PorcentajeActividad { get; set; }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(FormEstudiante.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ProyectoTesis.Entidades;
using ProyectoTesis.Logica.Servicios;

namespace ProyectoTesis.Presentacion.Formularios
{
    public partial class FormEstudiante : Form
    {
        private readonly int _profesorId;
        private readonly int? _estudianteId;
        private readonly EstudianteServicio _servicio;
        private byte[] _archivoSeleccionado;

        public FormEstudiante(int profesorId, int? estudianteId = null)
        {
            InitializeComponent();
            _profesorId = profesorId;
            _estudianteId = estudianteId;
            _servicio = new EstudianteServicio();
        }

        private void FormEstudiante_Load(object sender, EventArgs e)
        {
            if (_estudianteId.HasValue)
            {
                this.Text = "Editar Estudiante";
                CargarDatos(_estudianteId.Value);
            }
        }

        private void CargarDatos(int id)
        {
            var est = _servicio.ObtenerPorId(id);
            if (est == null) return;

            txtNombres.Text = est.Nombres;
            txtApellidos.Text = est.Apellidos;
            txtCedula.Text = est.Cedula;
            txtCarrera.Text = est.Carrera;
            txtTituloTesis.Text = est.TituloTesis;
            txtNumeroResolucion.Text = est.NumeroResolucion;
            dtpFechaResolucion.Value = est.FechaResolucion;
            if (est.ArchivoResolucion != null)
            {
                _archivoSeleccionado = est.ArchivoResolucion;
                lblArchivo.Text = "Archivo cargado";
                lblArchivo.ForeColor = Color.Green;
            }
        }

        private void BtnExaminar_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivos PDF|*.pdf";
                ofd.Title = "Seleccionar resolucion (PDF)";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _archivoSeleccionado = File.ReadAllBytes(ofd.FileName);
                    lblArchivo.Text = Path.GetFileName(ofd.FileName);
                    lblArchivo.ForeColor = Color.Green;
                }
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            try
            {
                if (_estudianteId.HasValue)
                {
                    var est = new Estudiante
                    {
                        EstudianteId = _estudianteId.Value,
                        Nombres = txtNombres.Text.Trim(),
                        Apellidos = txtApellidos.Text.Trim(),
                        Cedula = txtCedula.Text.Trim(),
                        Carrera = txtCarrera.Text.Trim(),
                        TituloTesis = txtTituloTesis.Text.Trim(),
                        NumeroResolucion = txtNumeroResolucion.Text.Trim(),
                        FechaResolucion = dtpFechaResolucion.Value,
                        ArchivoResolucion = _archivoSeleccionado
                    };
                    _servicio.Actualizar(est);
                }
                else
                {
                    var est = new Estudiante
                    {
                        ProfesorId = _profesorId,
                        Nombres = txtNombres.Text.Trim(),
                        Apellidos = txtApellidos.Text.Trim(),
                        Cedula = txtCedula.Text.Trim(),
                        Carrera = txtCarrera.Text.Trim(),
                        TituloTesis = txtTituloTesis.Text.Trim(),
                        NumeroResolucion = txtNumeroResolucion.Text.Trim(),
                        FechaResolucion = dtpFechaResolucion.Value,
                        ArchivoResolucion = _archivoSeleccionado
                    };
                    _servicio.Agregar(est);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNombres.Text) ||
                string.IsNullOrWhiteSpace(txtApellidos.Text) ||
                string.IsNullOrWhiteSpace(txtCedula.Text) ||
                string.IsNullOrWhiteSpace(txtCarrera.Text) ||
                string.IsNullOrWhiteSpace(txtTituloTesis.Text) ||
                string.IsNullOrWhiteSpace(txtNumeroResolucion.Text))
            {
                MessageBox.Show("Complete todos los campos", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!_servicio.CedulaDisponible(txtCedula.Text.Trim(), _estudianteId))
            {
                MessageBox.Show("La cedula ya esta registrada", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(EstudianteNEG.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DatosADO;
using Entidades;

namespace Negocio
{
    public class EstudianteNEG
    {
  
        public static Respuesta Insertar(Estudiante e)
        {
            try
            {
                Respuesta validacion = Validar(e);
                if (!validacion.Exitoso) return validacion;

                bool resultado = EstudianteDAL.Insertar(e);
                return resultado
                    ? Respuesta.Ok("Estudiante registrado correctamente.")
                    : Respuesta.Error("No se pudo registrar el estudiante.");
            }
            catch (Exception ex)
            {
                return Respuesta.Error("Error: " + ex.Message);
            }
        }

        public static Respuesta ObtenerTodos()
        {
            try
            {
                List<Estudiante> lista = EstudianteDAL.ObtenerTodos();
                return Respuesta.Ok("OK", lista);
            }
            catch (Exception ex)
            {
                return Respuesta.Error("Error: " + ex.Message);
            }
        }

        public static Respuesta Buscar(string termino)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(termino))
                    return ObtenerTodos();

                List<Estudiante> lista = EstudianteDAL.Buscar(termino.Trim());
                return Respuesta.Ok("OK", lista);
            }
            catch (Exception ex)
            {
                return Respuesta.Error("Error: " + ex.Message);
            }
        }

        public static Respuesta Actualizar(Estudiante e)
        {
            try
            {
                if (e.Id <= 0)
                    return Respuesta.Error("ID invalido para actualizar.");

                Respuesta validacion = Validar(e);
                if (!validacion.Exitoso) return validacion;

                bool resultado = EstudianteDAL.Actualizar(e);
                return resultado
                    ? Respuesta.Ok("Estudiante actualizado correctamente.")
                    : Respuesta.Error("No se pudo actualizar el estudiante.");
            }
            catch (Exception ex)
            {
                return Respuesta.Error("Error: " + ex.Message);
            }
        }

        public static Respuesta Eliminar(int id)
        {
            try
            {
                if (id <= 0)
                    return Respuesta.Error("ID invalido para eliminar.");

                bool resultado = EstudianteDAL.Eliminar(id);
                return resultado
                    ? Respuesta.Ok("Estudiante eliminado correctamente.")
                    : Respuesta.Error("No se encontro el estudiante a eliminar.");
            }
            catch (Exception ex)
            {
                return Respuesta.Error("Error: " + ex.Message);
            }
        }


        private static Respuesta Validar(Estudiante e)
        {
            if (e == null)
                return Respuesta.Error("El objeto estudiante no puede ser nulo.");
            if (string.IsNullOrWhiteSpace(e.Cedula))
                return Respuesta.Error("La cedula es obligatoria.");
            if (e.Cedula.Trim().Length != 10)
                return Respuesta.Error("La cedula debe tener exactamente 10 digitos.");
            if (!Regex.IsMatch(e.Cedula.Trim(), @"^\d{10}$"))
                return Respuesta.Error("La cedula solo debe contener numeros.");
            if (string.IsNullOrWhiteSpace(e.Nombres))
                return Respuesta.Error("El nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(e.Apellidos))
                return Respuesta.Error("El apellido es obligatorio.");
            if (string.IsNullOrWhiteSpace(e.Email))
                return Respuesta.Error("El email es obligatorio.");
            if (!Regex.IsMatch(e.Email.Trim(),
                @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                return Respuesta.Error("El formato del email no es valido.");
            if (string.IsNullOrWhiteSpace(e.Carrera))
                return Respuesta.Error("La carrera es obligatoria.");
            return Respuesta.Ok();
        }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(GestorViaje.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;
using System.Collections.Generic;
using PredictorTarifa.Datos;
using PredictorTarifa.Entidades;

namespace PredictorTarifa.Negocio
{
    // Gestor de viajes: orquesta la logica entre la Vista, el Servicio ML y el Repositorio de datos
    public class GestorViaje
    {
        private readonly ServicioML _servicioML;
        private readonly RepositorioViaje _repositorioViaje;

        public GestorViaje()
        {
            _servicioML = new ServicioML();
            _repositorioViaje = new RepositorioViaje();
        }

        // Entrena el modelo de ML con el CSV historico
        public string EntrenarModelo()
        {
            return _servicioML.EntrenarModelo();
        }

        // Predice la tarifa y guarda el viaje en la base de datos SQL Server
        public ResultadoOperacion PredecirYGuardar(
            string empresa,
            float codigoTarifa,
            float numeroPasajeros,
            float duracionSegundos,
            float distanciaMillas,
            string tipoPago)
        {
            try
            {
                if (!_servicioML.EstaEntrenado())
                    return new ResultadoOperacion
                    {
                        Exitoso = false,
                        Mensaje = "El modelo aun no ha sido entrenado. Haga clic en Entrenar primero."
                    };

                // Crear el objeto de entrada para el modelo ML
                var datosViaje = new ViajeML
                {
                    Empresa = empresa,
                    CodigoTarifa = codigoTarifa,
                    NumeroPasajeros = numeroPasajeros,
                    DuracionSegundos = duracionSegundos,
                    DistanciaMillas = distanciaMillas,
                    TipoPago = tipoPago,
                    TarifaReal = 0
                };

                // Obtener la prediccion del modelo ML
                float tarifaPredicha = _servicioML.PredecirTarifa(datosViaje);

                // Crear el registro completo para guardar en SQL Server
                var viaje = new Viaje
                {
                    Empresa = empresa,
                    CodigoTarifa = codigoTarifa,
                    NumeroPasajeros = numeroPasajeros,
                    DuracionSegundos = duracionSegundos,
                    DistanciaMillas = distanciaMillas,
                    TipoPago = tipoPago,
                    TarifaReal = 0,
                    TarifaPredicha = tarifaPredicha,
                    FechaRegistro = DateTime.Now
                };

                // Persistir en la base de datos mediante Entity Framework
                _repositorioViaje.GuardarViaje(viaje);

                return new ResultadoOperacion
                {
                    Exitoso = true,
                    TarifaPredicha = tarifaPredicha,
                    ViajeId = viaje.Id,
                    Mensaje = string.Format(
                        "Tarifa estimada: ${0:F2}\nViaje guardado en BD con ID: {1}",
                        tarifaPredicha,
                        viaje.Id
                    )
                };
            }
            catch (Exception ex)
            {
                return new ResultadoOperacion
                {
                    Exitoso = false,
                    Mensaje = "Error al procesar la operacion: " + ex.Message
                };
            }
        }

        // Obtiene el historial de viajes desde la base de datos
        public List<Viaje> ObtenerHistorial(int cantidad = 50)
        {
            return _repositorioViaje.ObtenerUltimos(cantidad);
        }

        // Devuelve el total de viajes guardados en la BD
        public int TotalViajesGuardados()
        {
            return _repositorioViaje.ContarViajes();
        }
    }

    // Clase de resultado para la comunicacion entre la Vista y el Gestor
    public class ResultadoOperacion
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
        public float TarifaPredicha { get; set; }
        public int ViajeId { get; set; }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(ServicioML.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;
using System.IO;
using Microsoft.ML;
using Microsoft.ML.Data;
using PredictorTarifa.Entidades;

namespace PredictorTarifa.Negocio
{
    // Servicio de Machine Learning: entrena el modelo con el CSV y realiza predicciones
    public class ServicioML
    {
        private readonly MLContext _contextoML;
        private ITransformer _modelo;
        private bool _modeloEntrenado = false;

        // Ruta del archivo CSV de entrenamiento
        private static readonly string RutaCSVEntrenamiento =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "taxi-fare-train.csv");

        public ServicioML()
        {
            _contextoML = new MLContext(seed: 0);
        }

        // Entrena el modelo con el CSV de datos historicos de taxis
        public string EntrenarModelo()
        {
            try
            {
                if (!File.Exists(RutaCSVEntrenamiento))
                    return "ERROR: No se encontro el archivo CSV de entrenamiento en: " + RutaCSVEntrenamiento;

                // Cargar datos del CSV (tiene encabezado, separado por coma)
                var datosEntrenamiento = _contextoML.Data.LoadFromTextFile<ViajeML>(
                    RutaCSVEntrenamiento,
                    hasHeader: true,
                    separatorChar: ','
                );

                // Definir el pipeline de transformacion y algoritmo de regresion
                var pipeline = _contextoML.Transforms
                    .CopyColumns(outputColumnName: "Label", inputColumnName: "Label")
                    .Append(_contextoML.Transforms.Categorical.OneHotEncoding("EmpresaCod", "Empresa"))
                    .Append(_contextoML.Transforms.Categorical.OneHotEncoding("TipoPagoCod", "TipoPago"))
                    .Append(_contextoML.Transforms.Concatenate("Features",
                        "EmpresaCod",
                        "CodigoTarifa",
                        "NumeroPasajeros",
                        "DuracionSegundos",
                        "DistanciaMillas",
                        "TipoPagoCod"
                    ))
                    .Append(_contextoML.Transforms.NormalizeMinMax("Features"))
                    .Append(_contextoML.Regression.Trainers.FastTree());

                // Entrenar el modelo con los datos del CSV
                _modelo = pipeline.Fit(datosEntrenamiento);
                _modeloEntrenado = true;

                // Evaluar la precision del modelo con los datos de entrenamiento
                var predicciones = _modelo.Transform(datosEntrenamiento);
                var metricas = _contextoML.Regression.Evaluate(predicciones, "Label", "Score");

                return string.Format(
                    "Modelo entrenado correctamente.\nR2: {0:P2} | Error Absoluto Medio: ${1:F2} | RMSE: ${2:F2}",
                    metricas.RSquared,
                    metricas.MeanAbsoluteError,
                    metricas.RootMeanSquaredError
                );
            }
            catch (Exception ex)
            {
                return "ERROR al entrenar el modelo: " + ex.Message;
            }
        }

        // Predice la tarifa de un viaje en base a sus datos
        public float PredecirTarifa(ViajeML datosViaje)
        {
            if (!_modeloEntrenado)
                throw new InvalidOperationException("El modelo no ha sido entrenado todavia.");

            var motorPrediccion = _contextoML.Model.CreatePredictionEngine<ViajeML, PrediccionTarifa>(_modelo);
            var resultado = motorPrediccion.Predict(datosViaje);

            // Asegurar que la tarifa predicha no sea negativa
            return Math.Max(0f, resultado.TarifaPredicha);
        }

        public bool EstaEntrenado()
        {
            return _modeloEntrenado;
        }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(Class1.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;
using System.Collections.Generic;
using System.Linq;
using SolucionBiblioteca.Entidades;
using Datos;

namespace LogicaNegocio
{
    public class BibliotecaLogica
    {
        private Repositorio _repo = Repositorio.Instancia;

        public void RegistrarLibro(Libro libro)
        {
            if (string.IsNullOrEmpty(libro.ISBN) || string.IsNullOrEmpty(libro.Titulo))
                throw new ArgumentException("ISBN y Titulo son obligatorios");
                
            _repo.AgregarLibro(libro);
        }

        public void RegistrarEstudiante(Estudiante estudiante)
        {
            if (string.IsNullOrEmpty(estudiante.Matricula))
                throw new ArgumentException("Matricula obligatoria");
                
            _repo.AgregarEstudiante(estudiante);
        }

        public void RegistrarCategoria(Categoria categoria)
        {
            if (string.IsNullOrEmpty(categoria.Nombre))
                throw new ArgumentException("El nombre es obligatorio");

            _repo.AgregarCategoria(categoria);
        }

        public Prestamo PrestarLibro(int libroId, int estudianteId)
        {
            var libro = _repo.Libros.FirstOrDefault(l => l.LibroID == libroId);
            var estudiante = _repo.Estudiantes.FirstOrDefault(e => e.EstudianteID == estudianteId);

            if (libro == null || estudiante == null)
                throw new Exception("Libro o estudiante no encontrado");

            if (!libro.TieneDisponibilidad())
                throw new Exception("No hay ejemplares disponibles");
            
            var prestamo = new Prestamo(libro, estudiante);
            _repo.RegistrarPrestamo(prestamo);
            
            return prestamo;
        }

        public void DevolverLibro(int prestamoId)
        {
            var prestamo = _repo.Prestamos.FirstOrDefault(p => p.PrestamoID == prestamoId);
            if (prestamo == null || prestamo.Estado != "ACTIVO")
                throw new Exception("PrÃ©stamo no vÃ¡lido");

            prestamo.FechaDevolucionReal = DateTime.Now;
            prestamo.CalcularMulta();
            if (prestamo.MontoMulta == 0)
                prestamo.Estado = "DEVUELTO";
                
            var libro = _repo.Libros.FirstOrDefault(l => l.LibroID == prestamo.LibroID);
            if (libro != null)
            {
                libro.EjemplaresDisponibles++;
            }
            
            _repo.ActualizarPrestamoYLibro(prestamo, libro);
        }

        public List<Libro> ObtenerLibros() => _repo.Libros;
        public List<Estudiante> ObtenerEstudiantes() => _repo.Estudiantes;
        public List<Prestamo> ObtenerPrestamos() => _repo.Prestamos;
        public List<Categoria> ObtenerCategorias() => _repo.Categorias;

        public Dictionary<string, int> ObtenerEstadisticasPrestamos()
        {
            var estadisticas = new Dictionary<string, int>();
            var prestamos = _repo.Prestamos;
            
            estadisticas["ACTIVO"] = prestamos.Count(p => p.Estado == "ACTIVO");
            estadisticas["DEVUELTO"] = prestamos.Count(p => p.Estado == "DEVUELTO");
            estadisticas["CON_MULTA"] = prestamos.Count(p => p.Estado == "CON_MULTA");
            
            return estadisticas;
        }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(UcHistorialProgresion.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;
using System.Linq;
using System.Windows.Forms;
using ProyectoTesis.Entidades;
using ProyectoTesis.Logica.Servicios;

namespace ProyectoTesis.Presentacion.Controles
{
    public partial class UcHistorialProgresion : UserControl
    {
        private readonly Estudiante _estudiante;
        private readonly FormPrincipal _principal;
        private readonly HistorialServicio _historialServicio;

        public UcHistorialProgresion(Estudiante estudiante, FormPrincipal principal)
        {
            InitializeComponent();
            _estudiante = estudiante;
            _principal = principal;
            _historialServicio = new HistorialServicio();
        }

        private void UcHistorialProgresion_Load(object sender, EventArgs e)
        {
            lblEstudiante.Text = $"{_estudiante.Nombres} {_estudiante.Apellidos} - {_estudiante.TituloTesis}";
            lblPorcentaje.Text = $"Progreso Actual: {_estudiante.PorcentajeAvance ?? 0}%";
            CargarHistorial();
        }

        private void CargarHistorial()
        {
            try
            {
                var historial = _historialServicio.ObtenerPorEstudiante(_estudiante.EstudianteId).ToList();
                dgvHistorial.DataSource = historial;
                ConfigurarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar historial: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnas()
        {
            if (dgvHistorial.Columns.Count == 0) return;
            if (dgvHistorial.Columns["HistorialId"] != null) dgvHistorial.Columns["HistorialId"].Visible = false;
            if (dgvHistorial.Columns["EstudianteId"] != null) dgvHistorial.Columns["EstudianteId"].Visible = false;
            if (dgvHistorial.Columns["Estudiante"] != null) dgvHistorial.Columns["Estudiante"].Visible = false;
            if (dgvHistorial.Columns["InformeCabeceraId"] != null) dgvHistorial.Columns["InformeCabeceraId"].Visible = false;
            if (dgvHistorial.Columns["InformeCabecera"] != null) dgvHistorial.Columns["InformeCabecera"].Visible = false;

            var headers = new System.Collections.Generic.Dictionary<string, string>
            {
                {"FechaInforme","Fecha Informe"},{"PorcentajeEnInforme","% en Informe"},
                {"EstadoEnInforme","Estado"},{"ResumenActividades","Actividades"}
            };
            foreach (var kv in headers)
                if (dgvHistorial.Columns[kv.Key] != null)
                    dgvHistorial.Columns[kv.Key].HeaderText = kv.Value;
            dgvHistorial.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            _principal.AbrirControl(new UcEstudiantes(_principal.ProfesorActual, _principal));
        }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(MachineLearning.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Data;
using SistemaVentas.Entidades;

namespace SistemaVentas.LogicaNegocio
{
    // Clase que mapea los datos de entrada para la IA
    public class DatosVentaML
    {
        [LoadColumn(0)] public string Region { get; set; }
        [LoadColumn(1)] public string Pais { get; set; }
        [LoadColumn(2)] public string TipoProducto { get; set; }
        [LoadColumn(3)] public float UnidadesVendidas { get; set; }
    }

    // Clase que recibe la prediccion de la IA
    public class PrediccionVentaML
    {
        [ColumnName("Score")]
        public float UnidadesProyectadas { get; set; }
    }

    // Motor principal de Inteligencia Artificial
    public class PredictorVentas
    {
        private readonly MLContext _mlContext;
        private ITransformer _modelo;

        public PredictorVentas()
        {
            _mlContext = new MLContext(seed: 0);
        }

        public void EntrenarModelo(List<Venta> datosHistoricos)
        {
            // Convertir las ventas de ADO.NET a la estructura de la IA
            var datos = datosHistoricos.Select(v => new DatosVentaML
            {
                Region = v.Region,
                Pais = v.Pais,
                TipoProducto = v.TipoProducto,
                UnidadesVendidas = (float)v.UnidadesVendidas
            });

            // Cargar los 10,000 registros a la memoria del algoritmo
            IDataView dataView = _mlContext.Data.LoadFromEnumerable(datos);

            // Pipeline: Codificar textos y usar regresion con FastTree
            var pipeline = _mlContext.Transforms.Categorical.OneHotEncoding(new[]
                {
                    new InputOutputColumnPair("RegionEncoded", "Region"),
                    new InputOutputColumnPair("PaisEncoded", "Pais"),
                    new InputOutputColumnPair("TipoProductoEncoded", "TipoProducto")
                })
                .Append(_mlContext.Transforms.Concatenate("Features", "RegionEncoded", "PaisEncoded", "TipoProductoEncoded"))
                .Append(_mlContext.Regression.Trainers.FastTree(labelColumnName: "UnidadesVendidas", featureColumnName: "Features"));

            // Â¡Entrenamiento!
            _modelo = pipeline.Fit(dataView);
        }

        public float Predecir(string region, string pais, string producto)
        {
            if (_modelo == null) throw new Exception("El modelo no ha sido entrenado aun.");

            var engine = _mlContext.Model.CreatePredictionEngine<DatosVentaML, PrediccionVentaML>(_modelo);
            var entrada = new DatosVentaML { Region = region, Pais = pais, TipoProducto = producto };
            
            // Prediccion matematica real
            var prediccion = engine.Predict(entrada);
            return prediccion.UnidadesProyectadas;
        }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(HistorialServicio.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System.Collections.Generic;
using System.Linq;
using ProyectoTesis.Entidades;
using ProyectoTesis.Logica.Interfaces;

namespace ProyectoTesis.Logica.Servicios
{
    public class HistorialServicio : IHistorialServicio
    {
        private HistorialProgresion MapDatosAEntidad(ProyectoTesis.Datos.HistorialProgresion h)
        {
            if (h == null) return null;
            return new HistorialProgresion
            {
                HistorialId = h.HistorialId,
                EstudianteId = h.EstudianteId,
                InformeCabeceraId = h.InformeCabeceraId,
                FechaInforme = h.FechaInforme,
                PorcentajeEnInforme = h.PorcentajeEnInforme,
                EstadoEnInforme = h.EstadoEnInforme,
                ResumenActividades = h.ResumenActividades
            };
        }

        public IEnumerable<HistorialProgresion> ObtenerPorEstudiante(int estudianteId)
        {
            using (var uow = new ProyectoTesis.Datos.UnitOfWork())
            {
                return uow.HistorialRepositorio.ObtenerPorEstudiante(estudianteId)
                    .Select(h => MapDatosAEntidad(h)).ToList();
            }
        }

        public void RegistrarProgresion(InformeCabecera informe)
        {
            using (var uow = new ProyectoTesis.Datos.UnitOfWork())
            {
                string resumen = string.Join("; ",
                    informe.InformeDetalle.Select(d => $"{d.DescripcionActividad} ({d.PorcentajeActividad}%)"));

                var historial = new ProyectoTesis.Datos.HistorialProgresion
                {
                    EstudianteId = informe.EstudianteId,
                    InformeCabeceraId = informe.InformeCabeceraId,
                    FechaInforme = informe.FechaEmision,
                    PorcentajeEnInforme = informe.PorcentajeAcumulado,
                    EstadoEnInforme = informe.Estado,
                    ResumenActividades = resumen
                };

                uow.HistorialRepositorio.Agregar(historial);
                uow.Guardar();

                if (informe.EsFinal == true)
                {
                    var estudiante = uow.EstudianteRepositorio.ObtenerPorId(informe.EstudianteId);
                    if (estudiante != null)
                    {
                        estudiante.Estado = "Aprobado";
                        estudiante.PorcentajeAvance = 100;
                        uow.EstudianteRepositorio.Actualizar(estudiante);
                        uow.Guardar();
                    }
                }
            }
        }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(ContextoBDModelSnapshot.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharp// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PredictorTarifa.Datos;

#nullable disable

namespace PredictorTarifa.Datos.Migrations
{
    [DbContext(typeof(ContextoBD))]
    partial class ContextoBDModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PredictorTarifa.Entidades.Viaje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("CodigoTarifa")
                        .HasColumnType("real");

                    b.Property<float>("DistanciaMillas")
                        .HasColumnType("real");

                    b.Property<float>("DuracionSegundos")
                        .HasColumnType("real");

                    b.Property<string>("Empresa")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("FechaRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<float>("NumeroPasajeros")
                        .HasColumnType("real");

                    b.Property<float>("TarifaPredicha")
                        .HasColumnType("real");

                    b.Property<float>("TarifaReal")
                        .HasColumnType("real");

                    b.Property<string>("TipoPago")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Id");

                    b.ToTable("Viajes", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(GestorVentas.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;
using System.Collections.Generic;
using SistemaVentas.Datos;
using SistemaVentas.Entidades;

namespace SistemaVentas.LogicaNegocio
{
    // Gestor principal: orquesta la logica entre la Vista y la capa de Datos
    public class GestorVentas
    {
        private readonly RepositorioVenta _repositorio;

        public GestorVentas()
        {
            _repositorio = new RepositorioVenta();
        }

        // Obtiene las ventas para mostrar en el grid
        public List<Venta> ObtenerVentas(int cantidad = 500)
        {
            return _repositorio.ObtenerTodas(cantidad);
        }

        // Busca ventas por pais
        public List<Venta> BuscarPorPais(string pais)
        {
            return _repositorio.BuscarPorPais(pais);
        }

        // Busca ventas por tipo de producto
        public List<Venta> BuscarPorProducto(string tipoProducto)
        {
            return _repositorio.BuscarPorProducto(tipoProducto);
        }

        // Inserta una venta nueva
        public int AgregarVenta(Venta venta)
        {
            return _repositorio.Insertar(venta);
        }

        // Elimina una venta
        public bool EliminarVenta(int id)
        {
            return _repositorio.Eliminar(id);
        }

        // Cuenta el total de registros en la BD
        public int TotalRegistros()
        {
            return _repositorio.ContarTotal();
        }

        // Reporte por region
        public List<ReporteRegion> ObtenerReportePorRegion()
        {
            return _repositorio.ReportePorRegion();
        }

        // Reporte por producto
        public List<ReporteProducto> ObtenerReportePorProducto()
        {
            return _repositorio.ReportePorProducto();
        }

        // ---------- MACHINE LEARNING ML.NET ----------
        private PredictorVentas? _predictor;
        private bool _modeloEntrenado = false;

        public float PredecirVentasFuturas(string region, string pais, string producto)
        {
            if (!_modeloEntrenado)
            {
                _predictor = new PredictorVentas();
                // Traemos una muestra representativa de 10,000 registros de SQL Server
                var todasLasVentas = _repositorio.ObtenerTodas(10000); 
                _predictor.EntrenarModelo(todasLasVentas);
                _modeloEntrenado = true;
            }
            if (_predictor == null) return 0;
            return _predictor.Predecir(region, pais, producto);
        }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(UnitOfWork.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;
using ProyectoTesis.Datos.Repositorios;

namespace ProyectoTesis.Datos
{
    public class UnitOfWork : IDisposable
    {
        private readonly SistemaTesisEntities _context;
        private bool _disposed;

        public UnitOfWork()
        {
            _context = new SistemaTesisEntities();
        }

        public UnitOfWork(SistemaTesisEntities context)
        {
            _context = context;
        }

        private ProfesorRepositorio _profesorRepositorio;
        private EstudianteRepositorio _estudianteRepositorio;
        private InformeCabeceraRepositorio _informeCabeceraRepositorio;
        private InformeDetalleRepositorio _informeDetalleRepositorio;
        private HistorialRepositorio _historialRepositorio;

        public ProfesorRepositorio ProfesorRepositorio =>
            _profesorRepositorio ?? (_profesorRepositorio = new ProfesorRepositorio(_context));

        public EstudianteRepositorio EstudianteRepositorio =>
            _estudianteRepositorio ?? (_estudianteRepositorio = new EstudianteRepositorio(_context));

        public InformeCabeceraRepositorio InformeCabeceraRepositorio =>
            _informeCabeceraRepositorio ?? (_informeCabeceraRepositorio = new InformeCabeceraRepositorio(_context));

        public InformeDetalleRepositorio InformeDetalleRepositorio =>
            _informeDetalleRepositorio ?? (_informeDetalleRepositorio = new InformeDetalleRepositorio(_context));

        public HistorialRepositorio HistorialRepositorio =>
            _historialRepositorio ?? (_historialRepositorio = new HistorialRepositorio(_context));

        public SistemaTesisEntities ObtenerContexto()
        {
            return _context;
        }

        public int Guardar()
        {
            return _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(Estudiante.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharp//------------------------------------------------------------------------------
// <auto-generated>
//     Este cÃ³digo se generÃ³ a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicaciÃ³n.
//     Los cambios manuales en este archivo se sobrescribirÃ¡n si se regenera el cÃ³digo.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoTesis.Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Estudiante
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Estudiante()
        {
            this.HistorialProgresion = new HashSet<HistorialProgresion>();
            this.InformeCabecera = new HashSet<InformeCabecera>();
        }
    
        public int EstudianteId { get; set; }
        public int ProfesorId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Carrera { get; set; }
        public string TituloTesis { get; set; }
        public string NumeroResolucion { get; set; }
        public System.DateTime FechaResolucion { get; set; }
        public byte[] ArchivoResolucion { get; set; }
        public string Estado { get; set; }
        public Nullable<int> PorcentajeAvance { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
    
        public virtual Profesor Profesor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistorialProgresion> HistorialProgresion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InformeCabecera> InformeCabecera { get; set; }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(EstudianteRepositorio.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProyectoTesis.Datos.Repositorios
{
    public class EstudianteRepositorio : RepositorioBase<Estudiante>
    {
        public EstudianteRepositorio(SistemaTesisEntities context) : base(context) { }

        public IEnumerable<Estudiante> ObtenerPorProfesor(int profesorId)
        {
            return Buscar(e => e.ProfesorId == profesorId);
        }

        public IEnumerable<Estudiante> BuscarConFiltros(
            int profesorId,
            string nombre = null,
            string apellido = null,
            string carrera = null,
            string estado = null,
            DateTime? fechaDesde = null,
            DateTime? fechaHasta = null)
        {
            var query = ((SistemaTesisEntities)_context).Estudiante
                .Include(e => e.Profesor)
                .Where(e => e.ProfesorId == profesorId);

            if (!string.IsNullOrWhiteSpace(nombre))
                query = query.Where(e => e.Nombres.Contains(nombre));

            if (!string.IsNullOrWhiteSpace(apellido))
                query = query.Where(e => e.Apellidos.Contains(apellido));

            if (!string.IsNullOrWhiteSpace(carrera))
                query = query.Where(e => e.Carrera.Contains(carrera));

            if (!string.IsNullOrWhiteSpace(estado))
                query = query.Where(e => e.Estado == estado);

            if (fechaDesde.HasValue)
                query = query.Where(e => e.FechaRegistro >= fechaDesde.Value);

            if (fechaHasta.HasValue)
                query = query.Where(e => e.FechaRegistro <= fechaHasta.Value);

            return query.OrderByDescending(e => e.FechaRegistro).ToList();
        }

        public Estudiante ObtenerConHistorial(int estudianteId)
        {
            return ((SistemaTesisEntities)_context).Estudiante
                .Include(e => e.HistorialProgresion)
                .Include(e => e.InformeCabecera)
                .FirstOrDefault(e => e.EstudianteId == estudianteId);
        }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(RepositorioViaje.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;
using System.Collections.Generic;
using System.Linq;
using PredictorTarifa.Entidades;

namespace PredictorTarifa.Datos
{
    // Repositorio: maneja todas las operaciones de la base de datos para Viaje
    public class RepositorioViaje
    {
        // Guarda un viaje nuevo en la base de datos SQL Server
        public void GuardarViaje(Viaje viaje)
        {
            using (var contexto = new ContextoBD())
            {
                viaje.FechaRegistro = DateTime.Now;
                contexto.Viajes.Add(viaje);
                contexto.SaveChanges();
            }
        }

        // Obtiene todos los viajes registrados en la base de datos
        public List<Viaje> ObtenerTodos()
        {
            using (var contexto = new ContextoBD())
            {
                return contexto.Viajes
                    .OrderByDescending(v => v.FechaRegistro)
                    .ToList();
            }
        }

        // Obtiene los ultimos N viajes registrados
        public List<Viaje> ObtenerUltimos(int cantidad)
        {
            using (var contexto = new ContextoBD())
            {
                return contexto.Viajes
                    .OrderByDescending(v => v.FechaRegistro)
                    .Take(cantidad)
                    .ToList();
            }
        }

        // Elimina un viaje por su ID
        public bool EliminarViaje(int id)
        {
            using (var contexto = new ContextoBD())
            {
                var viaje = contexto.Viajes.Find(id);
                if (viaje == null) return false;

                contexto.Viajes.Remove(viaje);
                contexto.SaveChanges();
                return true;
            }
        }

        // Verifica si la base de datos esta disponible y tiene registros
        public int ContarViajes()
        {
            using (var contexto = new ContextoBD())
            {
                return contexto.Viajes.Count();
            }
        }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(InformeCabecera.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharp//------------------------------------------------------------------------------
// <auto-generated>
//     Este cÃ³digo se generÃ³ a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicaciÃ³n.
//     Los cambios manuales en este archivo se sobrescribirÃ¡n si se regenera el cÃ³digo.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoTesis.Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class InformeCabecera
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InformeCabecera()
        {
            this.HistorialProgresion = new HashSet<HistorialProgresion>();
            this.InformeDetalle = new HashSet<InformeDetalle>();
        }
    
        public int InformeCabeceraId { get; set; }
        public int EstudianteId { get; set; }
        public int ProfesorId { get; set; }
        public string NumeroInforme { get; set; }
        public System.DateTime FechaEmision { get; set; }
        public int PorcentajeAcumulado { get; set; }
        public string Observaciones { get; set; }
        public string Estado { get; set; }
        public Nullable<bool> EsFinal { get; set; }
    
        public virtual Estudiante Estudiante { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistorialProgresion> HistorialProgresion { get; set; }
        public virtual Profesor Profesor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InformeDetalle> InformeDetalle { get; set; }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(RepositorioBase.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ProyectoTesis.Datos.Interfaces;

namespace ProyectoTesis.Datos
{
    public class RepositorioBase<T> : IRepositorio<T> where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dbSet;

        public RepositorioBase(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public T ObtenerPorId(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> ObtenerTodos()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<T> Buscar(Expression<Func<T, bool>> predicado)
        {
            return _dbSet.Where(predicado).ToList();
        }

        public void Agregar(T entidad)
        {
            _dbSet.Add(entidad);
        }

        public void AgregarRango(IEnumerable<T> entidades)
        {
            _dbSet.AddRange(entidades);
        }

        public void Actualizar(T entidad)
        {
            _context.Entry(entidad).State = EntityState.Modified;
        }

        public void Eliminar(T entidad)
        {
            if (_context.Entry(entidad).State == EntityState.Detached)
                _dbSet.Attach(entidad);
            _dbSet.Remove(entidad);
        }

        public void Eliminar(int id)
        {
            var entidad = _dbSet.Find(id);
            if (entidad != null)
                Eliminar(entidad);
        }

        public int Contar(Expression<Func<T, bool>> predicado = null)
        {
            if (predicado == null)
                return _dbSet.Count();
            return _dbSet.Count(predicado);
        }

        public bool Existe(Expression<Func<T, bool>> predicado)
        {
            return _dbSet.Any(predicado);
        }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(20260530024507_CreacionInicial.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PredictorTarifa.Datos.Migrations
{
    /// <inheritdoc />
    public partial class CreacionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Viajes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empresa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CodigoTarifa = table.Column<float>(type: "real", nullable: false),
                    NumeroPasajeros = table.Column<float>(type: "real", nullable: false),
                    DuracionSegundos = table.Column<float>(type: "real", nullable: false),
                    DistanciaMillas = table.Column<float>(type: "real", nullable: false),
                    TipoPago = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    TarifaReal = table.Column<float>(type: "real", nullable: false),
                    TarifaPredicha = table.Column<float>(type: "real", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viajes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Viajes");
        }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(FormLogin.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;
using System.Windows.Forms;
using ProyectoTesis.Logica.Interfaces;
using ProyectoTesis.Logica.Servicios;

namespace ProyectoTesis.Presentacion
{
    public partial class FormLogin : Form
    {
        private readonly ILoginServicio _loginServicio;

        public FormLogin()
        {
            InitializeComponent();
            _loginServicio = new LoginServicio();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text;

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Ingrese usuario y contrasena", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var profesor = _loginServicio.Autenticar(usuario, contrasena);

            if (profesor != null)
            {
                var principal = new FormPrincipal(profesor);
                principal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contrasena incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContrasena.Clear();
                txtUsuario.Focus();
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TxtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                BtnIngresar_Click(sender, e);
        }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(Prestamo.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;
using System.Collections.Generic;

namespace SolucionBiblioteca.Entidades
{
    public class Prestamo
    {
        public int PrestamoID { get; set; }
        public int LibroID { get; set; }
        public int EstudianteID { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucionEsperada { get; set; }
        public DateTime? FechaDevolucionReal { get; set; }
        public string Estado { get; set; }
        public int DiasRetraso { get; set; }
        public decimal MontoMulta { get; set; }
        
        public Libro Libro { get; set; }
        public Estudiante Estudiante { get; set; }
        
        public const int DIAS_PRESTAMO = 15;
        public const decimal MULTA_POR_DIA = 5.00m;
        
        public Prestamo()
        {
            FechaPrestamo = DateTime.Now;
            FechaDevolucionEsperada = DateTime.Now.AddDays(DIAS_PRESTAMO);
            Estado = "ACTIVO";
            DiasRetraso = 0;
            MontoMulta = 0;
        }
        
        public Prestamo(Libro libro, Estudiante estudiante) : this()
        {
            Libro = libro;
            LibroID = libro?.LibroID ?? 0;
            Estudiante = estudiante;
            EstudianteID = estudiante?.EstudianteID ?? 0;
        }
        
        public void CalcularMulta()
        {
            if (FechaDevolucionReal.HasValue && FechaDevolucionReal > FechaDevolucionEsperada)
            {
                DiasRetraso = (FechaDevolucionReal.Value - FechaDevolucionEsperada).Days;
                MontoMulta = DiasRetraso * MULTA_POR_DIA;
                Estado = "CON_MULTA";
            }
        }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(Profesor.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharp//------------------------------------------------------------------------------
// <auto-generated>
//     Este cÃ³digo se generÃ³ a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicaciÃ³n.
//     Los cambios manuales en este archivo se sobrescribirÃ¡n si se regenera el cÃ³digo.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoTesis.Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Profesor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Profesor()
        {
            this.Estudiante = new HashSet<Estudiante>();
            this.InformeCabecera = new HashSet<InformeCabecera>();
        }
    
        public int ProfesorId { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public Nullable<bool> Activo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Estudiante> Estudiante { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InformeCabecera> InformeCabecera { get; set; }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(Libro.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;
using System.Collections.Generic;

namespace SolucionBiblioteca.Entidades
{
    public class Libro
    {
        public int LibroID { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public int AnioPublicacion { get; set; }
        public int EjemplaresTotales { get; set; }
        public int EjemplaresDisponibles { get; set; }
        public int CategoriaID { get; set; }
        public bool Activo { get; set; }
        
        
        public Categoria Categoria { get; set; }
        public List<Prestamo> Prestamos { get; set; }
        
        
        public Libro()
        {
            Prestamos = new List<Prestamo>();
            Activo = true;
            EjemplaresTotales = 1;
            EjemplaresDisponibles = 1;
        }
        
        public Libro(string isbn, string titulo, string autor, int ejemplares) : this()
        {
            ISBN = isbn;
            Titulo = titulo;
            Autor = autor;
            EjemplaresTotales = ejemplares;
            EjemplaresDisponibles = ejemplares;
        }
        
        public Libro(string isbn, string titulo, string autor, string editorial, 
                     int anio, int ejemplares, int categoriaID) : this(isbn, titulo, autor, ejemplares)
        {
            Editorial = editorial;
            AnioPublicacion = anio;
            CategoriaID = categoriaID;
        }
        
        public bool TieneDisponibilidad()
        {
            return EjemplaresDisponibles > 0;
        }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(FormPrincipal.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;
using System.Windows.Forms;
using ProyectoTesis.Entidades;

namespace ProyectoTesis.Presentacion
{
    public partial class FormPrincipal : Form
    {
        private readonly Profesor _profesor;
        public Profesor ProfesorActual => _profesor;

        public FormPrincipal(Profesor profesor)
        {
            InitializeComponent();
            _profesor = profesor;
            this.Text = $"Sistema de Gestion de Tesis - {profesor.Nombres} {profesor.Apellidos}";
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            CargarVistaEstudiantes();
        }

        public void CargarVistaEstudiantes()
        {
            AbrirControl(new Controles.UcEstudiantes(_profesor, this));
        }

        private void BtnEstudiantes_Click(object sender, EventArgs e)
        {
            CargarVistaEstudiantes();
        }

        private void BtnNuevoEstudiante_Click(object sender, EventArgs e)
        {
            var form = new Formularios.FormEstudiante(_profesor.ProfesorId);
            if (form.ShowDialog() == DialogResult.OK)
                CargarVistaEstudiantes();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void AbrirControl(UserControl control)
        {
            pnlContenido.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pnlContenido.Controls.Add(control);
        }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(InformeCabeceraRepositorio.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProyectoTesis.Datos.Repositorios
{
    public class InformeCabeceraRepositorio : RepositorioBase<InformeCabecera>
    {
        public InformeCabeceraRepositorio(SistemaTesisEntities context) : base(context) { }

        public IEnumerable<InformeCabecera> ObtenerPorEstudiante(int estudianteId)
        {
            return ((SistemaTesisEntities)_context).InformeCabecera
                .Include(i => i.InformeDetalle)
                .Include(i => i.Estudiante)
                .Include(i => i.Profesor)
                .Where(i => i.EstudianteId == estudianteId)
                .OrderByDescending(i => i.FechaEmision)
                .ToList();
        }

        public InformeCabecera ObtenerConDetalles(int informeId)
        {
            return ((SistemaTesisEntities)_context).InformeCabecera
                .Include(i => i.InformeDetalle)
                .Include(i => i.Estudiante)
                .Include(i => i.Profesor)
                .FirstOrDefault(i => i.InformeCabeceraId == informeId);
        }

        public int ObtenerUltimoNumeroInforme(int estudianteId)
        {
            var ultimo = ((SistemaTesisEntities)_context).InformeCabecera
                .Where(i => i.EstudianteId == estudianteId)
                .OrderByDescending(i => i.InformeCabeceraId)
                .FirstOrDefault();

            if (ultimo == null) return 0;

            if (int.TryParse(ultimo.NumeroInforme?.Replace("INF-", ""), out int num))
                return num;

            return 0;
        }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(Libros.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharp//------------------------------------------------------------------------------
// <auto-generated>
//     Este cÃ³digo se generÃ³ a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicaciÃ³n.
//     Los cambios manuales en este archivo se sobrescribirÃ¡n si se regenera el cÃ³digo.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Libros
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Libros()
        {
            this.Prestamos = new HashSet<Prestamos>();
        }
    
        public int LibroID { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public Nullable<int> AnioPublicacion { get; set; }
        public int EjemplaresTotales { get; set; }
        public int EjemplaresDisponibles { get; set; }
        public Nullable<int> CategoriaID { get; set; }
        public Nullable<bool> Activo { get; set; }
    
        public virtual Categorias Categorias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prestamos> Prestamos { get; set; }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(Estudiantes.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharp//------------------------------------------------------------------------------
// <auto-generated>
//     Este cÃ³digo se generÃ³ a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicaciÃ³n.
//     Los cambios manuales en este archivo se sobrescribirÃ¡n si se regenera el cÃ³digo.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Estudiantes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Estudiantes()
        {
            this.Prestamos = new HashSet<Prestamos>();
        }
    
        public int EstudianteID { get; set; }
        public string Matricula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Carrera { get; set; }
        public Nullable<int> Semestre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public Nullable<bool> Activo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prestamos> Prestamos { get; set; }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(Estudiante.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;
using System.Collections.Generic;

namespace SolucionBiblioteca.Entidades
{
    public class Estudiante
    {
        public int EstudianteID { get; set; }
        public string Matricula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Carrera { get; set; }
        public int Semestre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public bool Activo { get; set; }
        
        public List<Prestamo> Prestamos { get; set; }
        
        public Estudiante()
        {
            Prestamos = new List<Prestamo>();
            Activo = true;
        }
        
        public Estudiante(string matricula, string nombre, string apellido) : this()
        {
            Matricula = matricula;
            Nombre = nombre;
            Apellido = apellido;
        }
        
        public Estudiante(string matricula, string nombre, string apellido, 
                         string carrera, int semestre) : this(matricula, nombre, apellido)
        {
            Carrera = carrera;
            Semestre = semestre;
        }
        
        public string NombreCompleto => $"{Nombre} {Apellido}";
        
        public int PrestamosActivos()
        {
            return Prestamos.FindAll(p => p.Estado == "ACTIVO").Count;
        }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(Model2.Context.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharp//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoTesis.Datos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SistemaTesisEntities : DbContext
    {
        public SistemaTesisEntities()
            : base("name=SistemaTesisEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Estudiante> Estudiante { get; set; }
        public virtual DbSet<HistorialProgresion> HistorialProgresion { get; set; }
        public virtual DbSet<InformeCabecera> InformeCabecera { get; set; }
        public virtual DbSet<InformeDetalle> InformeDetalle { get; set; }
        public virtual DbSet<Profesor> Profesor { get; set; }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(Prestamos.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharp//------------------------------------------------------------------------------
// <auto-generated>
//     Este cÃ³digo se generÃ³ a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicaciÃ³n.
//     Los cambios manuales en este archivo se sobrescribirÃ¡n si se regenera el cÃ³digo.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Prestamos
    {
        public int PrestamoID { get; set; }
        public Nullable<int> LibroID { get; set; }
        public Nullable<int> EstudianteID { get; set; }
        public System.DateTime FechaPrestamo { get; set; }
        public Nullable<System.DateTime> FechaDevolucionEsperada { get; set; }
        public Nullable<System.DateTime> FechaDevolucionReal { get; set; }
        public string Estado { get; set; }
        public Nullable<int> DiasRetraso { get; set; }
        public Nullable<decimal> MontoMulta { get; set; }
    
        public virtual Estudiantes Estudiantes { get; set; }
        public virtual Libros Libros { get; set; }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(ContextoBD.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing Microsoft.EntityFrameworkCore;
using PredictorTarifa.Entidades;

namespace PredictorTarifa.Datos
{
    // Contexto de Entity Framework Core - Representa la base de datos
    public class ContextoBD : DbContext
    {
        // Tabla de viajes en SQL Server
        public DbSet<Viaje> Viajes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder opciones)
        {
            // Conexion a SQL Server Express local con autenticacion de Windows
            opciones.UseSqlServer(
                "Server=localhost\\SQLEXPRESS;Database=PredictorTarifaDB;Trusted_Connection=True;TrustServerCertificate=True;"
            );
        }

        protected override void OnModelCreating(ModelBuilder modelCreador)
        {
            // Configuracion de la tabla Viajes
            modelCreador.Entity<Viaje>(entidad =>
            {
                entidad.HasKey(v => v.Id);
                entidad.Property(v => v.Empresa).HasMaxLength(10).IsRequired();
                entidad.Property(v => v.TipoPago).HasMaxLength(5).IsRequired();
                entidad.Property(v => v.FechaRegistro).HasDefaultValueSql("GETDATE()");
                entidad.ToTable("Viajes");
            });
        }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(Categorias.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharp//------------------------------------------------------------------------------
// <auto-generated>
//     Este cÃ³digo se generÃ³ a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicaciÃ³n.
//     Los cambios manuales en este archivo se sobrescribirÃ¡n si se regenera el cÃ³digo.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Categorias
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Categorias()
        {
            this.Libros = new HashSet<Libros>();
        }
    
        public int CategoriaID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Nullable<bool> Activo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Libros> Libros { get; set; }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(Model1.Context.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharp//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BibliotecaDBEntities : DbContext
    {
        public BibliotecaDBEntities()
            : base("name=BibliotecaDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Estudiantes> Estudiantes { get; set; }
        public virtual DbSet<Libros> Libros { get; set; }
        public virtual DbSet<Prestamos> Prestamos { get; set; }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(Venta.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;

namespace SistemaVentas.Entidades
{
    // Entidad que representa una venta en la base de datos
    public class Venta
    {
        public int Id { get; set; }
        public string Region { get; set; }
        public string Pais { get; set; }
        public string TipoProducto { get; set; }
        public string CanalVenta { get; set; }
        public string Prioridad { get; set; }
        public DateTime FechaOrden { get; set; }
        public long OrdenId { get; set; }
        public DateTime FechaEnvio { get; set; }
        public int UnidadesVendidas { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal CostoUnitario { get; set; }
        public decimal IngresoTotal { get; set; }
        public decimal CostoTotal { get; set; }
        public decimal GananciaTotal { get; set; }

        public Venta()
        {
            Region = "";
            Pais = "";
            TipoProducto = "";
            CanalVenta = "";
            Prioridad = "";
        }

        public override string ToString()
        {
            return string.Format("Venta #{0} - {1} | {2} | ${3:N2}", Id, Pais, TipoProducto, IngresoTotal);
        }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(Estudiante.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;
using System.Collections.Generic;

namespace ProyectoTesis.Entidades
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            this.HistorialProgresion = new HashSet<HistorialProgresion>();
            this.InformeCabecera = new HashSet<InformeCabecera>();
        }

        public int EstudianteId { get; set; }
        public int ProfesorId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public string Carrera { get; set; }
        public string TituloTesis { get; set; }
        public string NumeroResolucion { get; set; }
        public DateTime FechaResolucion { get; set; }
        public byte[] ArchivoResolucion { get; set; }
        public string Estado { get; set; }
        public Nullable<int> PorcentajeAvance { get; set; }
        public Nullable<DateTime> FechaRegistro { get; set; }

        public virtual Profesor Profesor { get; set; }
        public virtual ICollection<HistorialProgresion> HistorialProgresion { get; set; }
        public virtual ICollection<InformeCabecera> InformeCabecera { get; set; }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(HistorialProgresion.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharp//------------------------------------------------------------------------------
// <auto-generated>
//     Este cÃ³digo se generÃ³ a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicaciÃ³n.
//     Los cambios manuales en este archivo se sobrescribirÃ¡n si se regenera el cÃ³digo.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoTesis.Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class HistorialProgresion
    {
        public int HistorialId { get; set; }
        public int EstudianteId { get; set; }
        public int InformeCabeceraId { get; set; }
        public System.DateTime FechaInforme { get; set; }
        public int PorcentajeEnInforme { get; set; }
        public string EstadoEnInforme { get; set; }
        public string ResumenActividades { get; set; }
    
        public virtual Estudiante Estudiante { get; set; }
        public virtual InformeCabecera InformeCabecera { get; set; }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(InformeCabecera.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;
using System.Collections.Generic;

namespace ProyectoTesis.Entidades
{
    public partial class InformeCabecera
    {
        public InformeCabecera()
        {
            this.HistorialProgresion = new HashSet<HistorialProgresion>();
            this.InformeDetalle = new HashSet<InformeDetalle>();
        }

        public int InformeCabeceraId { get; set; }
        public int EstudianteId { get; set; }
        public int ProfesorId { get; set; }
        public string NumeroInforme { get; set; }
        public DateTime FechaEmision { get; set; }
        public int PorcentajeAcumulado { get; set; }
        public string Observaciones { get; set; }
        public string Estado { get; set; }
        public Nullable<bool> EsFinal { get; set; }

        public virtual Estudiante Estudiante { get; set; }
        public virtual ICollection<HistorialProgresion> HistorialProgresion { get; set; }
        public virtual Profesor Profesor { get; set; }
        public virtual ICollection<InformeDetalle> InformeDetalle { get; set; }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(Viaje.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing System;

namespace PredictorTarifa.Entidades
{
    // Entidad principal que representa un viaje guardado en la base de datos
    public class Viaje
    {
        public int Id { get; set; }

        // Empresa de taxis (CMT o VTS)
        public string Empresa { get; set; }

        // Codigo de tarifa aplicada
        public float CodigoTarifa { get; set; }

        // Numero de pasajeros en el viaje
        public float NumeroPasajeros { get; set; }

        // Duracion del viaje en segundos
        public float DuracionSegundos { get; set; }

        // Distancia del viaje en millas
        public float DistanciaMillas { get; set; }

        // Tipo de pago (CRD = Tarjeta, CSH = Efectivo)
        public string TipoPago { get; set; }

        // Tarifa real del viaje en dolares
        public float TarifaReal { get; set; }

        // Tarifa que predijo el modelo de ML
        public float TarifaPredicha { get; set; }

        // Fecha y hora en que se registro el viaje
        public DateTime FechaRegistro { get; set; }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(LoginServicio.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharpusing ProyectoTesis.Entidades;
using ProyectoTesis.Logica.Interfaces;

namespace ProyectoTesis.Logica.Servicios
{
    public class LoginServicio : ILoginServicio
    {
        private Profesor MapDatosAEntidad(ProyectoTesis.Datos.Profesor profesor)
        {
            if (profesor == null) return null;
            return new Profesor
            {
                ProfesorId = profesor.ProfesorId,
                Nombres = profesor.Nombres,
                Apellidos = profesor.Apellidos,
                Usuario = profesor.Usuario,
                Contrasena = profesor.Contrasena,
                Email = profesor.Email,
                Activo = profesor.Activo
            };
        }

        public Profesor Autenticar(string usuario, string contrasena)
        {
            using (var uow = new ProyectoTesis.Datos.UnitOfWork())
            {
                var datosProfesor = uow.ProfesorRepositorio.ObtenerPorUsuario(usuario);
                return MapDatosAEntidad(datosProfesor);
            }
        }
    }
}

``

## 📝 Archivo: $nombreRelativo
**Ubicación:** $(InformeDetalle.cs.DirectoryName)
**Propósito:** Componente extraído directamente del proyecto para estudio de sintaxis y arquitectura.

``csharp//------------------------------------------------------------------------------
// <auto-generated>
//     Este cÃ³digo se generÃ³ a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicaciÃ³n.
//     Los cambios manuales en este archivo se sobrescribirÃ¡n si se regenera el cÃ³digo.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoTesis.Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class InformeDetalle
    {
        public int InformeDetalleId { get; set; }
        public int InformeCabeceraId { get; set; }
        public int NumeroActividad { get; set; }
        public string DescripcionActividad { get; set; }
        public int PorcentajeActividad { get; set; }
        public string Observacion { get; set; }
    
        public virtual InformeCabecera InformeCabecera { get; set; }
    }
}

``
