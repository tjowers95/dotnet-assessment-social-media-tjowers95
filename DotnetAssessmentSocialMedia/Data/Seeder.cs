using System;
using DotnetAssessmentSocialMedia.Data.Entities;
using DotnetAssessmentSocialMedia.Services;

namespace DotnetAssessmentSocialMedia.Data
{
    public class Seeder
    {
        private IUserService _userService;

        public Seeder(IUserService userService)
        {
            _userService = userService;
        }

        public void Seed()
        {
            GenerateUsers(25);

        }

        private void GenerateUsers(int count)
        {
            for (var i = 0; i < count; ++i)
            {
                var firstName = ((char)(i+97)).ToString();
                var lastName = ((char)(i+97)).ToString();
                var email = firstName + "@gmail.com";
                var password = firstName;
                var username = firstName;

                var addPhoneNumber = GenerateInt(0, 10) % 2 == 0;          

                var credentials = new Credentials
                {
                    Username = firstName,
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
            string name = "";
            name += consonants[r.Next(consonants.Length)].ToUpper();
            name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                name += consonants[r.Next(consonants.Length)];
                b++;
                name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return name;
        }
        
        private static int GenerateInt(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}