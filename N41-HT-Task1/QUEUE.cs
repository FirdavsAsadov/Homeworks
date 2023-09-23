using System;
using System.Collections.Generic;
using System.Linq;

namespace N41_HT_Task1
{
    public class QUEUE<T> : IQUEUE<T>
    {
        private List<T> _items = new List<T>();
        private readonly object _locker ;
        public void Enqueue(T item)
        {
            lock (_locker)
            {
                if (item == null)
                    throw new ArgumentException("item is null");
                _items.Add(item);
            }
        }

        public T Dequeue()
        {
            lock (_locker)
            {
                var target = _items.FirstOrDefault();
                if (target != null)
                {
                    _items.Remove(target);
                    return target;
                }

                throw new InvalidOperationException("Collections has 0 element");
            }
        }
        }
    }
