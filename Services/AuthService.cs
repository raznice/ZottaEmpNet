namespace ZottaEmpNet.Services
{
    public class AuthService
    {
        public bool AdminLogin(string username, string password)
        {
            // Basic in-memory authentication for admin
            if (username == "ZottaAdmin" && password == "Zotta123")
            {
                return true;
            }
            return false;
        }

        public bool EmployeeLogin(string username, string password)
        {
            // Basic in-memory authentication for employee (any non-empty credentials)
            return !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password);
        }
    }
}

