namespace MyWebAPIApp.Models
{
    public class NguoiDungVM
    {
        public string Ten { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
    }

    public class NguoiDung : NguoiDungVM
    {
        public Guid Id { get; set; }
    }
}
