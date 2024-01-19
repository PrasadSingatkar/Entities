namespace APP.repositories;

using APP.models;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
public class MySqlRepository{
//============================================================================================================
    public MySqlRepository(){}
//============================================================================================================
    public List<User> GetAll(){

        List<User> users = new List<User>();

        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString=@"server=localhost; port=3306; user=root; password=root123; database=advjava";

        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = conn;
        cmd.CommandText="select * from users";

        try{
            conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read()){

                int id = int.Parse(reader["id"].ToString());
                string? name = reader["name"].ToString();
                string? email = reader["email"].ToString();
                string? address = reader["address"].ToString();

                User u = new User(id,name,email,address);
                users.Add(u);
            }
            reader.Close();
        }
        catch(Exception e){
            Console.WriteLine(e.Message);
        }
        finally{
            conn.Close();
        }
        return users;
    }
//===========================================================================================================
    public User GetById(int uid){
        User user = new User();

        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString=@"server=localhost; port=3306; user=root; password=root123; database=advjava";

        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "select * from users where id="+uid;

        try{
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read()){
                int userid = int.Parse(reader["id"].ToString());
                string username = reader["name"].ToString();
                string useremail = reader["email"].ToString();
                string useraddress = reader["address"].ToString();

                user.userId = userid;
                user.userName = username;
                user.userEmail = useremail;
                user.userAddress = useraddress;
            }

            Console.WriteLine(user.userId+" "+user.userName+" "+user.userEmail+" "+user.userAddress);

            reader.Close();
        }
        catch(Exception e){
            Console.WriteLine(e.Message);
        }
        finally{
            conn.Close();
        }
        return user;
    }
//==================================================================================================================
    public void Delete(int uid){
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString=@"server=localhost; port=3306; user=root; password=root123; database=advjava";

        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "delete from users where id="+uid;
        try{
            conn.Open();
            cmd.ExecuteNonQuery();
        }
        catch(Exception e){
            Console.WriteLine(e.Message);
        }
        finally{
            conn.Close();
        }
    }
//================================================================================================================

    public void Insert(User user){
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString=@"server=localhost; port=3306; user=root; password=root123; database=advjava";
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = conn;
        cmd.CommandText="insert into users values("+user.userId+",'"+user.userName+"','"+user.userEmail+"','"+user.userAddress+"')";
        try{
            conn.Open();
            cmd.ExecuteNonQuery();
        }
        catch(Exception e){
            Console.WriteLine(e.Message);
        }
        finally{
            conn.Close();
        }
    }
//==================================================================================================================
    public void Update(User user){
        MySqlConnection conn = new MySqlConnection();
        conn.ConnectionString=@"server=localhost; port=3306; user=root; password=root123; database=advjava";
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = conn;
        cmd.CommandText="update users set name='"+user.userName+"', email='"+user.userEmail+"', address='"+user.userAddress+"' where id="+user.userId;
        try{
            conn.Open();
            cmd.ExecuteNonQuery();
        }
        catch(Exception e){
            Console.WriteLine(e.Message);
        }
        finally{
            conn.Close();
        }
    }
//===============================================================================================================
}