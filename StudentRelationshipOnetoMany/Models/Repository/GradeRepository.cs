using StudentRelationshipOnetoMany.Interfaces;

namespace StudentRelationshipOnetoMany.Models.Repository
{
    public class GradeRepository : IGradeRepository
    {
        private readonly DataContext _context;
        public GradeRepository(DataContext context)
        {
            _context = context;
        }
        public bool Create(Grade entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Grade entity)
        {
            throw new NotImplementedException();
        }

        public Grade Get(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Grade> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(Grade entity)
        {
            throw new NotImplementedException();
        }
    }
}
