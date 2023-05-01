namespace WebAPI.Data
{
    public class MySqlConfiguration
    {
        public MySqlConfiguration(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public string ConnectionString { get; set; }
    }
}
