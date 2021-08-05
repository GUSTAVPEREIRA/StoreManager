using Bogus;
using StoreManager.FakeData.Functions;
using StoreManager.SharedKernel.ViewModels.Users;

namespace StoreManager.FakeData.Users
{
    public class NewUserDataFaker : Faker<NewUserDTO>
    {
        public NewUserDataFaker()
        {
            RuleFor(x => x.Login, x => x.Person.UserName);
            RuleFor(x => x.Password, x => x.Internet.Password(new Faker().PickRandom(5, 20)));
            RuleFor(x => x.Functions, x => new FunctionReferenceDataFaker().Generate(new Faker().PickRandom(1, 100)));
        }
    }
}