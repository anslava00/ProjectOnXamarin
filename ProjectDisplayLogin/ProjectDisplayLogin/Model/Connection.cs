using Npgsql;

namespace ProjectDisplayLogin.Model
{
    public class Connection
    {
        static public NpgsqlConnection Connect = new NpgsqlConnection("Server=10.0.2.2; Port=5432;" +                                                            "Port=5432; " +
                                                                      "User Id=postgres;" +
                                                                      "Password=Ctvtqrf55@;" +
                                                                      "Database=University;");
        static public string SqlRequest;
    }
}