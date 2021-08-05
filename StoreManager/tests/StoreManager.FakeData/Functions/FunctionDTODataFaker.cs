using Bogus;
using StoreManager.SharedKernel.ViewModels;

namespace StoreManager.FakeData.Functions
{
    public class FunctionDTODataFaker : Faker<FunctionDTO>
    {
        public FunctionDTODataFaker()
        {
            var functionId = new Faker().PickRandom(1, 99999999);

            var descriptionCount = new Faker().PickRandom(5, 150);
            RuleFor(x => x.Description, x => x.Lorem.Sentence(descriptionCount));
            RuleFor(x => x.Id, x => functionId);
            RuleFor(x => x.Admin, x => true);
        }
    }
}