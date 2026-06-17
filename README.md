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

# 📚 ANEXO DE ESTUDIO INTENSIVO: CÓDIGO FUENTE LÍNEA POR LÍNEA

> **NOTA PARA EL ESTUDIANTE:** 
> A continuación se presenta el código fuente completo de los componentes más críticos de la arquitectura N-Capas y las implementaciones de LINQ. Este anexo ha sido generado para que no tengas que abrir Visual Studio al repasar. Todo el código que necesitas para el examen está aquí mismo.
