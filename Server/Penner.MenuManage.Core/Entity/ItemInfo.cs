using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penner.MenuManage.Core.Entity
{
    using Castle.ActiveRecord;
    using Penner.NHibernateActiveRecord;

    [ActiveRecord("item")]
    public class ItemInfo : DbObject<ItemInfo>
    {
        [PrimaryKey("id")]
        public int Id { get; set; }

        [Property("name")]
        public string Name { get; set; }

        [Property("image_uri")]
        public string ImageUri { get; set; }

        [Property("price")]
        public decimal Price { get; set; }

        [Property("unit")]
        public string Unit { get; set; }

        [Property("summary")]
        public string Summary { get; set; }

        [Property("create_time")]
        public DateTime CreateTime { get; set; }
    }
}
