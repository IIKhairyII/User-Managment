using Application.Requests.User.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace User.Presentation.Pages.Shared
{

    [BindProperties]
    public class LoginModel : PageModel
    {
        private readonly IMediator _mediator;
        public GetProfileQueryDto UserDto { get; set; } = new();
        public LoginModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task OnGet()
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }
        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                    return Page();
                var user = await _mediator.Send(UserDto);
             if (user is null)
                {
                    TempData["InvalidUser"] = "User wasn't found... Make sure you inserted correct credentials!";
                    return RedirectToPage("/Shared/Login");
                }
                TempData["InvalidUser"] = null;
                return RedirectToPage("/Index", new { id = user.Id });
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error");
            }
        }
    }
}
