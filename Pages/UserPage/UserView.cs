using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

public class ViewUser : PageModel{
    private readonly UserService userService;
    public ViewUser(UserService userService){
        this.userService = userService;
    }

    public List<User> users { get; set; }
    public async Task OnGet(){
        var qr = from user in userService.Users
        select user;

        users = await qr.ToListAsync();
        
    }

}