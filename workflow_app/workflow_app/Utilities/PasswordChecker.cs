using OfficeOpenXml;
using System;
using System.IO;
using workflow_app.Configuration;

public enum CheckerVerdict
{
    OK = 1,
    WRONG_PASSWORD = 2,
    NO_FILE = 3
}

public static  class PasswordChecker
{
    public static CheckerVerdict VerifyPassword(string user, string password)
    {
        string path = AppConfig.GetUserResultFile(user);
        if (!File.Exists(path))
        {
            return CheckerVerdict.NO_FILE;
        } else
        {
            try
            {
                using (ExcelPackage xlPackage = new ExcelPackage(new FileInfo(path), password))
                {
                    return CheckerVerdict.OK;
                }
            } catch (Exception)
            {
                return CheckerVerdict.WRONG_PASSWORD;
            }
        }
    }
}
