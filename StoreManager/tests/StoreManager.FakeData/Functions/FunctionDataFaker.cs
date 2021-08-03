using System.Security.Cryptography.X509Certificates;
using Bogus;
using StoreManager.Core.Domain;

namespace StoreManager.FakeData.Functions
{
    public class FunctionDataFaker : Faker<Function>
    {
        public FunctionDataFaker()
        {
            FunctionRules();
        }

        public FunctionDataFaker(int id)
        {
            FunctionRules(id);
        }

        private void FunctionRules(int id = 0)
        {
            var functionId = id != 0 ? id : new Faker().PickRandom(1, 99999999);
            
            var descriptionCount = new Faker().PickRandom(10, 150);
            RuleFor(x => x.Description, x => x.Lorem.Sentence(descriptionCount));
            RuleFor(x => x.Id, x => functionId);
            RuleFor(x => x.Admin, x => true);
        }
    }
}