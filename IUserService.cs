namespace APP.services;
using APP.models;

public interface IUserService{
    public List<User> GetAll();

    public User GetById(int id);

    public  void DeleteById(int id);

    public void AddUser(User user);

    public void Update(User user);
}