namespace ConsoleAppTest;

public class Program
{
    private static readonly List<UserItem> User = [];


    private static void Register()
    {
        var email = "";
        var username = "";
        var password = "";
        
        var emailed = false;
        while (emailed == false)
        {
            Console.WriteLine("请输入邮箱");
            email = Console.ReadLine();
            if (string.IsNullOrEmpty(email))
            {
                Console.WriteLine("输入邮箱为空，请重新输入");
                continue;
            }

            if (User.Any(x => x.Email == email))
            {
                Console.WriteLine("您注册过了");
                return;
            }

            emailed = true;
        }

        var usernamed = false;
        while (usernamed == false)
        {
            Console.WriteLine("请输入用户名");
            username = Console.ReadLine();
            if (string.IsNullOrEmpty(username))
            {
                Console.WriteLine("输入用户名为空，请重新输入");
                continue;
            }

            usernamed = true;
        }

        var passworded = false;
        while (passworded == false)
        {
            Console.WriteLine("请输入密码");
            password = Console.ReadLine();
            if (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("输入密码为空，请重新输入");
                continue;
            }

            passworded = true;
        }

        User.Add(new UserItem { Username = username, Password = password, Email = email });
        Console.WriteLine("注册成功");
    }

    private static void Login()

    {
        if (User.Count == 0)
        {
            Console.WriteLine("未有用户注册过，请先注册");
            Register();
        }
        else
        {
            var email = "";
            var validEmail = false;

            while (!validEmail)

            {
                Console.WriteLine("请输入邮箱");
                email = Console.ReadLine();
                if (string.IsNullOrEmpty(email))
                {
                    Console.WriteLine("输入邮箱为空，请重新输入");
                    continue;
                }

                if (!User.Any(x => x.Email == email))
                {
                    Console.WriteLine("此邮箱不存在，请重新输入邮箱");
                    continue;
                }

                validEmail = true;
            }

            var PasswordCorrect = false;


            while (!PasswordCorrect)
            {
                Console.WriteLine("请输入密码");
                var password = Console.ReadLine();
                if (string.IsNullOrEmpty(password))
                {
                    Console.WriteLine("输入密码为空，请重新输入");
                    continue;
                }

                if (User.Any(x => x.Email == email && x.Password != password))
                {
                    Console.WriteLine("密码错误，请重新输入密码");
                    continue;
                }

                if (User.Any(x => x.Email == email && x.Password == password))
                {
                    var userinfo = User.FirstOrDefault(x => x.Email == email && x.Password == password);
                    Console.WriteLine($"登陆成功，{userinfo.Username}");
                    PasswordCorrect = true;
                }
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
                    Console.WriteLine("请输入范围在1-4之间的整数");
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
                        if (User.Count!=0)
                            foreach (var item in User)
                                Console.WriteLine($"邮箱:{item.Email},用户名:{item.Username},密码:{item.Password}");
                        if (User.Count == 0)
                            Console.WriteLine("无用户信息");
                        break;

                    case 4:
                        Console.WriteLine("再见");
                        Environment.Exit(0);
                        break;
                }
            }

            catch
            {
                Console.WriteLine("请输入范围在1-4之间的整数");
            }
        }
    }

    private class UserItem
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
    }
}