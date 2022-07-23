using SQLite;
using SqliteDemo.Helpers;
using SqliteDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteDemo.Repository
{
    internal class SqliteRepository
    {
        private readonly SQLiteConnection _database;

        public SqliteRepository()
        {
            string dbPath = FileAccessHelper.GetLocalFilePath("entities.db");

            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<MyEntity>();
        }

        public List<MyEntity> List()
        {
            return _database.Table<MyEntity>().ToList();
        }

        public int Create(MyEntity entity)
        {
            return _database.Insert(entity);
        }

        public int Update(MyEntity entity)
        {
            return _database.Update(entity);
        }

        public int Delete(MyEntity entity)
        {
            return _database.Delete(entity);
        }
    }
}
