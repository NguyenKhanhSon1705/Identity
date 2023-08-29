using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

public class Update : PageModel
{
    private readonly UserService userService;
    public Update(UserService userService)
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
        var qr = (from q in this.userService.Users
                  where q.id == id
                  select q).FirstOrDefaultAsync();
        if (qr != null)
        {
            users = await qr;
        }
        return Page();
    }
    public async Task<IActionResult> OnPostAsync(int id)
    {
        if(ModelState.IsValid){
               var a =  userService.Users.Attach(users).State = EntityState.Modified;
            try
            {
                await userService.SaveChangesAsync();
            }catch (DbUpdateConcurrencyException ex){
                System.Console.WriteLine(ex.Message);
            }
        }
        return RedirectToPage("./UserView");
    }
}