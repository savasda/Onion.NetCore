using Infrastucture.Interfaces.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Services.Maps
{
    public class UserMap
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(d => d.Id);
        }
    }
}
