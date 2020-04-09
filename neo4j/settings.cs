using System;
//https://github.com/tonerdo/dotnet-env
using DotNetEnv;

namespace data
{
    public static class Settings
    {
        static Settings()
        {
            Env.Load();
        }

        public static string host => Env.GetString("HOST");
        public static string username => Env.GetString("USERNAME");
        public static string password => Env.GetString("PASSWORD");
        public static string port => Env.GetString("PORT");
        public static string database => Env.GetString("database");




    }
}
