using System;

namespace Task1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string id = "test";

            Miles miles1 = new Miles(10);
            Miles miles2 = new Miles(20);
            Miles miles3 = new Miles(30);

            Kilometers kilos1 = new Kilometers(100);
            Kilometers kilos2 = new Kilometers(200);
            Kilometers kilos3 = new Kilometers(300);

            Miles miles = miles1 + miles2;
            Kilometers kilos = kilos1 + kilos2;

            bool isSameLen = miles1 == miles2;

            SavePathToDataBase(id, miles1, kilos1);

            Console.ReadKey();
        }
        public static void SavePathToDataBase(string id, Miles milesPath, Kilometers kilometersPath)
        {
            if (id is null) throw new ArgumentNullException(nameof(id));
            if (milesPath is null) throw new ArgumentNullException(nameof(milesPath));
            if (kilometersPath is null) throw new ArgumentNullException(nameof(kilometersPath));
            //...
            // Do something with database
            //...
            Console.WriteLine("{0}: {1} m.miles, {2} kilometers", id, milesPath.Value, kilometersPath.Value);
        }
        public static void SavePathToDataBase(string id, Kilometers kilometersPath, Miles milesPath)
        {
            SavePathToDataBase(id, milesPath, kilometersPath);
        }
    }
    public class Distance: IComparable
    {
        private int _value;
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value >= 0)
                {
                    _value = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
            }
        }
        public Distance(int value)
        {
            Value = value;
        }
        public virtual double GetDistanceInMeters()
        {
            return (double)Value;
        }
        public override bool Equals(object obj)
        {
            if (obj is null) throw new ArgumentNullException(nameof(obj));

            if (obj is Distance)
            {
                Distance distance = obj as Distance;
                return GetDistanceInMeters() == distance.GetDistanceInMeters();
            }
            else
            {
                throw new ArgumentException(nameof(obj));
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public int CompareTo(object obj)
        {
            if (obj is null) throw new ArgumentNullException(nameof(obj));

            if (obj is Distance)
            {
                Distance distance = obj as Distance;
                if (GetDistanceInMeters() > distance.GetDistanceInMeters())
                {
                    return 1;
                }
                else if (GetDistanceInMeters() < distance.GetDistanceInMeters())
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                throw new ArgumentException(nameof(obj));
            }
        }
        public static bool operator >(Distance obj1, Distance obj2)
        {
            if (obj1 is null) throw new ArgumentNullException(nameof(obj1));
            if (obj2 is null) throw new ArgumentNullException(nameof(obj2));

            return obj1.CompareTo(obj2) > 0 ? true : false;
        }
        public static bool operator >=(Distance obj1, Distance obj2)
        {
            if (obj1 is null) throw new ArgumentNullException(nameof(obj1));
            if (obj2 is null) throw new ArgumentNullException(nameof(obj2));

            return obj1.CompareTo(obj2) >= 0 ? true : false;
        }
        public static bool operator <=(Distance obj1, Distance obj2)
        {
            if (obj1 is null) throw new ArgumentNullException(nameof(obj1));
            if (obj2 is null) throw new ArgumentNullException(nameof(obj2));

            return obj1.CompareTo(obj2) <= 0 ? true : false;
        }
        public static bool operator <(Distance obj1, Distance obj2)
        {
            if (obj1 is null) throw new ArgumentNullException(nameof(obj1));
            if (obj2 is null) throw new ArgumentNullException(nameof(obj2));

            return obj1.CompareTo(obj2) < 0 ? true : false;
        }
        public static bool operator ==(Distance obj1, Distance obj2)
        {
            if (obj1 is null) throw new ArgumentNullException(nameof(obj1));
            if (obj2 is null) throw new ArgumentNullException(nameof(obj2));

            return obj1.Equals(obj2);
        }
        public static bool operator !=(Distance obj1, Distance obj2)
        {
            if (obj1 is null) throw new ArgumentNullException(nameof(obj1));
            if (obj2 is null) throw new ArgumentNullException(nameof(obj2));

            return !(obj1.Equals(obj2));
        }
    }

    public class Miles : Distance
    {
        public Miles(int value) : base (value)
        {

        }
        public sealed override double GetDistanceInMeters()
        {
            return (double)Value * 1.852 * 1000.0;
        }
        public static Miles operator +(Miles obj1, Miles obj2)
        {
            if (obj1 is null) throw new ArgumentNullException(nameof(obj1));
            if (obj2 is null) throw new ArgumentNullException(nameof(obj2));

            return new Miles(obj1.Value + obj2.Value);
        }
        public static Miles operator -(Miles obj1, Miles obj2)
        {
            if (obj1 is null) throw new ArgumentNullException(nameof(obj1));
            if (obj2 is null) throw new ArgumentNullException(nameof(obj2));

            return new Miles(obj1.Value - obj2.Value);
        }
    }
    public class Kilometers : Distance
    {
        public Kilometers(int value) : base(value)
        {

        }
        public sealed override double GetDistanceInMeters()
        {
            return (double)Value * 1000.0;
        }
        public static Kilometers operator +(Kilometers obj1, Kilometers obj2)
        {
            if (obj1 is null) throw new ArgumentNullException(nameof(obj1));
            if (obj2 is null) throw new ArgumentNullException(nameof(obj2));

            return new Kilometers(obj1.Value + obj2.Value);
        }
        public static Kilometers operator -(Kilometers obj1, Kilometers obj2)
        {
            if (obj1 is null) throw new ArgumentNullException(nameof(obj1));
            if (obj2 is null) throw new ArgumentNullException(nameof(obj2));

            return new Kilometers(obj1.Value - obj2.Value);
        }
    }
}