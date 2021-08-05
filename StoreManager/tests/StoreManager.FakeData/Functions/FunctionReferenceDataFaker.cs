using Bogus;
using StoreManager.SharedKernel.ViewModels.Functions;

namespace StoreManager.FakeData.Functions
{
    public class FunctionReferenceDataFaker : Faker<ReferenceFunctionDTO>
    {
        public FunctionReferenceDataFaker(int id = 0)
        {
            RuleFor(x => x.Id, x => id == 0 ? x.Random.Int(1, 9999) : id);
        }
    }
}