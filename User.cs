namespace APP.models;
[Serializable]
public class User{
    public int userId{get; set;}
    public string? userName{get; set;}
    public string? userEmail{get; set;}
    public string? userAddress{get; set;}

    public User(){
        Console.WriteLine("Inside user constructor ...");
    }
    public User(int userId, string userName, string userEmail, string userAddress){
        Console.WriteLine("Inside parameterized constructor ...");
        this.userId = userId;
        this.userName = userName;
        this.userEmail = userEmail;
        this.userAddress = userAddress;
    }

}