using Microsoft.EntityFrameworkCore;

namespace adminpro.Models
{ 


    public class MyDBContex : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-TDAOF1CV;Initial Catalog=SEHS;User ID=sa;Password=1234567"
                );
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<destinoCompra> destinoCompras {get;set;}
        public DbSet<tipoOferta> tipoOfertas {get;set;}
        public DbSet<facturacion> facturaciones {get;set;}
        public DbSet<producto> productos {get;set;} 
        public DbSet<productoOferta> productoOfertas {get;set;}
        public DbSet<notificacion> notificaciones {get;set;} 
        public DbSet<compra> compras {get;set;} 
        public DbSet<oferta> ofertas {get;set;} 
        public DbSet<tipoPago> tipoPagos {get;set;} 
        public DbSet<reserva> reservas{get;set;}
        public DbSet<provincia> provincias {get;set;}
        public DbSet<usuario> usuarios {get;set;}
        public DbSet<rol> roles {get;set;}
        public DbSet<estadoCompra> estadoCompras {get;set;}
        public DbSet<log> logs {get;set;}
        public DbSet<empresa> empresas {get;set;}
        public DbSet<categoria> categorias {get;set;}
        public DbSet<departamento> departamentos {get;set;}
        public DbSet<sucursal> sucursales {get;set;}




    }


   }
