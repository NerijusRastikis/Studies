﻿using AsmensRegistravimoSistemaI2.Models;

namespace AsmensRegistravimoSistemaI2.DTOs.Requests
{
    public class UserModelDTORequest
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PersonalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password {  get; set; }
        public IFormFile GIImage { get; set; }
        public string Town {  get; set; }
        public string Street { get; set; }
        public string HouseNumber {  get; set; }
        public int ApartmentNumber {  get; set; }
    }
}
