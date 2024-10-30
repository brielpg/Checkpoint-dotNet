using Microsoft.EntityFrameworkCore;

namespace Checkpoint1GabrielPescarolli.Persistence
{
    public class Repository<Entity> where Entity : class
    {
        private readonly CheckpointDbContext _context;

        private readonly DbSet<Entity> _dbSet;

        public Repository(CheckpointDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Entity>();
        }

        public void Add(Entity entity)
        {
            _context.Add(entity);

            _context.SaveChanges();
        }

        public void Delete(Entity entity)
        {
            _context.Remove(entity);

            _context.SaveChanges();
        }

        public IEnumerable<Entity> GetAll()
        {
            return _dbSet.ToList();
        }

        public Entity GetById(int? id)
        {
            return _dbSet.Find(id);
        }

        public void Update(Entity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}