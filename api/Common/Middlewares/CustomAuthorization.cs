using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Common.Middlewares;
public class CustomAuthorization
{
    
    public static bool ValidadeClains(HttpContext context, string clainName, string clainValue)
    {

        


        return false;
        
    }


}

public class ClaimsAuthorizeAttribute : TypeFilterAttribute
{
    public ClaimsAuthorizeAttribute(string clainName, string clainValue) : base(typeof(RequerimentClaimFilter))
    {
        Arguments = new object[] { new Claim(clainName, clainValue) };
    }
}

public class RequerimentClaimFilter : IAuthorizationFilter
{
    private readonly Claim _claim;

    public RequerimentClaimFilter(Claim claim)
    {
        _claim = claim;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if(!context.HttpContext.User.Identity.IsAuthenticated)
        {
            context.Result = new StatusCodeResult(401);
            return;
        }

        if(!CustomAuthorization.ValidadeClains(context.HttpContext, _claim.Type, _claim.Value))
        {
            context.Result = new StatusCodeResult(403);
            return;
        }
    }
}