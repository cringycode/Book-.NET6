using Book.Models;
using Book.DataAccess.Data;
using Book.DataAccess.Repository.IRepository;


namespace Book.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private ApplicationDbContext _db;

        public CoverTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(CoverType obj)
        {
            _db.CoverTypes.Update(obj);
        }
    }
}