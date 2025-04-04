using Microsoft.AspNetCore.Http;

namespace Restaurants.Application.User;

public class UserContext(IHttpContextAccessor httpContextAccessor)
{
    public CurrentUser GetCurrentUser()
    {
        var user = httpContextAccessor?.HttpContext?.User;
    }
}
