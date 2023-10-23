namespace SecondHandCarDemoRepo.Data
{
    public interface IRepository<Car>
    {
        Task<Car> GetByIdAsync(int id);
        Task<IEnumerable<Car>> GetAllAsync();
        Task AddAsync(Car entity);
        Task UpdateAsync(Car entity);
        Task DeleteAsync(int id);
    }
}
