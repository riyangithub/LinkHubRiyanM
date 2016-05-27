using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BOL;
namespace BLL
{
   public class CategoryBs
    {
        private CategoryDb obj;
        public CategoryBs()
        {
            obj = new CategoryDb();
        }
        public IEnumerable<tbl_Category> Getall()
        {
            return obj.GetAll();
        }
        public tbl_Category GetById(int Id)
        {
            return obj.GetById(Id);
        }
        public void Insert(tbl_Category ctgr)
        {
            obj.Insert(ctgr);
        }
        public void Delete(int id)
        {
            obj.Delete(id);
        }
        public void Update(tbl_Category url)
        {
            obj.Update(url);
        }
        public void Save()
        {
            obj.Save();
        }
    }
}
