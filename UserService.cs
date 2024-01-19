using APP.models;
using APP.repositories;

namespace APP.services;

public class UserService : IUserService{
    public List<User> GetAll(){
        List<User> users = new List<User>();
        MySqlRepository repo = new MySqlRepository(); // DB file
        users = repo.GetAll();
        return users;
    }

    public User GetById(int id){
        User user = new User();
        MySqlRepository repo = new MySqlRepository();
        user = repo.GetById(id);
        return user;
    }

    public void DeleteById(int id){
        MySqlRepository repo = new MySqlRepository();
        repo.Delete(id);
    }

    public void AddUser(User user){
        MySqlRepository repo = new MySqlRepository();
        repo.Insert(user);
    }

    public void Update(User user){
        MySqlRepository repo = new MySqlRepository();
        repo.Update(user);
    }
}