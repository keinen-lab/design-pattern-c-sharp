using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designpattern
{
    public enum RecordType
    {
        Car,
        Person
    }

    // Record is the Prototype
    public abstract class Record
    {
        public abstract Record Clone();
    }

    // PersonRecord is the concrete prototype
    public class PersonRecord : Record
    {
        string name;
        int age;

        public PersonRecord(string _name, int _age)
        {
            name = _name;
            age = _age;
        }

        public override Record Clone()
        {
            return (Record)this.MemberwiseClone(); // default shallow copy
        }

        public override string ToString()
        {
            return string.Format("Person Record : name ({0}), age({1})", name, age);
        }
    }

    // CarRecord is another concrete prototype
    public class CarRecord : Record
    {
        string carname;
        Guid id;

        public CarRecord(string _name, Guid _id)
        {
            carname = _name;
            id = _id;
        }

        public override Record Clone()
        {
            CarRecord clone = (CarRecord)this.MemberwiseClone(); // default shallow copy
            clone.id = Guid.NewGuid(); // always generate new id
            return clone;
        }

        public override string ToString()
        {
            return string.Format("Car Record : name({0}), id({1})", carname, id);
        }
    }

    // RecordFactory is the client
    public class RecordFactory
    {
        private static Dictionary<RecordType, Record> _prototypes = new Dictionary<RecordType, Record>();

        public RecordFactory()
        {
            _prototypes.Add(RecordType.Car, new CarRecord("Ferrari", Guid.NewGuid()));
            _prototypes.Add(RecordType.Person, new PersonRecord("Tom", 12));
        }

        public Record CreateRecord(RecordType type)
        {
            return _prototypes[type].Clone();
        }
    }


    class prototypePattern
    {
        public static void Main(string[] args)
        {
            RecordFactory factory = new RecordFactory();

            Record record = factory.CreateRecord(RecordType.Car);
            Console.WriteLine(record.ToString());

            record = factory.CreateRecord(RecordType.Person);
            Console.WriteLine(record.ToString());

            Console.ReadKey();
        }
    }
}