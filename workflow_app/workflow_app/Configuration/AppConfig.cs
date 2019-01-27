using System;

namespace workflow_app.Configuration
{
    public static class AppConfig
    {
        static string basicPath = "";
        private static string GetBasePath()
        {
            return basicPath;
        }

        public static void Init()
        {
            basicPath = @"files\";
        }

        public static string GetUserResultFile(string user)
        {
            return basicPath + @"results\" + user + ".xlsx";
        }

        public static string GetUsersNameFile()
        {
            return GetBasePath() + "users.txt";
        }

        public static string GetPwdSuffix()
        {
            return "pwd";
        }
    }
}
