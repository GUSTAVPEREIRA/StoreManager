using Bogus;
using StoreManager.Core.ViewModels.Functions;

namespace StoreManager.FakeData.Functions
{
    public class UpdateFunctionDataFaker : Faker<UpdateFunctionDTO>
    {
        public UpdateFunctionDataFaker()
        {            
            var descriptionCount = new Faker().Random.Int(1, 99999999);
            RuleFor(x => x.Description, x => x.Lorem.Sentence(100));
            RuleFor(x => x.Admin, x => true);
        }
    }
}