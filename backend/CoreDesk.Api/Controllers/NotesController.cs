using CoreDesk.Api.Extensions;
using CoreDesk.Application.DTOs.Notes;
using CoreDesk.Domain.Entities;
using CoreDesk.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreDesk.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class NotesController : ControllerBase
{
    private readonly CoreDeskDbContext _context;

    public NotesController(CoreDeskDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var companyId = User.GetCompanyId();

        var notes = await _context.Notes
            .Where(x => x.CompanyId == companyId)
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();

        return Ok(notes);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var companyId = User.GetCompanyId();

        var note = await _context.Notes
            .FirstOrDefaultAsync(x => x.Id == id && x.CompanyId == companyId);

        if (note == null)
            return NotFound();

        return Ok(note);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateNoteRequest request)
    {
        var companyId = User.GetCompanyId();
        var userId = User.GetUserId();

        var note = new Note
        {
            Title = request.Title,
            Content = request.Content,
            ProjectId = request.ProjectId,
            CreatedByUserId = userId,
            CompanyId = companyId
        };

        _context.Notes.Add(note);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = note.Id }, note);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateNoteRequest request)
    {
        var companyId = User.GetCompanyId();

        var note = await _context.Notes
            .FirstOrDefaultAsync(x => x.Id == id && x.CompanyId == companyId);

        if (note == null)
            return NotFound();

        note.Title = request.Title;
        note.Content = request.Content;
        note.ProjectId = request.ProjectId;

        await _context.SaveChangesAsync();

        return Ok(note);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var companyId = User.GetCompanyId();

        var note = await _context.Notes
            .FirstOrDefaultAsync(x => x.Id == id && x.CompanyId == companyId);

        if (note == null)
            return NotFound();

        _context.Notes.Remove(note);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}