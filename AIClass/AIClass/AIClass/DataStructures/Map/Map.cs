using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Map
{
    public class Map<K, V> : IMap<K, V>
    {
        private Dictionary<K, V> dictionary;

        public Map()
        {
            dictionary = new Dictionary<K, V>();
        }

        public int Size()
        {
            return dictionary.Count;
        }

        public bool IsEmpty()
        {
            return dictionary.Count == 0;
        }

        public V Get(K key)
        {
            dictionary.TryGetValue(key, out V value);
            return value;
        }

        public V Put(K key, V value)
        {
            if (dictionary.ContainsKey(key))
            {
                V oldValue = dictionary[key];
                dictionary[key] = value;
                return oldValue;
            }
            else
            {
                dictionary[key] = value;
                return default(V);
            }
        }

        public V Remove(K key)
        {
            if (dictionary.TryGetValue(key, out V value))
            {
                dictionary.Remove(key);
                return value;
            }
            else
            {
                return default(V);
            }
        }

        public IEnumerable<K> KeySet()
        {
            return dictionary.Keys;
        }

        public IEnumerable<V> Values()
        {
            return dictionary.Values;
        }

        public IEnumerable<KeyValuePair<K, V>> EntrySet()
        {
            return dictionary;
        }
    }

}
