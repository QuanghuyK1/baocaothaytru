namespace WEB_TTTN.Helpers
{
    public class validate
    {
        public static string ProcessString(string input)
        {
            switch (input)
            {
                case "validate_login_err_2":
                    return "username hoac password bi sai";
                case "validate_blank":
                    return "vui long khong de trong";
                case "validate_regis_err_1":
                    return "Username da ton tai";
                case "validate_regis_err_2":
                    return "password va conpassword khong trung nhau";
                case "validate_email_err":
                    return "email khong dung dinh dang";
                case "validate_regis_err_5":
                    return "yeu cau password gom co chu cai hoa, so va ky tu dac biet. It nhat 6 ki tu";
            }
            return null;
        }
    }
}
