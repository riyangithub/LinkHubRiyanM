﻿using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UrlDB
    {
        private LinkHubDbEntities db;
        public UrlDB() {
            db = new LinkHubDbEntities();
        }

        public IEnumerable<tbl_Url> GetAll()
        {
            return db.tbl_Url.ToList();
        }
        public tbl_Url GetById(int Id)
        {
            return db.tbl_Url.Find(Id);
        }
        public void Insert(tbl_Url url)
        {
            db.tbl_Url.Add(url);
            Save();
        }
        public void Delete(int id)
        {
            tbl_Url url = db.tbl_Url.Find(id);
            db.tbl_Url.Remove(url);
        }
        public void Update(tbl_Url url)
        {
            db.Entry(url).State = EntityState.Modified;            

        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
