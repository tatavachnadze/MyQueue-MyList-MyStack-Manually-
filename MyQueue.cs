using System;
using System.Collections;
using System.Collections.Generic;

namespace G16_20220623
{
    internal class MyQueue<T> : BaseCollection<T>, ICollection<T>
    {
        public virtual void Enqueue(T obj)
        {
            if (_items.Length == Count)
            {
                Resize(ref _items, _items.Length * 2);
            }
            _items[Count] = obj;
        }

        public virtual T Peek()
        {
            if (_items.Length == 0)
            {
                throw new Exception("Array is empty");
            }

            return _items[0];
        }

        public virtual T Dequeue()
        {
            if (_items.Length == 0)
            {
                throw new Exception("Array Is Empty");
            }

            T first = Peek();
            RemoveAt(0);
            return first;
        }
    }
}
