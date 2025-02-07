namespace ConsoleAppTest;

public class Program
{
    public static List<Useritem> User = new();


    public static void Register()
    {
        Console.WriteLine("请输入用户名");
        var username = Console.ReadLine();
        Console.WriteLine("请输入密码");
        var password = Console.ReadLine();
        Console.WriteLine("请输入邮箱");
        var email = Console.ReadLine();
        if (User.Any(x => x.Username == username))
        {
            Console.WriteLine("SB你注册过了");
        }
        else
        {
            User.Add(new Useritem { Username = username, Password = password, Email = email });
            Console.WriteLine("注册成功");
        }
    }

    public static void Login()
    {
        Console.WriteLine("请输入用户名");
        var username = Console.ReadLine();
        Console.WriteLine("请输入密码");
        var password = Console.ReadLine();
        if (User.Any(x=>x.Username==username && x.Password==password))
        {
            Console.WriteLine("登陆成功");
        }
        else if (User.Any(x => x.Username == username && x.Password != password))
        {
            Console.WriteLine("密码错误");
        }
        else
        {
            Console.WriteLine("无此用户");
        }
    }


    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("请输入数字选择功能");
            Console.WriteLine("1.注册");
            Console.WriteLine("2.登录");
            Console.WriteLine("3.查询用户列表");
            Console.WriteLine("4.退出");
            var input = Console.ReadLine();
            if (input == "1")
            {
                Register();
            }
            else if (input == "2")
            {
                Login();
            }
            else if (input == "3")
            {
                foreach (var item in User) Console.WriteLine($"用户名:{item.Username},密码:{item.Password},邮箱:{item.Email}");
            }


            else if (input == "4")
            {
                Console.WriteLine("再见");
                break;
            }
        }
    }

    public class Useritem
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}