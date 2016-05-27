using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL
{
    public class AdminBs:BaseBs
    {

        public void ApproveOrReject(List<int> Ids, string Status)
        {
            using (TransactionScope Trans = new TransactionScope()) {
                try 
                {
                    foreach (var Item in Ids) {
                        var myUrl = urlBs.GetById(Item);
                        myUrl.IsApproved = Status;
                        urlBs.Update(myUrl);
                    }
                    Trans.Complete();
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
