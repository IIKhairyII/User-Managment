using Application.Requests.User.Commands;
using Application.Requests.User.Queries;
using Application.Responses.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace User.Presentation.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IMediator _mediator;

        public UserDto? UserDto { get; set; }
        public IndexModel(ILogger<IndexModel> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<IActionResult> OnGet(long id)
        {
            
            if (id < 1)
                return RedirectToPage("/Shared/Login");
            UserDto = await _mediator.Send(new GetProfileByIdQueryDto() { Id = id});

            if(UserDto is null)
                return RedirectToPage("/Shared/Login");

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                    return Page();
                await _mediator.Send(new EditProfileCommandDto() { userDto = UserDto });
                return Page();
            }
            catch (Exception ex) {

                ModelState.AddModelError(string.Empty, "Error while updating");
                return Page();
            }
        }
    }
}
