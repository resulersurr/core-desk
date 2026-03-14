using CoreDesk.Api.Extensions;
using CoreDesk.Application.DTOs.Projects;
using CoreDesk.Domain.Entities;
using CoreDesk.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreDesk.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly CoreDeskDbContext _context;

    public ProjectsController(CoreDeskDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var companyId = User.GetCompanyId();

        var projects = await _context.Projects
            .Where(x => x.CompanyId == companyId)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();

        return Ok(projects);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var companyId = User.GetCompanyId();

        var project = await _context.Projects
            .FirstOrDefaultAsync(x => x.Id == id && x.CompanyId == companyId);

        if (project == null)
            return NotFound();

        return Ok(project);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProjectRequest request)
    {
        var companyId = User.GetCompanyId();
        var userId = User.GetUserId();

        var project = new Project
        {
            Name = request.Name,
            Description = request.Description,
            CreatedByUserId = userId,
            CompanyId = companyId
        };

        _context.Projects.Add(project);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = project.Id }, project);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProjectRequest request)
    {
        var companyId = User.GetCompanyId();

        var project = await _context.Projects
            .FirstOrDefaultAsync(x => x.Id == id && x.CompanyId == companyId);

        if (project == null)
            return NotFound();

        project.Name = request.Name;
        project.Description = request.Description;

        await _context.SaveChangesAsync();

        return Ok(project);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var companyId = User.GetCompanyId();

        var project = await _context.Projects
            .FirstOrDefaultAsync(x => x.Id == id && x.CompanyId == companyId);

        if (project == null)
            return NotFound();

        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}