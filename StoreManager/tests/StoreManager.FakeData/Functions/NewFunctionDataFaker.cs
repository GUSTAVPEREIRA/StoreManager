using Bogus;
using StoreManager.SharedKernel.ViewModels;

namespace StoreManager.FakeData.Functions
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