using System.Security.Claims;

namespace API.Extensions
{
    public static class ClaimsPrincipleExtensions
    {
        public static string GetUserName( this ClaimsPrincipal user)
        {
            //represents unique name set in token service
            return user.FindFirst(ClaimTypes.Name)?.Value;
        }

           public static int GetUserId( this ClaimsPrincipal user)
        {
            //represents unique id or NameIdentifier set in token service
            return int.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
    }
}