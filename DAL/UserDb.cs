using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDb
    {
        private LinkHubDbEntities db;
        public UserDb()
        {
            db = new LinkHubDbEntities();
        }

        public IEnumerable<tbl_User> GetAll()
        {
            return db.tbl_User.ToList();
        }
        public tbl_User GetById(int Id)
        {
            return db.tbl_User.Find(Id);
        }
        public void Insert(tbl_User url)
        {
            db.tbl_User.Add(url);
        }
        public void Delete(int id)
        {
            tbl_User url = db.tbl_User.Find(id);
            db.tbl_User.Remove(url);
        }
        public void Update(tbl_User url)
        {
            db.Entry(url).State = EntityState.Modified;
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
