using System;
using System.Text.Json.Serialization;

namespace Project_KTMH
{
    public abstract class Person
    {
        private string name;
        private string email;
        private DateTime dateOfBirth;
        private string phone_num;
        private string address;

        [JsonInclude]
        public string Name { get; private set; }
        [JsonInclude]
        public string Email { get; private set; }
        [JsonInclude]
        public DateTime DateOfBirth { get; private set; }
        [JsonInclude]
        public string Phone_num { get; private set; }
        [JsonInclude]
        public string Address { get; private set; }

        protected Person(string name, string email, DateTime dateofbirth, string phone_num, string address)
        {
            this.Name = name;
            this.Email = email;
            this.DateOfBirth = dateofbirth;
            this.Phone_num = phone_num;
            this.Address = address;
        }

        protected Person()
        {
            this.Name = Name;
            this.Email = Email;
            this.DateOfBirth = DateOfBirth;
            this.Phone_num = Phone_num;
            this.Address = Address;
        }

        public virtual void UpdatePersonalDetails(string name, string email, DateTime dateOfBirth, string phone_num, string address)
        {
            this.Name = name;
            this.Email = email;
            this.DateOfBirth = dateOfBirth;
            this.Phone_num = phone_num;
            this.Address = address;
        }
    }
}