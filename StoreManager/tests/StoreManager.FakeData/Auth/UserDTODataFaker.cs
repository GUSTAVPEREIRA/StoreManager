using Bogus;
using StoreManager.Core.Auth.ViewModels;
using StoreManager.FakeData.Auth;

namespace StoreManager.FakeData.Users
{
    public class UserDTODataFaker : Faker<UserDTO>
    {
        public UserDTODataFaker()
        {            
                        
            RuleFor(x => x.Id, x => x.Random.Int(1, 99999));
            RuleFor(x => x.Login, x => x.Person.UserName);
            RuleFor(x => x.Functions, x => new FunctionDTODataFaker().Generate(x.Random.Int(1, 100)));
        }
    }
}