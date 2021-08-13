using Bogus;
using StoreManager.Core.Auth.ViewModels;

namespace StoreManager.FakeData.Auth
{
    public class NewFunctionDataFaker : Faker<NewFunctionDTO>
    {
        public NewFunctionDataFaker()
        {
            RuleFor(x => x.Description, x => x.Lorem.Sentence(150));
            RuleFor(x => x.Admin, x => true);
        }
    }
}