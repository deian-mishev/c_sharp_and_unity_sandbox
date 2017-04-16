using System;

namespace TypesAndVariables_F84396_D.Mishev
{
    class MarketingPOCO
    {
        private string firstName;
        private string lastName;
        private byte age;
        private string gender;
        private uint personalID;
        private ulong employeeNumber;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public byte Age
        {
            get { return age; }
            set { age = value; }
        }

        public uint PersonalID
        {
            get { return personalID; }
            set { personalID = value; }
        }

        public ulong EmployeeNumber
        {
            get { return employeeNumber; }
            set
            {
                if (value >= 27560000 && value <= 27569999) { employeeNumber = value; }
                else
                {
                    throw new ArgumentOutOfRangeException("Employee Number out of bounds. (27560000...27569999)");
                }
            }
        }
    }
}
