using Microsoft.EntityFrameworkCore;
using DreamyReefs.Models;

namespace DreamyReefs.Data
{
    public class Conexion : DbContext
    {
        public Conexion(DbContextOptions<Conexion> options) : base(options)
        {

        }

        public DbSet<AccesoWeb> AccesoWeb { get; set; }
        public DbSet<Caracteristica> Caracteristicas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Disponibilidad> Disponibilidades { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Estatus> Estatuses { get; set; }
        public DbSet<Imagen> Imagenes { get; set; }
        public DbSet<Reservacion> Reservaciones { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tours> Tours { get; set; }
        public DbSet<Transportes> Transportes { get; set; }

        #region Tablas
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<AccesoWeb>().ToTable("AccesoWeb");
            builder.Entity<AccesoWeb>().HasKey(u => u.IDAccesoWeb);
            builder.Entity<AccesoWeb>().Property(u => u.IDAccesoWeb).HasColumnName("IDAccesoWeb");
            builder.Entity<AccesoWeb>().Property(u => u.Usuario).HasColumnName("Usuario");
            builder.Entity<AccesoWeb>().Property(u => u.Nombre).HasColumnName("Nombre");
            builder.Entity<AccesoWeb>().Property(u => u.Correo).HasColumnName("Correo");
            builder.Entity<AccesoWeb>().Property(u => u.Contrasena).HasColumnName("Contrasena");
            builder.Entity<AccesoWeb>().Property(u => u.Estatus).HasColumnName("Estatus");

            builder.Entity<Caracteristica>().ToTable("Caracteristicas");
            builder.Entity<Caracteristica>().HasKey(u => u.IDCaracteristicas);
            builder.Entity<Caracteristica>().Property(u => u.IDCaracteristicas).HasColumnName("IDCaracteristicas");
            builder.Entity<Caracteristica>().Property(u => u.NombreCaracteristica).HasColumnName("NombreCaracteristica");

            builder.Entity<Categoria>().ToTable("Categorias");
            builder.Entity<Categoria>().HasKey(u => u.IDCategorias);
            builder.Entity<Categoria>().Property(u => u.IDCategorias).HasColumnName("IDCategorias");
            builder.Entity<Categoria>().Property(u => u.NombreCategoria).HasColumnName("NombreCategoria");

            builder.Entity<Disponibilidad>().ToTable("Disponibilidad");
            builder.Entity<Disponibilidad>().HasKey(u => u.IDDisponibilidad);
            builder.Entity<Disponibilidad>().Property(u => u.IDDisponibilidad).HasColumnName("IDDisponibilidad");
            builder.Entity<Disponibilidad>().Property(u => u.Hora).HasColumnName("Hora");

            builder.Entity<Empresa>().ToTable("Empresas");
            builder.Entity<Empresa>().HasKey(u => u.IDEmpresas);
            builder.Entity<Empresa>().Property(u => u.IDEmpresas).HasColumnName("IDEmpresas");
            builder.Entity<Empresa>().Property(u => u.NombreEmpresa).HasColumnName("NombreEmpresa");
            builder.Entity<Empresa>().Property(u => u.Correo).HasColumnName("Correo");
            builder.Entity<Empresa>().Property(u => u.Telefono).HasColumnName("Telefono");
            builder.Entity<Empresa>().Property(u => u.Direccion).HasColumnName("Direccion");
            builder.Entity<Empresa>().Property(u => u.RFC).HasColumnName("RFC");

            builder.Entity<Estatus>().ToTable("Estatus");
            builder.Entity<Estatus>().HasKey(u => u.IDEstatus);
            builder.Entity<Estatus>().Property(u => u.IDEstatus).HasColumnName("IDEstatus");
            builder.Entity<Estatus>().Property(u => u.NombreEstatus).HasColumnName("NombreEstatus");

            builder.Entity<Imagen>().ToTable("Imagenes");
            builder.Entity<Imagen>().HasKey(u => u.IDImagenes);
            builder.Entity<Imagen>().Property(u => u.IDImagenes).HasColumnName("IDImagenes");
            builder.Entity<Imagen>().Property(u => u.ImagenBase64).HasColumnName("ImagenBase64");
            builder.Entity<Imagen>().Property(u => u.TourID).HasColumnName("TourID");

            builder.Entity<Reservacion>().ToTable("Reservaciones");
            builder.Entity<Reservacion>().HasKey(u => u.IDReservaciones);
            builder.Entity<Reservacion>().Property(u => u.IDReservaciones).HasColumnName("IDReservaciones");
            builder.Entity<Reservacion>().Property(u => u.NombreCompleto).HasColumnName("NombreCompleto");
            builder.Entity<Reservacion>().Property(u => u.Telefono).HasColumnName("Telefono");
            builder.Entity<Reservacion>().Property(u => u.Email).HasColumnName("Email");
            builder.Entity<Reservacion>().Property(u => u.Adultos).HasColumnName("Adultos");
            builder.Entity<Reservacion>().Property(u => u.Infantes).HasColumnName("Infantes");
            builder.Entity<Reservacion>().Property(u => u.Estatus).HasColumnName("Estatus");

            builder.Entity<Review>().ToTable("Reviews");
            builder.Entity<Review>().HasKey(u => u.IDReviews);
            builder.Entity<Review>().Property(u => u.IDReviews).HasColumnName("IDReviews");
            builder.Entity<Review>().Property(u => u.TourID).HasColumnName("TourID");
            builder.Entity<Review>().Property(u => u.Comentario).HasColumnName("Comentario");

            builder.Entity<Tours>().ToTable("Tours");
            builder.Entity<Tours>().HasKey(u => u.IDTours);
            builder.Entity<Tours>().Property(u => u.IDTours).HasColumnName("IDTours");
            builder.Entity<Tours>().Property(u => u.Nombre).HasColumnName("Nombre");
            builder.Entity<Tours>().Property(u => u.Itinerario).HasColumnName("Itinerario");
            builder.Entity<Tours>().Property(u => u.Precio).HasColumnName("Precio");
            builder.Entity<Tours>().Property(u => u.Descripcion).HasColumnName("Descripcion");
            builder.Entity<Tours>().Property(u => u.Disponibilidad).HasColumnName("Disponibilidad");
            builder.Entity<Tours>().Property(u => u.Idioma).HasColumnName("Idioma");
            builder.Entity<Tours>().Property(u => u.Categoria1).HasColumnName("Categoria1");
            builder.Entity<Tours>().Property(u => u.Categoria2).HasColumnName("Categoria2");
            builder.Entity<Tours>().Property(u => u.Categoria3).HasColumnName("Categoria3");
            builder.Entity<Tours>().Property(u => u.Categoria4).HasColumnName("Categoria4");
            builder.Entity<Tours>().Property(u => u.Caracteristica1).HasColumnName("Caracteristica1");
            builder.Entity<Tours>().Property(u => u.Caracteristica2).HasColumnName("Caracteristica2");
            builder.Entity<Tours>().Property(u => u.Caracteristica3).HasColumnName("Caracteristica3");
            builder.Entity<Tours>().Property(u => u.Estatus).HasColumnName("Estatus");
            builder.Entity<Tours>().Property(u => u.PrecioAdulto).HasColumnName("PrecioAdulto");
            builder.Entity<Tours>().Property(u => u.PrecioInfantes).HasColumnName("PrecioInfantes");

            builder.Entity<Transportes>().ToTable("Transportes");
            builder.Entity<Transportes>().HasKey(u => u.IDTransportes);
            builder.Entity<Transportes>().Property(u => u.IDTransportes).HasColumnName("IDTransportes");
            builder.Entity<Transportes>().Property(u => u.NombreEmpresa).HasColumnName("NombreEmpresa");
            builder.Entity<Transportes>().Property(u => u.Transporte).HasColumnName("Transporte");
        }

        #endregion

        #region Acciones de usuario
        public List<AccesoWeb> GetAllUsuarios()
        {
            return AccesoWeb.FromSqlRaw("EXEC [dbo].[ObtenerUsuarios] 'ACCESO'").ToList();
        }

        public AccesoWeb? GetOneUsuario(int id)
        {
            var usuario = AccesoWeb.FromSqlInterpolated($"EXEC [dbo].[ObtenerUsuarioPorID] 'ACCESO', {id}").AsEnumerable().FirstOrDefault();
            return usuario;
        }

        public void CrearUsuario(string user, string name, string email, string pass, string status)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[CrearUsuario] 'ACCESO', {0}, {1}, {2}, {3}, {4}", user, name, email, pass, status);
        }

        public void ActualizarUsuario(int ID, string user, string name, string email, string pass, string status)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[ActualizarUsuario] 'ACCESO', {0}, {1}, {2}, {3}, {4}, {5}", ID, user, name, email, pass, status);
        }

        public void EliminarUsuario(int ID)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[EliminarUsuario] 'ACCESO', {0}", ID);
        }

        public void InicioSesion(string email, string pass)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[InicioDeSesion] {0}, {1}", email, pass);
        }

        #endregion

        #region Acciones de Tours
        public List<Tours> GetAllTours()
        {
            return Tours.FromSqlRaw("EXEC [dbo].[ObtenerUsuarios] 'TOURS'").ToList();
        }

        public Tours? GetOneTour(int id)
        {
            var tours = Tours.FromSqlInterpolated($"EXEC [dbo].[ObtenerUsuarioPorID] 'TOURS', {id}").AsEnumerable().FirstOrDefault();
            return tours;
        }

        public void CrearTour(string name, string itinerario, int precio, string descripcion, string disponibilidad, string idioma, string categoria1, string categoria2, string categoria3, string categoria4, string caracteristica1, string caracteristica2, string caracteristica3, string estatus, int precioAdulto, int precioInfantes)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[CrearUsuario] 'TOURS', {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}", name, itinerario, precio, descripcion, disponibilidad, idioma, categoria1, categoria2, categoria3, categoria4, caracteristica1, caracteristica2, caracteristica3, estatus, precioAdulto, precioInfantes);
        }

        public void ActualizarTour(int ID, string name, string itinerario, int precio, string descripcion, string disponibilidad, string idioma, string categoria1, string categoria2, string categoria3, string categoria4, string caracteristica1, string caracteristica2, string caracteristica3, string estatus, int precioAdulto, int precioInfantes)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[ActualizarUsuario] 'TOURS', {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}", ID, name, itinerario, precio, descripcion, disponibilidad, idioma, categoria1, categoria2, categoria3, categoria4, caracteristica1, caracteristica2, caracteristica3, estatus, precioAdulto, precioInfantes);
        }

        public void EliminarTour(int ID)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[EliminarUsuario] 'TOURS', {0}", ID);
        }

        #endregion

        #region Acciones de Caracteristicas
        public List<Caracteristica> GetAllCaracteristicas()
        {
            return Caracteristicas.FromSqlRaw("EXEC [dbo].[ObtenerUsuarios] 'CARACTERISTICAS'").ToList();
        }

        public Caracteristica? GetOneCaracteristicas(int id)
        {
            var caracteristicas = Caracteristicas.FromSqlInterpolated($"EXEC [dbo].[ObtenerUsuarioPorID] 'CARACTERISTICAS', {id}").AsEnumerable().FirstOrDefault();
            return caracteristicas;
        }

        public void CrearCaracteristicas(string name)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[CrearUsuario] 'CARACTERISTICAS', {0}", name);
        }

        public void ActualizarCaracteristicas(int ID, string name)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[ActualizarUsuario] 'CARACTERISTICAS', {0}, {1}", ID, name);
        }

        public void EliminarCaracteristicas(int ID)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[EliminarUsuario] 'CARACTERISTICAS', {0}", ID);
        }

        #endregion

        #region Acciones de Categorias
        public List<Categoria> GetAllCategorias()
        {
            return Categorias.FromSqlRaw("EXEC [dbo].[ObtenerUsuarios] 'CATEGORIAS'").ToList();
        }

        public Categoria? GetOneCategoria(int id)
        {
            var categoria = Categorias.FromSqlInterpolated($"EXEC [dbo].[ObtenerUsuarioPorID] 'CATEGORIAS', {id}").AsEnumerable().FirstOrDefault();
            return categoria;
        }

        public void CrearCategoria(string name)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[CrearUsuario] 'CATEGORIAS', {0}", name);
        }

        public void ActualizarCategoria(int ID, string name)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[ActualizarUsuario] 'CATEGORIAS', {0}, {1}", ID, name);
        }

        public void EliminarCategoria(int ID)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[EliminarUsuario] 'CATEGORIAS', {0}", ID);
        }

        #endregion

        #region Acciones de Disponible
        public List<Disponibilidad> GetAllDisponible()
        {
            return Disponibilidades.FromSqlRaw("EXEC [dbo].[ObtenerUsuarios] 'DISPONIBLE'").ToList();
        }

        public Disponibilidad? GetOneDisponible(int id)
        {
            var disponibilidad = Disponibilidades.FromSqlInterpolated($"EXEC [dbo].[ObtenerUsuarioPorID] 'DISPONIBLE', {id}").AsEnumerable().FirstOrDefault();
            return disponibilidad;
        }

        public void CrearDisponible(string name)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[CrearUsuario] 'DISPONIBLE', {0}", name);
        }

        public void ActualizarDisponible(int ID, string name)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[ActualizarUsuario] 'DISPONIBLE', {0}, {1}", ID, name);
        }

        public void EliminarDisponible(int ID)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[EliminarUsuario] 'DISPONIBLE', {0}", ID);
        }

        #endregion

        #region Acciones de Empresas
        public List<Empresa> GetAllEmpresas()
        {
            return Empresas.FromSqlRaw("EXEC [dbo].[ObtenerUsuarios] 'EMPRESAS'").ToList();
        }

        public Empresa? GetOneEmpresas(int id)
        {
            var empresa = Empresas.FromSqlInterpolated($"EXEC [dbo].[ObtenerUsuarioPorID] 'EMPRESAS', {id}").AsEnumerable().FirstOrDefault();
            return empresa;
        }

        public void CrearEmpresas(string name, string correo, string telefono, string direccion, string rfc)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[CrearUsuario] 'EMPRESAS', {0}, {1}, {2}, {3}, {4}", name, correo, telefono, direccion, rfc);
        }

        public void ActualizarEmpresas(int ID, string name, string correo, string telefono, string direccion, string rfc)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[ActualizarUsuario] 'EMPRESAS', {0}, {1}, {2}, {3}, {4}, {5}", ID, name, correo, telefono, direccion, rfc);
        }

        public void EliminarEmpresas(int ID)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[EliminarUsuario] 'EMPRESAS', {0}", ID);
        }

        #endregion

        #region Acciones de Estatus
        public List<Estatus> GetAllEstatus()
        {
            return Estatuses.FromSqlRaw("EXEC [dbo].[ObtenerUsuarios] 'ESTATUS'").ToList();
        }

        public Estatus? GetOneEstatus(int id)
        {
            var estatus = Estatuses.FromSqlInterpolated($"EXEC [dbo].[ObtenerUsuarioPorID] 'ESTATUS', {id}").AsEnumerable().FirstOrDefault();
            return estatus;
        }

        public void CrearEstatus(string name)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[CrearUsuario] 'ESTATUS', {0}", name);
        }

        public void ActualizarEstatus(int ID, string name)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[ActualizarUsuario] 'ESTATUS', {0}, {1}", ID, name);
        }

        public void EliminarEstatus(int ID)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[EliminarUsuario] 'ESTATUS', {0}", ID);
        }

        #endregion

        #region Acciones de Imagenes
        public List<Imagen> GetAllImagenes()
        {
            return Imagenes.FromSqlRaw("EXEC [dbo].[ObtenerUsuarios] 'IMAGENES'").ToList();
        }

        public Imagen? GetOneImagenes(int id)
        {
            var imagenes = Imagenes.FromSqlInterpolated($"EXEC [dbo].[ObtenerUsuarioPorID] 'IMAGENES', {id}").AsEnumerable().FirstOrDefault();
            return imagenes;
        }

        public void CrearImagenes(string imagen, int idtour)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[CrearUsuario] 'IMAGENES', {0}, {1}", imagen, idtour);
        }

        public void ActualizarImagenes(int ID, string imagen, int idtour)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[ActualizarUsuario] 'IMAGENES', {0}, {1}, {2}", ID, imagen, idtour);
        }

        public void EliminarImagenes(int ID)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[EliminarUsuario] 'IMAGENES', {0}", ID);
        }

        #endregion

        #region Acciones de Reservaciones
        public List<Reservacion> GetAllReservaciones()
        {
            return Reservaciones.FromSqlRaw("EXEC [dbo].[ObtenerUsuarios] 'RESERVACIONES'").ToList();
        }

        public Reservacion? GetOneReservaciones(int id)
        {
            var reseervaciones = Reservaciones.FromSqlInterpolated($"EXEC [dbo].[ObtenerUsuarioPorID] 'RESERVACIONES', {id}").AsEnumerable().FirstOrDefault();
            return reseervaciones;
        }

        public void CrearReservaciones(string name, string telefono, string email, int adultos, int infantes, string estatus)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[CrearUsuario] 'RESERVACIONES', {0}, {1}, {2}, {3}, {4}", name, telefono, email, adultos, infantes, estatus);
        }

        public void ActualizarReservaciones(int ID, string name, string telefono, string email, int adultos, int infantes, string estatus)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[ActualizarUsuario] 'RESERVACIONES', {0}, {1}, {2}, {3}, {4}, {5}, {6}", ID, name, telefono, email, adultos, infantes, estatus);
        }

        public void EliminarReservaciones(int ID)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[EliminarUsuario] 'RESERVACIONES', {0}", ID);
        }

        #endregion

        #region Acciones de Reviews
        public List<Review> GetAllReviews()
        {
            return Reviews.FromSqlRaw("EXEC [dbo].[ObtenerUsuarios] 'REVIEWS'").ToList();
        }

        public Review? GetOneReviews(int id)
        {
            var reviews = Reviews.FromSqlInterpolated($"EXEC [dbo].[ObtenerUsuarioPorID] 'REVIEWS', {id}").AsEnumerable().FirstOrDefault();
            return reviews;
        }

        public void CrearReviews(int idtour, string comentario)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[CrearUsuario] 'REVIEWS', {0}, {1}", idtour, comentario);
        }

        public void ActualizarReviews(int ID, int idtour, string comentario)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[ActualizarUsuario] 'REVIEWS', {0}, {1}, {2}", ID, idtour, comentario);
        }

        public void EliminarReviews(int ID)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[EliminarUsuario] 'REVIEWS', {0}", ID);
        }

        #endregion

        #region Acciones de Transportes
        public List<Transportes> GetAllTransportes()
        {
            return Transportes.FromSqlRaw("EXEC [dbo].[ObtenerUsuarios] 'TRANSPORTES'").ToList();
        }

        public Transportes? GetOneTransportes(int id)
        {
            var transportes = Transportes.FromSqlInterpolated($"EXEC [dbo].[ObtenerUsuarioPorID] 'TRANSPORTES', {id}").AsEnumerable().FirstOrDefault();
            return transportes;
        }

        public void CrearTransportes(string nombreEmpresa, string tp)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[CrearUsuario] 'TRANSPORTES', {0}, {1}", nombreEmpresa, tp);
        }

        public void ActualizarTransportes(int ID, string nombreEmpresa, string tp)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[ActualizarUsuario] 'TRANSPORTES', {0}, {1}, {2}", ID, nombreEmpresa, tp);
        }

        public void EliminarTransportes(int ID)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[EliminarUsuario] 'TRANSPORTES', {0}", ID);
        }

        #endregion
    }
}