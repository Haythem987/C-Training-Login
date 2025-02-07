namespace ConsoleAppTest;

public class Program
{
    public static List<Useritem> User = new();


    public static void Register()
    {
        Console.WriteLine("请输入用户名");
        var username = Console.ReadLine();
        if (username == "")
        {
            Console.WriteLine("输入内容为空，请重新输入");
            Register();
        }

        Console.WriteLine("请输入密码");
        var password = Console.ReadLine();
        if (password == "")
        {
            Console.WriteLine("输入内容为空，请重新输入");
            Register();
        }

        Console.WriteLine("请输入邮箱");
        var email = Console.ReadLine();
        if (email == "")
        {
            Console.WriteLine("输入内容为空，请重新输入");
            Register();
        }

        if (User.Any(x => x.Email == email))
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
        if (!User.Any())
        {
            Console.WriteLine("未有用户注册过");
        }
        else
        {
            Console.WriteLine("请输入邮箱");
            var email = Console.ReadLine();
            if (email == "")
            {
                Console.WriteLine("输入内容为空，请重新输入");
                Login();
            }

            Console.WriteLine("请输入密码");
            var password = Console.ReadLine();
            if (password == "")
            {
                Console.WriteLine("输入内容为空，请重新输入");
                Login();
            }

            if (User.Any(x => x.Username == email && x.Password == password))
            {
                var userinfo = User.FirstOrDefault(x => x.Email == email && x.Password == password);
                Console.WriteLine($"登陆成功，{userinfo.Username}");
            }
            else if (User.Any(x => x.Username == email && x.Password != password))
            {
                Console.WriteLine("密码错误");
            }
            else if (User.Any(x => x.Email != email))
            {
                Console.WriteLine("邮箱错误");
            }
            else
            {
                Console.WriteLine("无此用户");
            }
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
            try
            {
                var inputnum = Convert.ToInt32(input);
                if (inputnum is 0 or > 4)
                {
                    Console.WriteLine("请输入在1-4之间的整数");
                    continue;
                }

                switch (inputnum)
                {
                    case 1:
                        Register();
                        break;
                    case 2:
                        Login();
                        break;
                    case 3:
                        foreach (var item in User)
                            Console.WriteLine($"用户名:{item.Username},密码:{item.Password},邮箱:{item.Email}");
                        break;
                    case 4:
                        Console.WriteLine("再见");
                        Environment.Exit(0);
                        break;
                }
            }

            catch
            {
                Console.WriteLine("你在输毛");
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