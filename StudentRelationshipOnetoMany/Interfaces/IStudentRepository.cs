using Microsoft.AspNetCore.Mvc;
using StudentRelationshipOnetoMany.DTO;
using StudentRelationshipOnetoMany.Models;

namespace StudentRelationshipOnetoMany.Interfaces
{
    public interface IStudentRepository : IRepositoryBase<Student>
    {
        public  Task<ActionResult<List<Student>>> GetRepo();
        public  Task<ActionResult<Student>> GetRepoByID(int id);
        public Task<ActionResult<Student>> PostRepo(StudentDto stu);
        public Task<ActionResult<Grade>> PostGradeRepo(GradeDto grade);
        public Task<ActionResult<List<Student>>> UpdateByRepo(StudentUpdateDto student); 
        public Task<ActionResult<List<Student>>> DeleteByRepo(int id); 
        
    }
}

