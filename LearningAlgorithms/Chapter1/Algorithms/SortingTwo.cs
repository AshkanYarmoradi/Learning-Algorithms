using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LearningAlgorithms.Abstracts;
using LearningAlgorithms.Chapter1.Dtos;

namespace LearningAlgorithms.Chapter1.Algorithms
{
    public class SortingTwoRequest : RequestAbstract<LargestTwoDto>
    {
        public SortingTwoRequest(int[] array)
        {
            Array = array;
        }
        
        public int[] Array { get; set; }
    }
    
    public class SortingTwoHandler: RequestHandlerAbstract<SortingTwoRequest, LargestTwoDto>
    {
        public override Task<LargestTwoDto> Handle(SortingTwoRequest request, CancellationToken cancellationToken)
        {
            var sortedArray = request.Array.OrderByDescending(x=>x).ToArray();
            return Task.FromResult(new LargestTwoDto(sortedArray[0], sortedArray[1]));
        }
    }
}