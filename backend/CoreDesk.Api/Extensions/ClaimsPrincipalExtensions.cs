using System.Security.Claims;

namespace CoreDesk.Api.Extensions;

public static class ClaimsPrincipalExtensions
{
    public static Guid GetUserId(this ClaimsPrincipal user)
    {
        var value = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        return Guid.TryParse(value, out var userId) ? userId : Guid.Empty;
    }

    public static Guid GetCompanyId(this ClaimsPrincipal user)
    {
        var value = user.FindFirst("companyId")?.Value;

        return Guid.TryParse(value, out var companyId) ? companyId : Guid.Empty;
    }
}