using Microsoft.AspNetCore.Mvc;
using Week1Api.Data;

namespace Week1Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly AppDbContext _context;

    public StudentsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/students
    [HttpGet]
    public IActionResult GetAll()
    {
        var students = _context.Students.ToList();
        return Ok(students);
    }

    // GET: api/students/1
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var student = _context.Students.Find(id);
        if (student == null)
            return NotFound();

        return Ok(student);
    }

    // POST: api/students
    [HttpPost]
    public IActionResult Create(Student student)
    {
        _context.Students.Add(student);
        _context.SaveChanges();

        return Ok(student);
    }
}