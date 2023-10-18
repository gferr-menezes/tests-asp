public class ValidadeRolesMiddleware {
    private readonly RequestDelegate _next;

    public ValidadeRolesMiddleware(RequestDelegate next) {

    //    Console.WriteLine("####################");

        _next = next;
    }

    public async Task Invoke(HttpContext context) {

       // Console.WriteLine("ValidadeRolesMiddleware ########");
        // var user = context.User;
        // var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();

        // if (roles.Count == 0) {
        //     context.Response.StatusCode = (int) HttpStatusCode.Forbidden;
        //     await context.Response.WriteAsync("Forbidden");
        //     return;
        // }

        await _next(context);
    }
}