using System;
using System.Collections.Generic;
using Bogus;
using StoreManager.Core.Domain;
using StoreManager.FakeData.Functions;

namespace StoreManager.FakeData.Users
{
    public class UserDataFaker : Faker<User>
    {
        public UserDataFaker(bool isDeleted = false, bool genFunctionId = false)
        {
            RuleFor(x => x.DeletedAt, x => !isDeleted ? null : DateTime.UtcNow);

            var functions = genFunctionId ?
                new FunctionDataFaker().Generate(new Faker().Random.Int(1, 100)) :
                new List<Function>();

            RuleFor(x => x.Functions, x => functions);

            CommonRules();
        }

        public UserDataFaker() : this(false, false)
        {

        }

        private void CommonRules()
        {
            RuleFor(x => x.Id, x => x.Random.Int(1, 99999));
            RuleFor(x => x.Login, x => x.Person.UserName);
            RuleFor(x => x.Password, x => x.Internet.Password(x.Random.Int(10, 30)));

            RuleFor(x => x.CreatedAt, x => x.Date.Between(DateTime.UtcNow.AddYears(-60), DateTime.UtcNow));
            RuleFor(x => x.UpdatedAt, x => DateTime.UtcNow);
            RuleFor(x => x.LastAccess, x => x.Date.Recent());
        }
    }
}