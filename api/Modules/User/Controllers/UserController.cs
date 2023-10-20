using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using PuppeteerSharp;

namespace api;


[ApiController]
[Authorize]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly ICompositeViewEngine _viewEngine;

    private readonly IUserService _service;
    private ITempDataProvider _tempDataProvider;

    public UserController(IUserService service, ICompositeViewEngine viewEngine, ITempDataProvider tempDataProvider)
    {
        _viewEngine = viewEngine;
        _service = service;
        _tempDataProvider = tempDataProvider;
    }
    
    [HttpPost]
    public async Task<UserResponseDto> Create([FromBody] UserRequestDto requestDto)
    {
        return await _service.CreateUserAsync(requestDto);
    }

    [HttpGet]
    public async Task<PaginationResponse<UserResponseDto>> GetAll([FromQuery] UserFilterRequestDto userFilterRequestDto, [FromQuery] PaginationRequest paginationRequest)
    {
        return await _service.GetUsersAsync(userFilterRequestDto, paginationRequest);
    }

    [HttpGet("{id}")]
    public async Task<UserResponseDto> GetById([FromRoute] Guid id)
    {
        return await _service.GetUserAsync(id);
    }

    // [HttpGet("generate-report")]
    // public async Task<IActionResult> GenerateReport([FromRoute] int id)
    // {
    //     IView view = _viewEngine.GetView("~/Views/User/GetById.cshtml", "~/Views/User/GetById.cshtml", false).View;

    //     var model = new UserModel
    //     {
    //         Id = Guid.NewGuid(),
    //         Email = "hge",
    //         Password = ""
    //     };

    //     var viewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
    //     {
    //         Model = model
    //     };

    //     var tempData = new TempDataDictionary(HttpContext, _tempDataProvider);

    //     using (var output = new StringWriter())
    //     {
    //         var viewContext = new ViewContext(
    //             new ActionContext(HttpContext, HttpContext.GetRouteData(), new ActionDescriptor()),
    //             view,
    //             viewData,
    //             tempData,
    //             output,
    //             new HtmlHelperOptions()
    //         );

    //         await view.RenderAsync(viewContext);

    //         var html = output.ToString();

    //         var pdf = await GeneratePDF.Execute(html);
    //         return File(pdf.ToArray(), "application/pdf");
    //     }

    // }
}
