using System;
using DotnetAssessmentSocialMedia.Data.Entities;
using DotnetAssessmentSocialMedia.Services;

namespace DotnetAssessmentSocialMedia.Data
{
    public class Seeder
    {
        private SocialMediaContext _context;
        private IUserService _userService;

        public Seeder(SocialMediaContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public void Seed()
        {
            GenerateUsers(20);
        }

        private void GenerateUsers(int count)
        {
            for (var i = 0; i < count; ++i)
            {
                var firstName = GenerateName(GenerateInt(3, 9));
                var lastName = GenerateName(GenerateInt(4, 7));
                var email = $"{firstName.ToLower()[0]}.{lastName.ToLower()}@gmail.com";
                var password = $"password{GenerateInt(1000, 9999)}";
                var username = $"{GenerateName(GenerateInt(5, 9))}{GenerateInt(10, 99)}";

                var addPhoneNumber = GenerateInt(0, 10) % 2 == 0;          

                var credentials = new Credentials
                {
                    Username = username,
                    Password = password
                };

                var profile = new Profile
                {
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    Phone = addPhoneNumber ? "555-555-1234" : null
                };


                var user = new User
                {
                    Credentials = credentials,
                    Profile = profile
                };

                _userService.CreateUser(user);
            }
        } 
        
        private static string GenerateName(int len)
        { 
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;
        }
        
        private static int GenerateInt(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}