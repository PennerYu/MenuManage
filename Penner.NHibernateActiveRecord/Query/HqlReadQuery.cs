using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penner.NHibernateActiveRecord.Query
{
    using NHibernate;
    using Castle.ActiveRecord;

    /// <summary>
    /// 只读查询类，该实体类不能保存进数据库
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HqlReadQuery<T> : IActiveRecordQuery
        where T : new()
    {
        private string _hql;
        private object[] _paras;

        public HqlReadQuery(string hql, params object[] paras)
        {
            _hql = hql;
            _paras = paras;
        }

        #region IActiveRecordQuery 成员

        public System.Collections.IEnumerable Enumerate(ISession session)
        {
            throw new NotImplementedException();
        }

        public object Execute(ISession session)
        {
            session.FlushMode = FlushMode.Never;
            session.CacheMode = CacheMode.Ignore;

            //string cql = string.Format("select count(*) {0}", _hql);
            //var cquery = session.CreateQuery(cql);
            //var count = Convert.ToInt32(cquery.UniqueResult());

            var query = session.CreateQuery(_hql);
            query.SetReadOnly(true);
            if (_paras != null)
            {
                for (int i = 0; i < _paras.Length; i++)
                {
                    query.SetParameter(i, _paras[i]);
                }
            }
            return query.List<T>();
        }

        public Type RootType
        {
            get { return typeof(T); }
        }

        #endregion
    }
}
