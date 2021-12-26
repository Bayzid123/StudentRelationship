using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRelationshipOnetoMany.DTO;
using StudentRelationshipOnetoMany.Interfaces;
using StudentRelationshipOnetoMany.Models;

namespace StudentRelationshipOnetoMany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IStudentRepository _studentRepository;

        public StudentController(DataContext context, IStudentRepository studentRepository)
        {
            _context = context;
            _studentRepository = studentRepository;
        }

        [HttpGet("FromRepo")]
        public async Task<ActionResult<List<Student>>> GetFromRepo()
        {
            return await _studentRepository.GetRepo();
        }

        [HttpGet("by id FromRepo")]

        public async Task<ActionResult<Student>> GetFromRepoByID(int id)
        {
            return await _studentRepository.GetRepoByID(id);
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> Get(int studentId)
        {
            var students = await _context.Students
                .Include(x => x.Grade)
                .Where(c => c.Id == studentId)
                .ToListAsync();
            return Ok(students);
        }
        [HttpGet("get by id")]
        public async Task<ActionResult<List<Student>>> GetbyID(int id)
        {
            var data = await _context.Students.FindAsync(id);
            if (data == null)
                return BadRequest("id not found");
            return Ok(data);
        }

        [HttpPost("student post by repo")]

        public async Task<ActionResult<Student>> Post(StudentDto studentrepo)
        {
            return await _studentRepository.PostRepo(studentrepo);
        }

        [HttpPost("grade post by repo")]

        public async Task<ActionResult<Grade>> PostGrade(GradeDto grade)
        {
            return await _studentRepository.PostGradeRepo(grade);
        }

        [HttpPost("Student Table Post")]
        public async Task<ActionResult<List<Student>>> CreateStudent(StudentDto student)
        {
            var newStudent = new Student
            {
                Name = student.Name,
                CurrentGradeId = student.CurrentGradeId,
            };

            _context.Students.Add(newStudent);
            await _context.SaveChangesAsync();
            return await Get(newStudent.Id);
        }
        [HttpPost("Grade post")]
        public async Task<ActionResult<List<Student>>> CreateGrade(GradeDto grade)
        {
            var newGrade = new Grade
            {
                GradeName = grade.GradeName,
                Section = grade.Section,
            };

            _context.Grades.Add(newGrade);
            await _context.SaveChangesAsync();

            return Ok(newGrade);
        }

        [HttpPut("Upadate student by repo")]

        public async Task<ActionResult<List<Student>>> UpdateStudentByRepo(StudentUpdateDto student)
        {
            return Ok(await _studentRepository.UpdateByRepo(student));
        }

        [HttpPut("update Student")]

        public async Task<ActionResult<List<Student>>> UpdateStudent(StudentUpdateDto student)
        {
            var dbstudent = await _context.Students.FindAsync(student.Id);
            if (dbstudent == null)
                return BadRequest("Student not found");

            dbstudent.Name= student.Name;
            dbstudent.Id= student.Id;
            dbstudent.CurrentGradeId= student.CurrentGradeId;

            await _context.SaveChangesAsync();
            return Ok(await _context.Students.ToListAsync());
        }

        [HttpDelete("Delete by repo")]

        public async Task<ActionResult<List<Student>>> DeleteStudentByRepo(int id)
        {
            return Ok(await _studentRepository.DeleteByRepo(id));
        }

        [HttpDelete("delete by id")]
        public async Task<ActionResult<List<Student>>> DeleteStudent(int id)
        {
            var data = await _context.Students.FindAsync(id);
            if (data == null)
                return BadRequest("id not found");
            _context.Students.Remove(data);
            await _context.SaveChangesAsync();
            return Ok(await _context.Students.ToListAsync());
        }
    }
}
