using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

[Table("TestUsers")]
public class User 
{
    [DisplayName("ID")]
    public int id { get; set; }
    [DisplayName("NAME")]

    public string name { get; set; } = "2999";
    [DisplayName("ADDRESS")]

    public string address { get; set; }
    [DisplayName("EMAIL")]
    
    public string email { get; set; }
    [DisplayName("ACCOUNT")]
    
    public string account { get; set; }
    [DisplayName("PASSWORD")]

    public string password { get; set; }

}