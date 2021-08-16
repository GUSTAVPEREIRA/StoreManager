using Bogus;
using StoreManager.Core.Auth.ViewModels;

namespace StoreManager.FakeData.Auth
{
    public sealed class UserDtoDataFaker : Faker<UserDto>
    {
        public UserDtoDataFaker()
        {            
                        
            RuleFor(x => x.Id, x => x.Random.Int(1, 99999));
            RuleFor(x => x.Login, x => x.Person.UserName);
            RuleFor(x => x.Functions, x => new FunctionDtoDataFaker().Generate(x.Random.Int(1, 100)));
        }
    }
}