using Microsoft.EntityFrameworkCore;
using StudentDashboard.Web.Data;
using StudentDashboard.Web.Models;

namespace StudentDashboard.Web.Repositories;

public class EfRepository<T> : IRepository<T> where T : BaseEntity
{
    private readonly IDbContextFactory<AppDbContext> dbFactory;

    public EfRepository(IDbContextFactory<AppDbContext> dbFactory)
    {
        this.dbFactory = dbFactory;
    }

    public async Task<List<T>> GetAllAsync()
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        return await db.Set<T>().AsNoTracking().OrderByDescending(entity => entity.Id).ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        return await db.Set<T>().FindAsync(id);
    }

    public async Task<T> AddAsync(T entity)
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        db.Set<T>().Add(entity);
        await db.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        entity.Touch();
        db.Set<T>().Update(entity);
        await db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        await using var db = await dbFactory.CreateDbContextAsync();
        var entity = await db.Set<T>().FindAsync(id);
        if (entity is null)
        {
            return;
        }

        db.Set<T>().Remove(entity);
        await db.SaveChangesAsync();
    }
}
