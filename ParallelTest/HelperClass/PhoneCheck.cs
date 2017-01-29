using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DBCompareWithUIParallelOptions.HelperClass
{
    class PhoneCheck
    {
        //get all phone masks from DB 
        //pass an instace of InfoFromDB as a parameter
        public static List<PhoneMasks> GetPhoneMasks(InfoFromDB corresponding)
        {
            List<PhoneMasks> phoneMaskList = new List<PhoneMasks>();
            phoneMaskList = corresponding.getInfoFromT_PHONECODESUA().ToList();
            return phoneMaskList;
        }

        public static string checkPhoneNumber(string PhoneNumber, List<PhoneMasks> phoneMaskList)
        {
            string phone = "";
            int isMobile = 0;
            //make phone number clear
            string clearPhone = Regex.Replace(PhoneNumber, @"[^0-9]", "");

            //find proper mask
            var phoneMask = phoneMaskList.Where(mask => Regex.Match(clearPhone, mask.PhoneMask).Success == true);

            //phone for the proper mask
            phone = phoneMask.Select(mask => Regex.Match(clearPhone, mask.PhoneMask).Value).FirstOrDefault();

            //check phone number
            if (phone != null && phone != "")
            {
                // returns characteristic of the phone by its mask (mobile or not)
                isMobile = phoneMask.FirstOrDefault().Mobile;
                if (phone.Length > 10)
                {
                    //get last 10 numbers of the phone
                    phone = phone.Substring(phone.Length - 10);
                }
                else if (phone.Length == 9)
                {
                    //add 0 if phone number less than 9
                    phone = "0" + phone;
                }
                else if (phone.Length < 9)
                {
                    return phone;
                }
            }
            else
            {
                return phone;
            }
            return phone;
        }
    }
}
