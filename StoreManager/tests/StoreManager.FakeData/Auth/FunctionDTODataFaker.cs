using Bogus;
using StoreManager.Core.Auth.ViewModels;

namespace StoreManager.FakeData.Auth
{
    public class FunctionDTODataFaker : Faker<FunctionDTO>
    {
        public FunctionDTODataFaker()
        {            
            var descriptionCount = new Faker().PickRandom(5, 150);
            RuleFor(x => x.Description, x => x.Lorem.Sentence(descriptionCount));
            RuleFor(x => x.Id, x => x.Random.Int(1, 9999));
            RuleFor(x => x.Admin, x => true);
        }
    }
}