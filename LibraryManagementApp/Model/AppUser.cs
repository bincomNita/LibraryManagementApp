﻿using System.Text.Json.Serialization;

namespace LibraryManagementApp.Model
{
    public class AppUser
    {
        public string Id { get; set; }=Guid.NewGuid().ToString();
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; }=string.Empty;
       
        public string Role { get; set; } = "User";
    }
}
