﻿namespace NarkoCenter.Domain.Dtos.Users
{
    public class UserUpdateDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}