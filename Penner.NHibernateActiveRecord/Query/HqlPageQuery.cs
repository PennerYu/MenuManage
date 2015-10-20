using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Penner.NHibernateActiveRecord.Query
{
    using Castle.ActiveRecord;

    public class HqlPageQuery<T> : IActiveRecordQuery
        where T : new()
    {
        int _start;
        int _limit;
        string _hql;
        object[] _parameters;

        public HqlPageQuery(string hql, int start, int limit, params object[] parameters)
        {
            _hql = hql;
            _start = start;
            _limit = limit;
            _parameters = parameters;
        }

        public System.Collections.IEnumerable Enumerate(NHibernate.ISession session)
        {
            throw new NotImplementedException();
        }

        public object Execute(NHibernate.ISession session)
        {
            var query = session.CreateQuery(_hql);
            if (_parameters != null)
            {
                for (int i = 0; i < _parameters.Length; i++)
                    query.SetParameter(i, _parameters[i]);
            }
            return query.SetFirstResult(_start).SetMaxResults(_limit).List<T>();
        }

        public Type RootType
        {
            get { return typeof(T); }
        }
    }
}
