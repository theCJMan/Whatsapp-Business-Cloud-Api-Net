using Microsoft.EntityFrameworkCore;

namespace WhatsAppBusinessCloudAPI.Web.Data
{
	public class WebAppDBContext : DbContext
	{
		public IConfiguration _config { get; set; }

		public WebAppDBContext(IConfiguration config)
		{
			_config = config;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
		}

		public DbSet<WhatsAppSentMessage> whatsAppSentMessages { get; set; }
	}
}
