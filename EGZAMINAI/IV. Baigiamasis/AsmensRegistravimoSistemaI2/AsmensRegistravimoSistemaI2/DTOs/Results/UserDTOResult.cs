namespace AsmensRegistravimoSistemaI2.DTOs.Results
{
    public class UserDTOResult
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] PasswordSalt { get; set; }
        public RoleTypes Roles { get; set; }
    }
}
