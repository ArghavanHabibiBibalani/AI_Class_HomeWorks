using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Map
{
   public interface IMap<K, V>
    {
        int Size();
        bool IsEmpty();
        V Get(K key);
        V Put(K key, V value);
        V Remove(K key);
        IEnumerable<K> KeySet();
        IEnumerable<V> Values();
        IEnumerable<KeyValuePair<K, V>> EntrySet();
    }

}
