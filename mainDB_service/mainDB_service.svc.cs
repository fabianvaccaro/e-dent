using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace mainDB_service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "mainDB_service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select mainDB_service.svc or mainDB_service.svc.cs at the Solution Explorer and start debugging.
    public class mainDB_service : ImainDB_service
    {
        public void DoWork()
        {
        }

        public String getUsername(Int32 ID)
        {
            using (cdentalEntities entidad = new cdentalEntities())
            {
                var nombrequery = from user in entidad.users
                                 where user.usr_id == ID
                                 select new
                                 {
                                     user.username,
                                     user.role
                                 };

                //nombrequery.Take(10).Skip(20);,
                return nombrequery.FirstOrDefault().username;
            }
        }
    }
}
