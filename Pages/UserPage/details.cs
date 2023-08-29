using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

public class Detail : PageModel
{
    private readonly UserService userService;
    public Detail(UserService _userService)
    {
        this.userService = _userService;
    }
    public User users {get; set;}
    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var user = (from qr in userService.Users
                    where qr.id == id
                    select qr).FirstOrDefaultAsync();
        if(user != null){
            users = await user;
        }
        return Page();
    }
}