using System;
using System.Linq;
using System.Threading.Tasks;
using LearningAlgorithms.Chapter2.Algorithms;
using LearningAlgorithms.Generators;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace LearningAlgorithms.Chapter2
{
    public class TestChapter2 : UnitTestBase
    {
        private readonly IArrayGenerator _arrayGenerator;
        
        public TestChapter2()
        {
            _arrayGenerator = _serviceProvider.GetRequiredService<IArrayGenerator>();
        }

        [Fact]
        public async Task BinarySearch()
        {
            var array = _arrayGenerator.Generate<int>(100000).OrderBy(x=>x).ToArray();
            var target = array.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            var binaryArraySearch = await _mediator.Send(new BinaryArraySearchRequest(array, target));
            var improvedBinaryArraySearch = await _mediator.Send(new ImprovedBinaryArraySearchRequest(array, target));
        }
    }
}