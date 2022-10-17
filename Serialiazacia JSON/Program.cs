using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialiazacia_JSON
{
    [Serializable]

    public class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public DateTime Dob { get; set; }

        [NonSerialized]
        public string IIN;

        public User()
        {

        }

        public User(int UserId, string FullName, DateTime Dob)
        {
            this.UserId = UserId;
            this.FullName = FullName;
            this.Dob = Dob;
        }

        public override string ToString()
        {
            return String.Format("ID: {0}; \n FullName: {1}", UserId, FullName);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User(1, "Anton Fedotov", DateTime.Now);
            Exmpl_02(user);

        }

        public static void Exmpl_03(User user)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(User));

            using (FileStream fs = new FileStream("user.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, user);
                Console.WriteLine("файл создан");
            }

            using (FileStream fs = new FileStream("user.dat", FileMode.Open))
            {
                User newUser = (User)formatter.Deserialize(fs);
                Console.WriteLine(newUser);
            }
        }

        public static void Exmpl_02(User user)
        {
            SoapFormatter formatter = new SoapFormatter();

            using (FileStream fs = new FileStream("user.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, user);
                Console.WriteLine("файл создан");
            }

            using (FileStream fs = new FileStream("user.dat", FileMode.Open))
            {
                User newUser = (User)formatter.Deserialize(fs);
                Console.WriteLine(newUser);
            }

        }
        public static void Exmpl_1(User user)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("user.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, user);
                Console.WriteLine("файл создан");
            }

            using (FileStream fs = new FileStream("user.dat", FileMode.Open))
            {
                User newUser = (User)formatter.Deserialize(fs);
                Console.WriteLine(newUser);
            }
        }
    }
}
