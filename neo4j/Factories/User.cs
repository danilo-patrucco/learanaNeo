using System;
using Bogus;
using Database.Models;

namespace Database.Factories
{
    public class UserFactory
    {
        public static User CreateFakeUser()
        {
            Faker _fakeUser = new Faker();

            User _user = Models.User.Create(_fakeUser.Person.UserName, _fakeUser.Person.Email, _fakeUser.Person.FirstName, _fakeUser.Person.LastName);

            return _user;
        }


    }
}
