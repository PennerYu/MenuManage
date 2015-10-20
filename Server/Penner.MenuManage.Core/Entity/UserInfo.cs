using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penner.MenuManage.Core.Entity
{
    using Castle.ActiveRecord;
    using Penner.NHibernateActiveRecord;

    [ActiveRecord("user")]
    public class UserInfo : DbObject<UserInfo>
    {
        [PrimaryKey("id")]
        public int Id { get; set; }

        [Property("name")]
        public string Name { get; set; }

        [Property("password")]
        public string Password { get; set; }

        [Property("forbidden")]
        public bool Forbidden { get; set; }

        [Property("admin")]
        public bool Admin { get; set; }

        [Property("user_expire")]
        public DateTime? UserExpire { get; set; }
    }
}
