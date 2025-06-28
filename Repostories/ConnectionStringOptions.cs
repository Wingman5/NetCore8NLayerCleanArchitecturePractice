namespace App.Repositories
{
    public class ConnectionStringOptions
    {
        public const string SectionName = "ConnectionStrings";
        public string SqlServer { get; set; } = default!;
    }
}
