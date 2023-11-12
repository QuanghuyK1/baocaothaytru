namespace WEB_TTTN.Helpers
{
    public class validate
    {
        public static string ProcessString(string input)
        {
            switch (input)
            {
                case "Fail_13":
                    return "So dien thoai khong hop le";
                case "Not_found":
                    return "Không tìm thấy dữ liệu";
                case "Fail_12":
                    return "Bảo hiểm y tế không tồn tại";
                case "Fail_11":
                    return "Date không hợp lệ";
                case "Fail_10":
                    return "Mật khẩu cũ không khớp";
                case "Fail_9":
                    return "username không tồn tại";
                case "Fail_8":
                    return "yeu cau kich hoat email";
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
                case "Success_1":
                    return "Them thanh cong";
                case "Success_2":
                    return "Sua thanh cong";
                case "Success_3":
                    return "Xoa thanh cong ";
                case "Success_4":
                    return "Xac nhan thanh cong ";
                case "Fail_1":
                    return "Them that bai ";
                case "Fail_2":
                    return "Sua that bai  ";
                case "Fail_3":
                    return "Xoa that bai ";
                case "Fail_4":
                    return "Vui long kiem tra lai ";
                case "Fail_5":
                    return "Xac nhan that bai ";
                case "Fail_6":
                    return "Loi tra cuu, thu lai";
                case "Fail_7":
                    return "Lich dat da ton tai";
            }
            return null;
        }
    }
}
