using System;
using Bogus;
using StoreManager.Core.Domain;
using StoreManager.FakeData.Functions;

namespace StoreManager.FakeData.Users
{
    public class UserDataFaker : Faker<User>
    {
        public UserDataFaker(bool isDeleted = false)
        {
            RuleFor(x => x.Id, x => x.Random.Int(1, 99999));
            RuleFor(x => x.Login, x => x.Person.UserName);
            RuleFor(x => x.Password, x => x.Internet.Password(x.Random.Int(10, 30)));
            RuleFor(x => x.Functions, x => new FunctionDataFaker().Generate(x.Random.Int(1, 100)));
            RuleFor(x => x.CreatedAt, x => x.Date.Between(DateTime.UtcNow.AddYears(-60), DateTime.UtcNow));
            RuleFor(x => x.UpdatedAt, x => DateTime.UtcNow);
            RuleFor(x => x.DeletedAt, x => !isDeleted ? null : DateTime.UtcNow);
            RuleFor(x => x.LastAccess, x => x.Date.Recent());
        }
    }
}