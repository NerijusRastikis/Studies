namespace AsmensRegistravimoSistemaI2.DTOs.Requests
{
    public class UserDTORequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] PasswordSalt { get; set; }
        public RoleTypes Roles { get; set; }
    }
}