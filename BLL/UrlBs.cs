using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UrlBs
    {
        private UrlDB obj;
        public UrlBs()
        {
            obj = new UrlDB();
        }
        public IEnumerable<tbl_Url> Getall()
        {
            return obj.GetAll();
        }
        public tbl_Url GetById(int Id)
        {
            return obj.GetById(Id);
        }
        public void Insert(tbl_Url url)
        {
            obj.Insert(url);
            obj.Save();
        }
        public void Delete(int id)
        {
            obj.Delete(id);
            Save();
        }
        public void Update(tbl_Url url)
        {
            obj.Update(url);
            Save();
        }
        public void Save()
        {
            obj.Save();
        }
    }
}
