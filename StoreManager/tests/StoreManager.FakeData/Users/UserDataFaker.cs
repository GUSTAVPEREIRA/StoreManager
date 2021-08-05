using Bogus;
using StoreManager.FakeData.Functions;
using StoreManager.SharedKernel.ViewModels.Users;

namespace StoreManager.FakeData.Users
{
    public class UserDataFaker : Faker<UserDTO>
    {
        public UserDataFaker()
        {
            var userId = new Faker().PickRandom(1, 9999);
            var functionId = new Faker().PickRandom(1, 9999);
                        
            RuleFor(x => x.Id, userId);
            RuleFor(x => x.Login, x => x.Person.UserName);
            RuleFor(x => x.Functions, x => new FunctionDTODataFaker().Generate(new Faker().PickRandom(1, 100)));
        }
    }
}