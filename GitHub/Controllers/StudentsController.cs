using GitHub.Database;
using GitHub.Filters.StudentFilters;
using GitHub.Interfaces.StudentsInterfaces;
using GitHub.Models;
using GitHub.Migrations;
using Microsoft.AspNetCore.Mvc;
namespace GitHub.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class StudentsController : ControllerBase
	{
		private readonly ILogger<StudentsController> _logger;
		private readonly IStudentService _studentService;
		public StudentDbContext _dbcontext;

		public StudentsController(ILogger<StudentsController> logger, IStudentService studentService, StudentDbContext context)
		{
			_logger = logger;
			_studentService = studentService;
			_dbcontext = context;
		}

		[HttpPost("GetStudentsByGroup")]
		public async Task<IActionResult> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
		{
			var students = await _studentService.GetStudentsByGroupAsync(filter, cancellationToken);

			return Ok(students);
		}

		[HttpPost("GetStudentsByIdGroup")]
		public async Task<IActionResult> GetStudentsByGroupIdAsync(StudentGroupId filter, CancellationToken cancellationToken = default)
		{
			var students = await _studentService.GetStudentsByGroupIdAsync(filter, cancellationToken);

			return Ok(students);
		}

		[HttpPost("GetStudentsById")]
		public async Task<IActionResult> GetStudentsByIdAsync(StudentIdFilter filterid, CancellationToken cancellationToken = default)
		{
			var students = await _studentService.GetStudentsByIdAsync(filterid, cancellationToken);

			return Ok(students);
		}

		[HttpPost("GetStudentsByName")]
		public async Task<IActionResult> GetStudentsByNameAsync(StudentNameFilter filterid, CancellationToken cancellationToken = default)
		{
			var students = await _studentService.GetStudentsByNameAsync(filterid, cancellationToken);

			return Ok(students);
		}


		[HttpPost("AddStudent", Name = "AddStudent")]
		public IActionResult CreateStudent([FromBody] StudentAddNewData filter)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var student = new Student();
			student.FirstName = filter.FirstName;
			student.LastName = filter.LastName;
			student.MiddleName = filter.MiddleName;
			student.GroupId = _dbcontext.Set<Models.Group>().FirstOrDefault(g => g.GroupId == filter.GroupId).GroupId;

			_dbcontext.Set<Student>().Add(student);
			_dbcontext.SaveChanges();
			return Ok(student);
		}

		[HttpPut("EditStudent")]
		public IActionResult UpdateStudent(int id, [FromBody] StudentAddNewData filter)
		{
			var existingStudent = _dbcontext.Set<Models.Student>().FirstOrDefault(g => g.StudentId == id);

			if (existingStudent == null)
			{
				return NotFound();
			}

			existingStudent.FirstName = filter.FirstName;
			existingStudent.LastName = filter.LastName;
			existingStudent.MiddleName = filter.MiddleName;
			existingStudent.GroupId = _dbcontext.Set<Models.Group>().FirstOrDefault(g => g.GroupId == filter.GroupId).GroupId;
			_dbcontext.SaveChanges();

			return Ok();
		}


		[HttpDelete("DeleteStudent")]
		public IActionResult DeleteGroup(int id)
		{
			var existingStudent = _dbcontext.Set<Student>().FirstOrDefault(g => g.StudentId == id);

			if (existingStudent == null)
			{
				return NotFound();
			}
			_dbcontext.Set<Student>().Remove(existingStudent);
			_dbcontext.SaveChanges();

			return Ok();
		}
	}
}