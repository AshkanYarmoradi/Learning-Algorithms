using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LearningAlgorithms.Abstracts;
using LearningAlgorithms.Chapter1.Dtos;

namespace LearningAlgorithms.Chapter1.Algorithms
{
    public class MutableTwoRequest : RequestAbstract<LargestTwoDto>
    {
        public MutableTwoRequest(int[] array)
        {
            Array = array;
        }
        
        public int[] Array { get; set; }
    }
    
    public class MutableTwoHandler: RequestHandlerAbstract<MutableTwoRequest, LargestTwoDto>
    {
        public override Task<LargestTwoDto> Handle(MutableTwoRequest request, CancellationToken cancellationToken)
        {
            var max = request.Array.Max();
            var idx = Array.IndexOf(request.Array, max);
            request.Array = request.Array.Where((_, index) => index != idx).ToArray();
            return Task.FromResult(new LargestTwoDto(max, request.Array.Max()));
        }
    }
}