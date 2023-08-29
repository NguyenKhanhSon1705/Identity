
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class UserPages : PageModel
{
    private readonly UserService userService;
    public UserPages(UserService _userService)
    {
        userService = _userService;
    }
    [BindProperty]
    public User user { get; set; }
    public IActionResult OnGet(){
        return Page();
    }
    public async Task<IActionResult> OnPostAsync(){
        if(!ModelState.IsValid){
            return Page();
        }

        userService.Add(user);
        await userService.SaveChangesAsync();

        return  RedirectToPage("./UserView");

    }
}