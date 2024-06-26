﻿namespace DTOs.UserDTO
{
    public class UsersDTO
    {
        public int IdUser { get; init; }
        public string Email { get; init; }
        public string Name { get; init; } 
        public string LastName { get; init; }
        public bool AccountType { get; init; }
        public DateOnly DateBirth { get; init; }
        public string UserName { get; init; }
        public string Password { get; init; }
        public bool Restore { get; init; }
        public bool Confirmation { get; init; }
    }
}
