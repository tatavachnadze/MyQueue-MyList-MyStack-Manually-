namespace G16_20220623
{
    internal class MyList<T> : BaseCollection<T>, IList<T>
    {
        public T this[int index]
        {
            get
            {
                return _items[index];
            }
            set
            {
                _items[index] = value;
            }
        }

        public void Add(T item)
        {

            if (index+1 >= _items.Length)
            {
                Resize(ref _items, _items.Length * 2);
            }
            index++;
            _items[index] = item;
        }
        //{
        //    if (_items.Length == Count)
        //    {
        //        Resize(ref _items, _items.Length * 2);
        //    }            
        //    _items[Count] = item;
        //}

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index != -1)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }

        public void Insert(int index, T item)
        {

            if (_items.Length == Count)
            {
                Resize(ref _items, _items.Length * 2);
            }
            for (int i = Count; i > index + 1; i--)
            {
                _items[i] = _items[i + 1];
            }
            _items[index] = item;
        }

    }
}
