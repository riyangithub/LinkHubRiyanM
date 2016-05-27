using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserBs
    {
        private UserDb obj;
        public UserBs()
        {
            obj = new UserDb();
        }
        public IEnumerable<tbl_User> Getall()
        {
            return obj.GetAll();
        }
        public tbl_User GetById(int Id)
        {
            return obj.GetById(Id);
        }
        public void Insert(tbl_User url)
        {
            obj.Insert(url);
            obj.Save();
        }
        public void Delete(int id)
        {
            obj.Delete(id);
            Save();
        }
        public void Update(tbl_User url)
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
