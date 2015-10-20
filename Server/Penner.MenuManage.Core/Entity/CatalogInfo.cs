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

    [ActiveRecord("catalog")]
    public class CatalogInfo : DbObject<CatalogInfo>
    {
        [PrimaryKey("id")]
        public int Id { get; set; }

        [Property("menu_id")]
        public int MenuId { get; set; }

        [Property("name")]
        public string Name { get; set; }

        //[HasMany(typeof(CatalogUserTemplateInfo), Table = "catalog_user_template", ColumnKey = "catalog_id")]
        //public IList Templates { get; set; }

        //[HasAndBelongsToMany(typeof(UserTemplateInfo), Table = "catalog_user_template", ColumnKey = "catalog_id", ColumnRef = "user_template_id")]
        //public IList UserTemplates { get; set; }
    }
}
