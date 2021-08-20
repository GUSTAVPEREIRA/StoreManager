using Bogus;
using Core.Auth;

namespace FakeData.Auth
{
    public sealed class FunctionDataFaker : Faker<Function>
    {
        public FunctionDataFaker() : this(0)
        {
        }

        public FunctionDataFaker(int id)
        {
            var functionId = id != 0 ? id : new Faker().Random.Int(1, 99999999);
            RuleFor(x => x.Id, functionId);
            CommonRules();
        }

        private void CommonRules()
        {
            var descriptionCount = new Faker().Random.Int(5, 150);
            RuleFor(x => x.Description, x => x.Lorem.Sentence(descriptionCount));
            RuleFor(x => x.Admin, x => x.Random.Bool());
        }
    }
}