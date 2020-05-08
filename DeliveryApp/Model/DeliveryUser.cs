using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Model
{
    public class DeliveryUser
    {
        public string Id { get; set; }
        public string  Email { get; set; }
        public string Password { get; set; }

        public static async Task<bool> Login(string email, string password)
        {
            bool result = false;

            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                result = false;
            }
            else
            {
                var user = (await AzureHelper.MobileService.GetTable<DeliveryUser>().Where(u => u.Email == email).ToListAsync()).FirstOrDefault();

                if (user.Password != password)
                    result = false;
                else
                    result = true;
            }

            return result;
        }

        public static async Task<bool> Register(string email, string password, string confirmPassword)
        {
            bool result = false;
            if(!string.IsNullOrEmpty(password))
            {
                if(password == confirmPassword)
                {
                    var user = new DeliveryUser()
                    {
                        Email = email,
                        Password = password
                    };
                    await AzureHelper.MobileService.GetTable<DeliveryUser>().InsertAsync(user);

                    result = true;
                }
            }
            return result;
        }
    }
}
