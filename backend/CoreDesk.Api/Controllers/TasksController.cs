using CoreDesk.Api.Extensions;
using CoreDesk.Application.DTOs.Tasks;
using CoreDesk.Domain.Entities;
using CoreDesk.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreDesk.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly CoreDeskDbContext _context;

    public TasksController(CoreDeskDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var companyId = User.GetCompanyId();

        var tasks = await _context.Tasks
            .Where(x => x.CompanyId == companyId)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();

        return Ok(tasks);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var companyId = User.GetCompanyId();

        var task = await _context.Tasks
            .FirstOrDefaultAsync(x => x.Id == id && x.CompanyId == companyId);

        if (task == null)
            return NotFound();

        return Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTaskRequest request)
    {
        var companyId = User.GetCompanyId();
        var userId = User.GetUserId();

        var task = new TaskItem
        {
            Title = request.Title,
            Description = request.Description,
            Status = request.Status,
            Priority = request.Priority,
            DueDate = request.DueDate,
            ProjectId = request.ProjectId,
            CreatedByUserId = userId,
            CompanyId = companyId
        };

        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTaskRequest request)
    {
        var companyId = User.GetCompanyId();

        var task = await _context.Tasks
            .FirstOrDefaultAsync(x => x.Id == id && x.CompanyId == companyId);

        if (task == null)
            return NotFound();

        task.Title = request.Title;
        task.Description = request.Description;
        task.Status = request.Status;
        task.Priority = request.Priority;
        task.DueDate = request.DueDate;

        await _context.SaveChangesAsync();

        return Ok(task);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var companyId = User.GetCompanyId();

        var task = await _context.Tasks
            .FirstOrDefaultAsync(x => x.Id == id && x.CompanyId == companyId);

        if (task == null)
            return NotFound();

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}