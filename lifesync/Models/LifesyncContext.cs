using Microsoft.EntityFrameworkCore;

namespace lifesync.Models
{
    public class LifesyncContext : DbContext
    {
        public LifesyncContext(DbContextOptions<LifesyncContext> options) : base(options)
        {

        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserContactModel> User_contact { get; set; }
        public DbSet<Registration> Logs { get; set; }
        public DbSet<FeedbackModel> Feedback { get; set; }
        public DbSet<EventsModel> Events { get; set; }
        public DbSet<EventLinksModel> Event_links { get; set; }
        public DbSet<EventImagesModel> Event_images { get; set; }
        public DbSet<EventContactModel> Event_contact { get; set; }
        public DbSet<BookedEventsModel> Booked_Events { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=FREYA-DTS;  User=sa; Password=\"Freya@123\"; TrustServerCertificate=true; Encrypt=true; Connection Timeout =30;database=lifeSync;Server=.");
                base.OnConfiguring(optionsBuilder);
            }
        }
    }
}
