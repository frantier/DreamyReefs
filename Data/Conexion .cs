using Microsoft.EntityFrameworkCore;
using DreamyReefs.Models;

namespace DreamyReefs.Data
{
    public class Conexion : DbContext
    {
        public Conexion(DbContextOptions<Conexion> options) : base(options)
        {

        }

        public DbSet<AccesoWeb> AccesoWeb {get; set;}
        public DbSet<Caracteristica> Caracteristicas {get; set;}
        public DbSet<Categoria> Categorias {get; set;}
        public DbSet<Disponibilidad> Disponibilidades {get; set;}
        public DbSet<Empresa> Empresas {get; set;}
        public DbSet<Estatus> Estatuses {get; set;}
        public DbSet<Imagen> Imagenes {get; set;}
        public DbSet<Reservacion> Reservaciones {get; set;}
        public DbSet<Review> Reviews {get; set;}
        public DbSet<Tours> Tours {get; set;}
        public DbSet<Transporte> Transportes {get; set;}

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
            builder.Entity<Reservacion>().Property(u => u.RecienNacidos).HasColumnName("RecienNacidos");

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

            builder.Entity<Transporte>().ToTable("Transportes");
            builder.Entity<Transporte>().HasKey(u => u.IDTransportes);
            builder.Entity<Transporte>().Property(u => u.IDTransportes).HasColumnName("IDTransportes");
            builder.Entity<Transporte>().Property(u => u.NombreEmpresa).HasColumnName("NombreEmpresa");
            builder.Entity<Transporte>().Property(u => u.NombreTransporte).HasColumnName("NombreTransporte");
        }

        #endregion
        public List<AccesoWeb> GetAllUsuarios()
        {
            return AccesoWeb.FromSqlRaw("EXEC [dbo].[ObtenerUsuarios]").ToList();
        }

        public AccesoWeb? GetOneUsuario(int id)
        {
            var usuario = AccesoWeb.FromSqlInterpolated($"EXEC [dbo].[ObtenerUsuarioPorID] {id}").AsEnumerable().FirstOrDefault();
            return usuario;
        }

        public void CrearUsuario(string user, string name, string email, string pass, string status)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[CrearUsuario] {0}, {1}, {2}, {3}, {4}", user, name, email, pass, status);
        }

        public void  ActualizarUsuario(int ID, string user, string name, string email, string pass, string status)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[ActualizarUsuario] {0}, {1}, {2}, {3}, {4}, {5}", ID, user, name, email, pass, status);
        }

        public void  EliminarUsuario(int ID)
        {
            Database.ExecuteSqlRaw("EXEC [dbo].[EliminarUsuario] {0}", ID);
        }
    }
}