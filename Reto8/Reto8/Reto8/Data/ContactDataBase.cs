using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Reto8.Models;

namespace Reto8.Data
{
    public class ContactDataBase
    {
        readonly SQLiteAsyncConnection _database;

        public ContactDataBase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ContactModel>().Wait();
        }

        public Task<List<ContactModel>> GetContactsAsync()
        {
            return _database.Table<ContactModel>().ToListAsync();
        }

        public Task<ContactModel> GetContactAsync(int id)
        {
            return _database.Table<ContactModel>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveContactAsync(ContactModel contact)
        {
            if (contact.ID != 0)
            {
                return _database.UpdateAsync(contact);
            }
            else
            {
                return _database.InsertAsync(contact);
            }
        }

        public Task<int> DeleteContactAsync(ContactModel contact)
        {
            return _database.DeleteAsync(contact);
        }
    }
}
