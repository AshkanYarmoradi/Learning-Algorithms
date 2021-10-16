using System.Threading.Tasks;
using LearningAlgorithms.Chapter1.Algorithms;
using LearningAlgorithms.Generators;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace LearningAlgorithms.Chapter1
{
    public class Test : UnitTestBase
    {
        private readonly IArrayGenerator _arrayGenerator;
        
        public Test()
        {
            _arrayGenerator = _serviceProvider.GetRequiredService<IArrayGenerator>();
        }
        
        [Fact]
        public async Task TestLargestValueArray()
        {
            var array = _arrayGenerator.Generate<int>(2000000);

            var largest = await _mediator.Send(new LargestRequest(array));

            var largestNative = await _mediator.Send(new LargestNativeRequest(array));
            
            var largestAlternative = await _mediator.Send(new LargestAlternateRequest(array));
        }
    }
}
