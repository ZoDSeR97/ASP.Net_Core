namespace ViewModelFun.Models;
public class User{
    public string FirstName {get;}
    public string LastName {get;}
    public User(string FirstName, string LastName){
        this.FirstName = FirstName;
        this.LastName = LastName;
    }
}