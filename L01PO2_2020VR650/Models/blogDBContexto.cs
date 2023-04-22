using System;
using Microsoft.EntityFrameworkCore;
using L01PO2_2020VR650.Models;
namespace L01PO2_2020VR650.Models

{
	public class blogDBContexto : DbContext
	{
		public blogDBContexto(DbContextOptions options) :base(options)
		{
		}
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Publicaciones> publicaciones { get; set; }
        public DbSet<Calificaciones> Calificaciones { get; set; }
        public DbSet<L01PO2_2020VR650.Models.Comentarios> Comentarios { get; set; } = default!;


    }
}

