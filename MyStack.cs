using System.Collections;

namespace G16_20220623
{
    internal class MyStack<T> : BaseCollection<T>, ICollection<T>
    {
        public virtual void Push(T obj)
        {
            if (index + 1 >= _items.Length)
            {
                Resize(ref _items, _items.Length * 2);
            }
            index++;
            _items[index] = obj;
        }

        public virtual T Peek()
        {
            if (_items.Length == 0)
            {
                throw new Exception("Array is empty");
            }

            return _items[^1];
        }

        public virtual T Pop()
        {
            if (_items.Length == 0)
            {
                throw new Exception("Array Is Empty");
            }

            T item = Peek();
            RemoveAt(_items.Length - 1);
            return item;
        }

        public override IEnumerator<T> GetEnumerator()
        {
            return new ArrayEnumerator<T>(GetReversed(this._items));
        }

        private static T[] GetReversed(T[] array)
        {
            T[] reversed = new T[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                reversed[^(i + 1)] = array[i];
            }

            return reversed;
        }
    }
}
