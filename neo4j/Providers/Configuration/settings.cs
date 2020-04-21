using DotNetEnv;

namespace Database.Providers.Configuration
{
    public static class Settings
    {
        static Settings()
        {
            Env.Load();
        }

        public static string Host => Env.GetString("HOST");
        public static string Username => Env.GetString("USERNAME");
        public static string Password => Env.GetString("PASSWORD");
        public static string Port => Env.GetString("PORT");
        public static string Database => Env.GetString("database");




    }
}
