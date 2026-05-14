using CalorieTracker.Domain.Interfaces;
using CalorieTracker.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _db;
        public UnitOfWork(AppDbContext db)
        {
            _db = db;
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _db.SaveChangesAsync();

        }
    }
}
