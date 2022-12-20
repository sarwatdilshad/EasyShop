using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyShop.Models
{
    public class UserInfoModel
    {
        public UserInformation GetUserInformation(string guId)
        {
            EasyShopDBEntities db = new EasyShopDBEntities();
            var info = (from x in db.UserInformations
                        where x.GUID == guId
                        select x).FirstOrDefault();
            return info;
        }

        public void InsertUserDetail(UserInformation info)
        {
            EasyShopDBEntities db = new EasyShopDBEntities();
            db.UserInformations.Add(info);
            db.SaveChanges();
        }


    }
}