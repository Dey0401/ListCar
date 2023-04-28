using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListCar.Logic
{
    public class DoubleList<T>
    {
        private DoubleNode<T>? _first;

        private DoubleNode<T>? _last;

        public DoubleList()
        {
            _first = null;
            _last = null;
            Count = 0;
        }

        public int Count { get; set; }

        public bool IsEmpty => Count == 0;

        public override string ToString()
        {
            var output = string.Empty;
            var pointer = _first;
            while (pointer != null)
            {
                output += $"{pointer.Data}\n";
                pointer = pointer.Right;
            }
            return output;
        }

        public string ToInvertedList()
        {
            var output = string.Empty;
            var pointer = _last;
            while (pointer != null)
            {
                output += $"{pointer.Data}\n";
                pointer = pointer.Left;
            }
            return output;
        }

        public void Add(T item)
        {
            var node = new DoubleNode<T>(item);
            if (IsEmpty)
            {
                _first = node;
                _last = node;
            }
            else
            {
                node.Left = _last;
                _last!.Right = node;
                _last = node;
            }
            Count++;
        }

        public T[] ToArray()
        {
            var array = new T[Count];
            int i = 0;
            var pointer = _first;
            while (pointer != null)
            {
                array[i] = pointer.Data!;
                i++;
                pointer = pointer.Right;
            }
            return array;
        }

        public Response Delete(T item)
        {
            var pointer = _first;
            while (pointer != null)
            {
                if (item!.Equals(pointer.Data))
                {
                    if (pointer == _first)
                    {
                        pointer.Right!.Left = null;
                        _first = pointer.Right;
                    }
                    else if (pointer == _last)
                    {
                        pointer.Left!.Right = null;
                        _last = pointer.Left;
                    }
                    else
                    {
                        pointer.Left!.Right = pointer.Right;
                        pointer.Right!.Left = pointer.Left;
                    }
                    pointer = null;
                    Count--;
                    return new Response
                    {
                        IsScucced = true,
                        Message = $"The element: {item} was deleted."
                    };
                }
                pointer = pointer!.Right;
            }
            return new Response
            {
                IsScucced = false,
                Message = $"The element: {item} not found."
            };
        }

        public Response Insert(T item, int position)
        {
            if (position < 0 || position >= Count)
            {
                return new Response
                {
                    IsScucced = false,
                    Message = $"The position {position} is not valid."
                };
            }
            var node = new DoubleNode<T>(item);
            if (position == 0)
            {
                _first!.Left = node;
                node.Right = _first;
                _first = node;
            }
            else
            {
                int i = 1;
                var pointer = _first!.Right;
                while (i < position)
                {
                    pointer = pointer!.Right;
                    i++;
                }
                pointer!.Left!.Right = node;
                node.Left = pointer.Left;
                node.Right = pointer;
                pointer.Left = node;
            }

            Count++;
            return new Response
            {
                IsScucced = true,
                Message = $"The item {item} was inserted."
            };

        }
      
        public void FillFibonacci(int limit)
        {
            while (Count < limit)
            {
                if (IsEmpty)
                {
                    T number = (T)Convert.ChangeType(0, typeof(T));
                    Add(number);
                }
                else if (Count == 1)
                {
                    T number = (T)Convert.ChangeType(1, typeof(T));
                    Add(number);
                }
                else
                {
                    var pointer = _last;
                    var result = Convert.ToInt32(pointer!.Data) + Convert.ToInt32(pointer.Left!.Data);
                    T number = (T)Convert.ChangeType(result, typeof(T));
                    Add(number);
                }
            }
        }

        public String GetBrand(string brand, DoubleList<Cars> listCars) 
        {
            var output = String.Empty;
            var pointer = _first;
            while (pointer!.Right != null)
            {
                Cars car = (Cars)Convert.ChangeType(pointer.Data, typeof(Cars))!;
                if (car!.Brand!.Equals(brand))
                {
                    output += $"{pointer.Data}\n";
                }
                pointer = pointer.Right;
            }
            return output;
        }

        public String GetRangeYears(int min, int max)
        {
            var output = String.Empty;
            var pointer = _first;
            while (pointer!.Right != null)
            {
                Cars car = (Cars)Convert.ChangeType(pointer.Data, typeof(Cars))!;
                if ((car.Year>=min) && (car.Year <= max))
                {
                    output += $"{pointer.Data}\n";
                }
                pointer = pointer.Right;
            }
            return output;
        }

        public String GetRangePrice(decimal min, decimal max)
        {
            var output = String.Empty;
            var pointer = _first;
            while (pointer!.Right != null)
            {
                Cars car = (Cars)Convert.ChangeType(pointer.Data, typeof(Cars))!;
                if ((car.Price >= min) && (car.Price <= max))
                {
                    output += $"{pointer.Data}\n";
                }
                pointer = pointer.Right;
            }
            return output;
        }

       
        public String GetCarsWithParam(string brand, string? model, int year, string? color, decimal price)
        {
            var output = String.Empty;
            var pointer = _first;
            while (pointer!.Right != null)
            {
                Cars car = (Cars)Convert.ChangeType(pointer.Data, typeof(Cars))!;
                if ((car.Brand!.Equals(brand)) && (car.Model!.Equals(model)) && (car.Year!.Equals(year)) && (car.Color!.Equals(color)) && (car.Price!.Equals(price)))
                {
                    output += $"{pointer.Data}\n";
                }
                pointer = pointer.Right;
            }
            return output;
        }
    }
}