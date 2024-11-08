// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using System.Reflection;
using TTADotNetCore.Database.Models;

Console.WriteLine("Hello, World!");

//AppDbContext db = new AppDbContext();
//var lst=db.TblBlogs.ToList();

var blog = new BlogModel
{
    Id = 1,
    Title="Test Title",
    Author="Testing Author",
    Content="Testing content"
};
//Encode,Decode,Encryption,Decryption

//string JsonStr = JsonConvert.SerializeObject(blog,Formatting.Indented); // C# to Json
string JsonStr = blog.ToJson();


Console.WriteLine(JsonStr);
string JsonStr2 = """{"Id":1,"Title":"TestTitle","Author":"TestAuthor","Content":"TestContent"}"""; //No case sensitive all the same
var blog2=JsonConvert.DeserializeObject<BlogModel>(JsonStr2);
Console.WriteLine(blog2.Title);
Console.ReadLine();
public class BlogModel
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Content { get; set; }
}

public static class Extensions  // Devcode
{
    public static string ToJson(this Object obj)
    {
        string JsonStr = JsonConvert.SerializeObject(obj, Formatting.Indented); // C# to Json
        return JsonStr;
    }
}
