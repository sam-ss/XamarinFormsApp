using SQLite;

namespace XamarinFormsApp.Models
{
    public class UserItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string Password { get; set; }
    }
}
