using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using XamarinFormsApp.Models;

namespace XamarinFormsApp.Data
{
    public class UserItemDatabase
    {
        readonly SQLiteAsyncConnection database;

        public UserItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<UserItem>().Wait();
        }

        public Task<List<UserItem>> GetItemsAsync()
        {
            return database.Table<UserItem>().ToListAsync();
        }

        public Task<List<UserItem>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<UserItem>("SELECT * FROM [TodoItem]");// WHERE [Done] = 0");
        }

        public Task<UserItem> GetItemAsync(int id)
        {
            return database.Table<UserItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(UserItem item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        //public Task<int> DeleteItemAsync(UserItem item)
        //{
        //    return database.DeleteAsync(item);
        //}
    }
}
