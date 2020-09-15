using PermissionManager.Core.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace PermissionManager.Infrastructure.Database
{
    public class ApplicationDbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (!context.PermissionTypes.Any())
              await SeedPermissionTypes(context);
        }

        private static async Task SeedPermissionTypes(ApplicationDbContext context)
        {
            var entities = new PermissionType[]
            {
                new PermissionType()
                {
                    Id = 1,
                    Description = "Disease"
                },
                new PermissionType()
                {
                    Id = 2,
                    Description = "Diligence"
                },
                new PermissionType()
                {
                    Id = 3,
                    Description = "Study"
                }
            };

            await context.AddRangeAsync(entities);
            await context.SaveChangesAsync();
        }
    }
}
