namespace LearningSystem.Services.Admin.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Services.Admin.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AdminUserService : IAdminUserService
    {
        private readonly LearningSystemDbContext db;

        public AdminUserService(LearningSystemDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<AdminUserListingServiceModel>> AllAsync()
        {
            return await this.db
                .Users
                .ProjectTo<AdminUserListingServiceModel>()
                .ToListAsync();
        }
    }
}
