using Business.Interfaces;
using Business.Other;
using Data.Models;

namespace Business.Managers
{
    public class CustomerPasswordManager
    {
        private Customer _customer;

        private IHasher _hasher = new SHA256Hasher();

        public Customer Customer
        {
            get => _customer;
            set
            {
                _customer = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        public IHasher Hasher
        {
            set
            {
                _hasher = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        public CustomerPasswordManager(Customer customer)
        {
            _customer = customer ?? throw new ArgumentNullException(nameof(customer));
        }

        public void ResetPassword(string newPassword)
        {
            if (newPassword == null)
                throw new ArgumentNullException(nameof(newPassword));
            const int minLength = 8;
            if (newPassword.Length < minLength)
                throw new ArgumentException($"The minimal length of the password is {minLength}", nameof(newPassword));
            _customer.HashPassword = _hasher.GetHash(newPassword);
        }

        public bool CheckPassword(string password)
        {
            if (password == null)
                return false;
            return _hasher.GetHash(password) == _customer.HashPassword;
        }
    }
}
