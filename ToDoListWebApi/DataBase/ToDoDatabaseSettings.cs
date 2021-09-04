namespace ToDoListWebApi.DataBase
{
    public class ToDoDatabaseSettings : IToDoDatabaseSettings
    {
        public string ToDoCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IToDoDatabaseSettings
    {
        string ToDoCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}

