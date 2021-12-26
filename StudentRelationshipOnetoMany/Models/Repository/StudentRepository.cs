using Microsoft.AspNetCore.Mvc;
using StudentRelationshipOnetoMany.DTO;
using StudentRelationshipOnetoMany.Interfaces;

namespace StudentRelationshipOnetoMany.Models.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext _context;
        private object _studentRepository;

        public StudentRepository(DataContext context)
        {
            _context = context;
        }

        //get all info from students table
        public async Task<ActionResult<List<Student>>> GetRepo()
        {
            return (await _context.Students.ToListAsync());
        }

        //get info from students table by id
        public async Task<ActionResult<Student>> GetRepoByID(int id)
        {
            {
                var data = await _context.Students.FindAsync(id);
                if (data == null)
                    Console.WriteLine("id not found");
                return data;
            }
        }

        //post student info into students table

        public async Task<ActionResult<Student>> PostRepo(StudentDto student)
        {
            var newStudent = new Student
            {
                Name = student.Name,
                CurrentGradeId = student.CurrentGradeId,
            };

            _context.Students.Add(newStudent);
            await _context.SaveChangesAsync();
            return (newStudent);
        }

        //post grade info into grades table

        public async Task<ActionResult<Grade>> PostGradeRepo(GradeDto grade)
        {
            var newGrade = new Grade
            {
                GradeName = grade.GradeName,
                Section = grade.Section,
            };

            _context.Grades.Add(newGrade);
            await _context.SaveChangesAsync();
            return (newGrade);
        }

        //update student info into student table

        public async Task<ActionResult<List<Student>>> UpdateByRepo(StudentUpdateDto student)
        {
            var dbstudent = await _context.Students.FindAsync(student.Id);
            if (dbstudent == null)
                Console.WriteLine("Student not found");

            dbstudent.Name = student.Name;
            dbstudent.Id = student.Id;
            dbstudent.CurrentGradeId = student.CurrentGradeId;

            await _context.SaveChangesAsync();
            return (await _context.Students.ToListAsync());
        }

        //Delete student from student table
        public async Task<ActionResult<List<Student>>> DeleteByRepo(int id)
        {
            var data = await _context.Students.FindAsync(id);
            if (data == null)
                Console.WriteLine("id not found");
            _context.Students.Remove(data);
            await _context.SaveChangesAsync();
            return (await _context.Students.ToListAsync());
        }

        public bool Create(Student entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Student entity)
        {
            throw new NotImplementedException();
        }

        public Student Get(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(Student entity)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<List<Student>>> GetRepoByID()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<Student>> PostRepo()
        {
            throw new NotImplementedException();
        }
    }
}
