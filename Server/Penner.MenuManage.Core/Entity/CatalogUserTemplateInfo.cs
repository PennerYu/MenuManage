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

    [ActiveRecord("catalog_user_template")]
    public class CatalogUserTemplateInfo : DbObject<CatalogUserTemplateInfo>
    {
        [PrimaryKey("id")]
        public int Id { get; set; }

        [Property("catalog_id")]
        public int CatalogId { get; set; }

        //[Property("user_template_id")]
        //public int UserTempalteId { get; set; }

        [Property("rank")]
        public int Rank { get; set; }

        [Property("create_time")]
        public DateTime? CreateTime { get; set; }

        [BelongsTo("user_template_id")]
        public UserTemplateInfo UserTemplateInfo { get; set; }

        [HasAndBelongsToMany(typeof(ItemInfo), Table="catalog_user_template_item", ColumnKey="catalog_user_template_id", ColumnRef="item_id")]
        public IList Items { get; set; }
    }
}
