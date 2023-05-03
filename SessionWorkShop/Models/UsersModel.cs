namespace SessionWorkShop.Models;
public class Users{
    public static Dictionary<string, User> users = new Dictionary<string, User>();
    public void clear() => users=new Dictionary<string, User>();
}