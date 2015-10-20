using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penner.MenuManage.Core.Entity
{
    using Castle.ActiveRecord;
    using Penner.NHibernateActiveRecord;

    [ActiveRecord("user_template")]
    public class UserTemplateInfo : DbObject<UserTemplateInfo>
    {
        [PrimaryKey("id")]
        public int Id { get; set; }

        [Property("user_id")]
        public int UserId { get; set; }

        //[Property("template_id")]
        //public int TemplateId { get; set; }

        [Property("free")]
        public bool Free { get; set; }

        [Property("price")]
        public decimal Price { get; set; }

        [Property("free_expire")]
        public DateTime? FreeExpire { get; set; }

        [BelongsTo("template_id")]
        public TemplateInfo TemplateInfo { get; set; }
    }
}
