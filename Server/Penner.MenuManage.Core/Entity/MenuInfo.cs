using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penner.MenuManage.Core.Entity
{
    using Castle.ActiveRecord;
    using Penner.NHibernateActiveRecord;

    [ActiveRecord("menu")]
    public class MenuInfo : DbObject<MenuInfo>
    {
        [PrimaryKey("id")]
        public int Id { get; set; }

        [Property("user_id")]
        public int UserId { get; set; }

        [Property("name")]
        public string Name { get; set; }

        [Property("summary")]
        public string Summary { get; set; }
    }
}
