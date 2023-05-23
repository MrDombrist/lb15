
namespace lb15
{
    public class HashNode<K, V>
    {
        public K key;
        public V value;
        public int hashCode;
        public HashNode<K, V> next;
        public HashNode(K key, V value, int hashcode)
        {
            this.key = key;
            this.value = value;
            this.hashCode = hashcode;
        }
        public override string ToString()
        {
            return value + " " + key;
        }
    }
    public class Map<K, V>
    {
        private List<HashNode<K, V>> array;
        private int capacity;
        private int size;
        public int Size { get { return size; } }
        public Map()
        {
            array = new List<HashNode<K, V>>();
            capacity = 10;
            size = 0;
            for (int i = 0; i < capacity; i++)
            {
                array.Add(null);
            }
        }
        public Map(int cap)
        {
            array = new List<HashNode<K, V>>();
            capacity = cap;
            size = 0;
            for (int i = 0; i < capacity; i++)
            {
                array.Add(null);
            }
        }
        public int HashCode(K key)
        {
            return key.GetHashCode();
        }
        public bool IsEmpty { get { return size == 0; } }
        private int getBucketIndex(K key)
        {
            int hashCode = HashCode(key);
            int index = 11 * hashCode % capacity;
            index = index < 0 ? index * -1 : index;
            return index;
        }
        public V remove(K key)
        {

            int bucketIndex = getBucketIndex(key);
            int hashCode = HashCode(key);
            HashNode<K, V> head = array[bucketIndex];
            HashNode<K, V> prev = null;
            while (head != null)
            {
                if (head.key.Equals(key) && hashCode == head.hashCode) break;
                prev = head;
                head = head.next;
            }

            if (head == null)
                return default(V);

            size--;
            if (prev != null)
                prev.next = head.next;
            else
                array[bucketIndex] = head.next;

            return head.value;
        }
        public V get(K key)
        {
            int bucketIndex = getBucketIndex(key);
            int hashCode = HashCode(key);

            HashNode<K, V> head = array[bucketIndex];
            while (head != null)
            {
                if (head.key.Equals(key) && head.hashCode == hashCode)
                    return head.value;
                head = head.next;
            }
            return default(V);
        }
        public void Add(K key, V value)
        {
            var temp = key.GetHashCode();
            if (array[temp] == null)
            {
                array[temp] = new HashNode<K, V>(key, value, HashCode(key));
            }
            else
            {
                var tp = array[temp];
                while (true)
                {
                    if (tp.next != null)
                    {
                        tp = tp.next;
                    }
                    else
                    {
                        tp.next = new HashNode<K, V>(key, value, HashCode(key));
                        break;
                    }
                }
            }
        }
        public string Output()
        {
            string str = "";
            for (int i = 0; i < size; i++)
            {
                str += i + "= ";
                var tmp = array[i];
                while (tmp != null)
                {
                    str += tmp.ToString() + "\n";
                }
            }
            return str;
        }
        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < size; i++)
            {
                str += i + "= ";
                var tmp = array[i];
                while(tmp!= null)
                {
                    str+= tmp.ToString()+ "\n";
                }   
            }
            return str;
        }
    }
}