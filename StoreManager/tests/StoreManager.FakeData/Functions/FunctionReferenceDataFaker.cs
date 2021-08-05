using Bogus;
using StoreManager.SharedKernel.ViewModels.Functions;

namespace StoreManager.FakeData.Functions
{
    public class FunctionReferenceDataFaker : Faker<ReferenceFunctionDTO>
    {
        public FunctionReferenceDataFaker(int id = 0)
        {
            id = id == 0 ? new Faker().PickRandom(1, 9999) : id;            
            RuleFor(x => x.Id, id);
        }
    }
}