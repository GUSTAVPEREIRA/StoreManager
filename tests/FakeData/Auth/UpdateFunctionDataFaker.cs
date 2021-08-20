using Bogus;
using Core.Auth.ViewModels;

namespace FakeData.Auth
{
    public sealed class UpdateFunctionDataFaker : Faker<UpdateFunctionDto>
    {
        public UpdateFunctionDataFaker()
        {            
            var descriptionCount = new Faker().Random.Int(1, 150);
            RuleFor(x => x.Description, x => x.Lorem.Sentence(descriptionCount));
            RuleFor(x => x.Admin, x => x.Random.Bool());
        }
    }
}