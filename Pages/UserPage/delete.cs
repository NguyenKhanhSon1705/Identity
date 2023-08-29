using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

public class Delete : PageModel
{
    private readonly UserService userService;
    public Delete(UserService userService)
    {
        this.userService = userService;
    }
    
    [BindProperty]
    public User users { get; set; }
    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return Page();
        }
        var qr = (from pr in this.userService.Users
                    where pr.id == id
                    select pr);
        if(qr != null){
          users = await qr.FirstOrDefaultAsync();
        }
        return Page();
    }
    public async Task<IActionResult> OnPostAsync(int? id){
        if (id == null){
            return NotFound();
        }
        if(users != null){
            userService.Remove(users);
            await userService.SaveChangesAsync();
        }
        return RedirectToPage("./UserView");

    }
}