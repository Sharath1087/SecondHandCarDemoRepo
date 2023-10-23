using Microsoft.EntityFrameworkCore;

namespace SecondHandCarDemoRepo.Data
{
    public class Repository<Car> : IRepository<Car> where Car : class
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Car entity)
        {
            await _context.Set<Car>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if(entity != null)
            {
                _context.Set<Car>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await _context.Set<Car>().ToListAsync();
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            return await _context.Set<Car>().FindAsync(id);
        }

        public async Task UpdateAsync(Car entity)
        {
            _context.Set<Car>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
