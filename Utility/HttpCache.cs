using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Utility
{
    internal class HttpCache : ICacheStrategy
    {
        private static readonly System.Web.Caching.Cache cache = HttpContext.Current == null ? HttpRuntime.Cache : HttpContext.Current.Cache;

        public void AddObject(string key, object o)
        {
            cache.Insert(key, o, null, AbsoluteTime, TimeOutSpan);
        }

        public void AddObjectWithFileChange(string key, object o, string[] files)
        {

        }

        public void AddObjectWithDepend(string key, object o, string[] dependKey)
        {

        }

        public void RemoveObject(string key)
        {
            cache.Remove(key);
        }

        public object RetrieveObject(string key)
        {
            return cache[key];
        }

        public bool CheckExistValueByKey(string key)
        {
            return cache[key] != null;
        }

        public IDictionaryEnumerator GetKeyValue()
        {
            return cache.GetEnumerator();
        }

        public TimeSpan TimeOutSpan { get; set; }

        public DateTime AbsoluteTime { get; set; }


        public IDictionaryEnumerator GetEnumerator()
        {
            return cache.GetEnumerator();
        }
    }
}
