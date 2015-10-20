using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penner.MenuManage.InternalServices.Impl.Page
{
    using Penner.MenuManage.Core.Entity;
    using Penner.MenuManage.InternalServices.Page;
    using Penner.MenuManage.InternalServices.Impl.Utils;

    using Penner.NHibernateActiveRecord;
    using Penner.NHibernateActiveRecord.Query;
    
    public class Pages : IPages
    {
        public string MenuPages(PagesFilter filter)
        {
            try
            {
                var c = filter.c;
                var s = filter.s;
                var hql = string.Empty;
                if (filter.CatalogId > 0)
                    hql = string.Format("from CatalogUserTemplateInfo c where c.CatalogId = {0} order by c.Rank", filter.CatalogId);
                else
                    hql = "from CatalogUserTemplateInfo c";

                var pages = CatalogUserTemplateInfo.Execute(
                    new HqlPageQuery<CatalogUserTemplateInfo>(hql, PageUtils.PageIndex(c, s), c)) as IList<CatalogUserTemplateInfo>;

                var builder = new StringBuilder(3000);
                builder.AppendFormat("\"c\":\"{0}\",\"s\":\"{1}\",\"comics\":[", c, s);
                
                foreach (var page in pages)
                {
                    builder.AppendFormat("{{\"item_count\":\"{0}\",\"content\":\"{1}\",\"items\":[",
                        page.UserTemplateInfo.TemplateInfo.ItemCount, page.UserTemplateInfo.TemplateInfo.Content);
                    foreach (var obj in page.Items)
                    {
                        var item = obj as ItemInfo;
                        if (item != null)
                        {
                            builder.AppendFormat("{{\"id\":\"{0}\",\"name\":\"{1}\",\"image\":\"{2}\",\"price\":\"{3}\",\"unit\":\"{4}\",\"summary\":\"{5}\",\"create_time\":\"{6}\"}},",
                                item.Id, item.Name, item.ImageUri, item.Price, item.Unit, item.Summary, item.CreateTime);
                        }
                    }
                    if (page.Items.Count > 0)
                        builder.Remove(builder.Length - 1, 1);
                    builder.Append("]},");
                }

                var count = Convert.ToInt32(CatalogUserTemplateInfo.ExecuteUniqueResult(string.Format("select count(*) {0}", hql))); 
                var totalPage = PageUtils.PageCount(count, c);
                if (count > 0 && s <= totalPage)
                    builder.Remove(builder.Length - 1, 1);
                builder.Insert(0, string.Format("{{\"total_count\":\"{0}\",\"total_pages\":\"{1}\",", count, totalPage));
                builder.Append("]}");

                return builder.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
