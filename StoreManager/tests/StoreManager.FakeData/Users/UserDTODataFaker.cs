using Bogus;
using StoreManager.FakeData.Functions;
using StoreManager.SharedKernel.ViewModels.Users;

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