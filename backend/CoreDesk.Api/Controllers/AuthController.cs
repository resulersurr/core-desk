using CoreDesk.Application.DTOs.Auth;
using CoreDesk.Domain.Entities;
using CoreDesk.Infrastructure.Persistence;
using CoreDesk.Infrastructure.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreDesk.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly CoreDeskDbContext _context;
    private readonly JwtTokenGenerator _jwtTokenGenerator;

    public AuthController(CoreDeskDbContext context, JwtTokenGenerator jwtTokenGenerator)
    {
        _context = context;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var email = request.Email.Trim().ToLower();

        var existingUser = await _context.Users
            .FirstOrDefaultAsync(x => x.Email == email);

        if (existingUser != null)
            return BadRequest(new { message = "Bu e-posta adresi zaten kayıtlı." });

        var company = new Company
        {
            Name = request.CompanyName,
            Slug = GenerateSlug(request.CompanyName)
        };

        var user = new User
        {
            FullName = request.FullName,
            Email = email,
            PasswordHash = PasswordHasher.Hash(request.Password),
            CompanyId = company.Id
        };

        _context.Companies.Add(company);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        var token = _jwtTokenGenerator.GenerateToken(user);

        var response = new AuthResponse
        {
            Token = token,
            FullName = user.FullName,
            Email = user.Email
        };

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var email = request.Email.Trim().ToLower();

        var user = await _context.Users
            .FirstOrDefaultAsync(x => x.Email == email);

        if (user == null)
            return Unauthorized(new { message = "E-posta veya şifre hatalı." });

        var isPasswordValid = PasswordHasher.Verify(request.Password, user.PasswordHash);

        if (!isPasswordValid)
            return Unauthorized(new { message = "E-posta veya şifre hatalı." });

        var token = _jwtTokenGenerator.GenerateToken(user);

        var response = new AuthResponse
        {
            Token = token,
            FullName = user.FullName,
            Email = user.Email
        };

        return Ok(response);
    }

    private static string GenerateSlug(string companyName)
    {
        return companyName
            .Trim()
            .ToLower()
            .Replace(" ", "-");
    }
}