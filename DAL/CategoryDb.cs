using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoryDb
    {
        private LinkHubDbEntities db;
        public CategoryDb()
        {
            db = new LinkHubDbEntities();
        }

        public IEnumerable<tbl_Category> GetAll()
        {
            return db.tbl_Category.ToList();
        }
        public tbl_Category GetById(int Id)
        {
            return db.tbl_Category.Find(Id);
        }
        public void Insert(tbl_Category ctgr)
        {
            db.tbl_Category.Add(ctgr);
            Save();
        }
        public void Delete(int id)
        {
            
                tbl_Category url = db.tbl_Category.Find(id);
                db.tbl_Category.Remove(url);
                Save();
        }
        public void Update(tbl_Category url)
        {
            db.Entry(url).State = EntityState.Modified;
        }
        public void Save()
        {
            db.SaveChanges();
            //try {
               
            //}
            //catch (Exception ex) { 
            //}
            
        }
    }
}
