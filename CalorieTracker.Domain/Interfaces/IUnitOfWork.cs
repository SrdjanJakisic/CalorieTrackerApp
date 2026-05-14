using System;
using System.Collections.Generic;
using System.Text;

namespace CalorieTracker.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
