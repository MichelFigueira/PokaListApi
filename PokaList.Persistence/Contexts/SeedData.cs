using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PokaList.Domain;

namespace PokaList.Persistence.Contexts
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, int userId)
        {
            await using (var context = new PokaListContext(
                serviceProvider.GetRequiredService<DbContextOptions<PokaListContext>>()))
            {
                SeedDB(context, userId);
            }
        }

        public static void SeedDB(PokaListContext context, int userId)
        {
            context.Groups.AddRange(
                new Group
                {
                    Title = "Group 1",
                    UserId = userId
                },
                new Group
                {
                    Title = "Group 2",
                    UserId = userId
                }
            );

            context.Pokas.AddRange(
                new Poka
                {
                    Title = "Blabla",
                    Description = "blabla 123",
                    GroupId = 1,
                    UserId = userId
                },
                new Poka
                {
                    Title = "Blabla 2",
                    Description = "blabla 1234",
                    GroupId = 2,
                    UserId = userId
                }
            );

            context.SaveChanges();
        }

    }
}