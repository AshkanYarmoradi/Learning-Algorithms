using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LearningAlgorithms.Abstracts;
using LearningAlgorithms.Chapter1.Dtos;

namespace LearningAlgorithms.Chapter1.Algorithms
{
    public class DoubleTwoRequest : RequestAbstract<LargestTwoDto>
    {
        public DoubleTwoRequest(int[] array)
        {
            Array = array;
        }
        
        public int[] Array { get; set; }
    }
    
    public class SDoubleTwoHandler: RequestHandlerAbstract<DoubleTwoRequest, LargestTwoDto>
    {
        public override Task<LargestTwoDto> Handle(DoubleTwoRequest request, CancellationToken cancellationToken)
        {
            var max = request.Array.Max(x => x);
            request.Array = request.Array.Where((_, index) => index != Array.IndexOf(request.Array, max)).ToArray();
            return Task.FromResult(new LargestTwoDto(max, request.Array.Max(x => x)));
        }
    }
}