﻿namespace AsmensRegistravimoSistemaI2.DTOs.Requests
{
    public class ImageDTORequest
    {
        public string Username { get; set; }
        public IFormFile Photo { get; set; }
    }
}
