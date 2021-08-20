using Bogus;
using Core.Auth.ViewModels;

namespace FakeData.Auth
{
    public sealed class NewFunctionDataFaker : Faker<NewFunctionDto>
    {
        public NewFunctionDataFaker()
        {
            RuleFor(x => x.Description, x => x.Lorem.Sentence(150));
            RuleFor(x => x.Admin, x => x.Random.Bool());
        }
    }
}