using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFramework.Tools;

namespace TestFramework.Data.Users
{
    public sealed class UserRepository
    {
        // Singleton
        //реалізовуємо даний паттерн для того, щоб забезпечити
        //наявність ЛИШЕ одного об'єкту даного класу під час виконання програми

        // Static Method

        private volatile static UserRepository instance;
        private static object lockingObject = new object();

        private UserRepository()
        {
        }

        public static UserRepository Get()
        {
            if (instance == null)
            {
                lock (lockingObject)
                {
                    if (instance == null)
                    {
                        instance = new UserRepository();
                    }
                }
            }
            return instance;
        }

        public IUser Registered()
        {
            return User.Get()
                .SetLogin("work")
                .SetFirstname("Firstname")
                .SetLastname("Lastname")
                .SetEmail("Email")
                .SetPhone("123456789")
                .SetAddressMain("AddressMain")
                .SetCity("City")
                .SetPostcode("1234567")
                .SetCoutry("Ukraine")
                .SetRegionState("Ukr")
                .SetPassword("qwerty")
                .SetSubscribe(true)
                .SetFax("12345")
                .SetCompany("Company")
                .SetAddressAdd("AddressAdd")
                .Build();
        }

        public IUser Invalid()
        {
            return User.Get()
                .SetLogin("hahaha")
                .SetFirstname("Firstname")
                .SetLastname("Lastname")
                .SetEmail("Email")
                .SetPhone("123456789")
                .SetAddressMain("AddressMain")
                .SetCity("City")
                .SetPostcode("1234567")
                .SetCoutry("Ukraine")
                .SetRegionState("Ukr")
                .SetPassword("qwerty")
                .SetSubscribe(true)
                .SetFax("12345")
                .SetCompany("Company")
                .SetAddressAdd("AddressAdd")
                .Build();
        }

        public IList<IUser> FromCsv()
        {
            return FromCsv("ExistUsers.csv");
        }

        public IList<IUser> FromCsv(string filename)
        {
            return User.GetAllUsers(new CSVReader(filename));
        }

        public IList<IUser> FromExcel()
        {
            return FromExcel("ExistUsers.xlsx");
        }

        public IList<IUser> FromExcel(string filename)
        {
            return User.GetAllUsers(new ExcelReader(filename));
        }

    }
}
