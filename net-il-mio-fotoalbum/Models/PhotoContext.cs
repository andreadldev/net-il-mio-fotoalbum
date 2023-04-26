using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace net_il_mio_fotoalbum.Models
{
	public class PhotoContext : IdentityDbContext<IdentityUser>
    {
		public DbSet<Photo> Photos { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Message> Messages { get; set; }

		public PhotoContext() { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=db-fotoalbum;Integrated Security=True;TrustServerCertificate=true;Encrypt=false;");
		}

		public void Seed()
		{
			if (!Photos.Any())
			{
				var photoSeeder = new Photo[]
				{
					new
					(
						title: "Lago",
						description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec malesuada accumsan mi, vel aliquam massa placerat sit amet. Nulla sit amet vestibulum nulla.",
						url: "img/land1.jpg",
						visible: true
					),
					new
					(
						title: "Mountagne 1",
						description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec malesuada accumsan mi, vel aliquam massa placerat sit amet. Nulla sit amet vestibulum nulla.",
						url: "img/land2.jpg",
						visible: true
					),
					new
					(
						title: "Mountagne 2",
						description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec malesuada accumsan mi, vel aliquam massa placerat sit amet. Nulla sit amet vestibulum nulla.",
						url: "img/land3.jpg",
						visible: true
					),
					new
					(
						title: "Strada",
						description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec malesuada accumsan mi, vel aliquam massa placerat sit amet. Nulla sit amet vestibulum nulla.",
						url: "img/city1.jpg",
						visible: true
					),
					new
					(
						title: "Città 1",
						description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec malesuada accumsan mi, vel aliquam massa placerat sit amet. Nulla sit amet vestibulum nulla.",
						url: "img/city2.jpg",
						visible: true
					),
					new
					(
						title: "Città 2",
						description: "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec malesuada accumsan mi, vel aliquam massa placerat sit amet. Nulla sit amet vestibulum nulla.",
						url: "img/city3.jpg",
						visible: true
					),
				};
				Photos.AddRange(photoSeeder);
			}

			if (!Categories.Any())
			{
				var categorySeeder = new Category[] 
				{
					new()
					{
						Name = "Natura"
					},
					new()
					{
						Name = "Paesaggio urbano"
					},
					new()
					{
						Name = "Persone"
					}
				};
				Categories.AddRange(categorySeeder);
			}
			SaveChanges();
		}
	}
}
