using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL
{
    public class CommonBs:BaseBs
    {
        public void InsertQuickURL(BOL.QuickURLSubmitModel myQuickURL)
        {
            try {
                using (TransactionScope Trans = new TransactionScope())
                {
                    myQuickURL.MyUser.Password = "123456";
                    myQuickURL.MyUser.ConfirmPassword = "123456";
                    myQuickURL.MyUser.Role = "U";
                    userBs.Insert(myQuickURL.MyUser);

                    myQuickURL.MyUrl.UserId = myQuickURL.MyUser.UserId;
                    myQuickURL.MyUrl.UrlDesc = myQuickURL.MyUrl.UrlTitle;
                    myQuickURL.MyUrl.IsApproved = "P";
                    urlBs.Insert(myQuickURL.MyUrl);
                    Trans.Complete();
                }            
            }catch(Exception ex){
                throw new Exception(ex.Message);
            }


        }
    }
}
