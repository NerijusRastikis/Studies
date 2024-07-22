using static OOP_5.Program;

namespace OOP_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Paskaitos data: 2024-07-10
            // GENERICS

            //Validation<string, int>.Validate(null, 32);
            var twogenerics = new TwoGenerics<string, int>();
            twogenerics.Set("nieko", 0);
            Console.WriteLine($"T1: {twogenerics.Get1()}");
            Console.WriteLine($"T2: {twogenerics.Get2()}");
            Console.WriteLine("------------------");

        }
        public class Validation<T1, T2>
        {
            public bool Validate(T1 value1, T2 value2)
            {
                bool answer;
                if (value1 == null)
                {
                    throw new ArgumentNullException("value");
                }
                else if (value2 == null)
                {
                    throw new ArgumentNullException("value");
                }
                else
                {
                    answer = true;
                    return answer;
                }
            }

            public static void Validate<T1>(object value)
            {
                throw new NotImplementedException();
            }
            public void OrintTypes(T1 value1, T2 value2)
            {
                Console.WriteLine($"Value 1: {value1.GetType()}");
                Console.WriteLine($"Value 2: {value2.GetType()}");
            }
        }
        public class TwoGenerics<T1, T2>
        {
            T1? value1;
            T2? value2;
            public void Set(T1 t1, T2 t2)
            {
                value1 = t1;
                value2 = t2;
            }
            public T1 Get1()
            {
                return value1;
            }
            public T2 Get2()
            {
                return value2;
            }
        }

        ///////////////////////////////////////
        ///////////////////////////////////////
        ///////////////////////////////////////
        
        public class MySelfMadeList<T>
        {
            private T[] MyArray { get; set; }
            private int Index = 0;
            private int Size = 10;
            
            public MySelfMadeList()
            {
                MyArray = new T[Size];
            }
            public void AddElement(T elementToAdd)
            {
                if (CheckIfFull())
                {
                    MyArray = IncreaseListSize();
                }
                if (elementToAdd != null)
                {
                    MyArray[Index] = elementToAdd;
                    Index++;
                }
                else
                {
                    throw new ArgumentNullException(nameof(elementToAdd));
                }
            }
            private bool CheckIfFull()
            {
                if (Index == Size)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            private T[] IncreaseListSize()
            {
                Size += (Size / 2);
                var newArray = new T[Size];
                MyArray.CopyTo(newArray, 0);
                return newArray;
            }
            public void RemoveElement(int indexToRemove)
            {
                if (indexToRemove < 0 || indexToRemove >= Index)
                {
                    throw new ArgumentOutOfRangeException(nameof(indexToRemove), "Index out of range.");
                }
                for (int i = indexToRemove; i < Index - 1; i++)
                {
                    MyArray[i] = MyArray[i + 1];
                }
                MyArray[Index - 1] = default(T);
                Index--;
            }
            public T[] GetElements()
            {
                T[] resultArray = new T[Index];
                Array.Copy(MyArray, resultArray, Index);
                return resultArray;
            }
        }
    }
}
