using AsmensRegistravimoSistemaI2.Services.Interfaces;

namespace AsmensRegistravimoSistemaI2.Services
{
    public class PhoneNumberConverter : IPhoneNumberConverter
    {
        public string ConvertPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.StartsWith("+370"))
            {
                phoneNumber = "0" + phoneNumber.Substring(4);
            }
            else if (phoneNumber.StartsWith("370"))
            {
                phoneNumber = "0" + phoneNumber.Substring(3);
            }
            else if (phoneNumber.StartsWith("8"))
            {
                phoneNumber = "0" + phoneNumber.Substring(1);
            }

            return phoneNumber;
        }
    }
}
