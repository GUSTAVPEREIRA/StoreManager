using Bogus;
using StoreManager.Core.Auth.ViewModels;

namespace StoreManager.FakeData.Auth
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