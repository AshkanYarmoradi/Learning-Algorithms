using System.Threading.Tasks;
using LearningAlgorithms.Chapter1.Algorithms;
using LearningAlgorithms.Generators;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace LearningAlgorithms.Chapter1
{
    public class TestChapter1 : UnitTestBase
    {
        private readonly IArrayGenerator _arrayGenerator;
        
        public TestChapter1()
        {
            _arrayGenerator = _serviceProvider.GetRequiredService<IArrayGenerator>();
        }
        
        [Fact]
        public async Task TestLargest()
        {
            var array = _arrayGenerator.Generate<int>(2000000);

            var largest = await _mediator.Send(new LargestRequest(array));

            var largestNative = await _mediator.Send(new LargestNativeRequest(array));
            
            var largestAlternative = await _mediator.Send(new LargestAlternateRequest(array));
        }
        
        [Fact]
        public async Task TestLargestTwo()
        {
            var array = _arrayGenerator.Generate<int>(100000);

            var largestTwo = await _mediator.Send(new LargestTwoRequest(array));
            
            var sortingTwo = await _mediator.Send(new SortingTwoRequest(array));
            
            var doubleTwo = await _mediator.Send(new DoubleTwoRequest(array));
            
            var mutableTwo = await _mediator.Send(new MutableTwoRequest(array));
            
            var tournamentTwo = await _mediator.Send(new TournamentTwoRequest(array));
        }

        [Fact]
        public async Task TestTournament()
        {
            var array = _arrayGenerator.Generate<int>(8);

            var tournamentTwo = await _mediator.Send(new TournamentTwoRequest(array));
        }
    }
}
