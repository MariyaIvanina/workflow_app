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

        public static void Init(String path)
        {
            basicPath = path;
        }

        public static string GetUserResultFile(string user)
        {
            return basicPath + @"results\" + user + ".xlsx";
        }

        public static string GetNormDirectory()
        {
            return GetBasePath() + @"norms\";
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
