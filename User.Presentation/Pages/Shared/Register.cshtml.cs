using Application.DTOs.User;
using Application.Requests.User.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace User.Presentation.Pages.Shared
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        private readonly IMediator _mediator;
        public UserDto UserDto { get; set; }
        public RegisterModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                    return Page();
                int result = await _mediator.Send(new AddProfileCommandDto() { userDto = UserDto });
                if (result > 0)
                {
                    TempData["Registered"] = "The user was registerd successfully...Please Login";
                    TempData["RegisterFailure"] = null;
                    return RedirectToPage("/Shared/Login");
                }

                TempData["RegisterFailure"] = "User wasn't registered....please try again!!";
                return Page();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Error while registring");
                return Page();
            }
        }
    }
}
