using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penner.MenuManage.Core.Entity
{
    using Castle.ActiveRecord;
    using Penner.NHibernateActiveRecord;

    [ActiveRecord("template")]
    public class TemplateInfo : DbObject<TemplateInfo>
    {
        [PrimaryKey("id")]
        public int Id { get; set; }

        [Property("item_count")]
        public int ItemCount { get; set; }

        [Property("content")]
        public string Content { get; set; }
    }
}
