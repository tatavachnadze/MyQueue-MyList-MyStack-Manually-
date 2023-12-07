using System.Collections;

namespace G16_20220623
{
    internal abstract class BaseCollection<T> : ICollection<T>
    {
        protected T[] _items;


        public int index = -1;

        public int Count
        {
            get
            {
                return ElementsCount();
            }
        }
        public int ElementsCount()
        {
            int counter = 0;
            for (int i = 0; i < _items.Length; i++)
            {
                if (_items[i] != null)
                {
                    counter++;

                }
                else
                {
                    break;
                }
            }
            return counter;
        }

        public bool IsReadOnly => false;

        public BaseCollection()
        {
            Clear();
            _items = new T[4];
        }
        public void TrimToSize()
        {
            Resize(ref _items, Count);
        }
        protected static void Resize(ref T[] array, int newSize)
        {
            if (newSize == array.Length)
            {
                return;
            }

            T[] temp = new T[newSize];
            for (int i = 0; i < array.Length && i < temp.Length; i++)
            {
                temp[i] = array[i];
            }

            array = temp;
        }

        void ICollection<T>.Add(T item)
        {
            throw new NotSupportedException();
        }

        public void Clear()
        {
            _items = Array.Empty<T>();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = 0; i < _items.Length; i++)
            {
                array[i + arrayIndex] = _items[i];
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < _items.Length; i++)
            {
                if (_items[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        bool ICollection<T>.Remove(T item)
        {
            throw new NotSupportedException();
        }

        public void RemoveAt(int index)
        {
            T[] temp = new T[_items.Length - 1];
            for (int i = 0, j = 0; i < _items.Length; i++, j++)
            {
                if (i != index)
                {
                    temp[j] = _items[i];
                }
                else
                {
                    j--;
                }
            }
            _items = temp;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < _items.Length; i++)
            {
                if (_items[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public virtual IEnumerator<T> GetEnumerator()
        {
            return new ArrayEnumerator<T>(this._items);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    class ArrayEnumerator<T> : IEnumerator<T>
    {
        private T[] _array;
        private int _index;

        public ArrayEnumerator(T[] array)
        {
            _array = array;
            _index = -1;
        }

        public bool MoveNext()
        {
            return ++_index < _array.Length;
        }

        public T Current => _array[_index];

        public void Reset()
        {
            _index = -1;
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {

        }
    }
}
