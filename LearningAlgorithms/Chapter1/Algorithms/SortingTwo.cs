using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LearningAlgorithms.Abstracts;
using LearningAlgorithms.Chapter1.Dtos;

namespace LearningAlgorithms.Chapter1.Algorithms
{
    public class LargestTwoRequest : RequestAbstract<LargestTwoDto>
    {
        public LargestTwoRequest(int[] array)
        {
            Array = array;
        }
        
        public int[] Array { get; set; }
    }
    
    public class LargestTwoHandler: RequestHandlerAbstract<LargestTwoRequest, LargestTwoDto>
    {
        public override Task<LargestTwoDto> Handle(LargestTwoRequest request, CancellationToken cancellationToken)
        {
            var max = request.Array[0];
            var second = request.Array[1];
            if (second > max)
            {
                max = request.Array[1];
                second = request.Array[0];
            }

            foreach (var idx in Enumerable.Range(2, (request.Array.Length - 2)))
            {
                if (max < request.Array[idx])
                {
                    max = request.Array[idx];
                }else if (second < request.Array[idx])
                {
                    second = request.Array[idx];
                }
            }

            return Task.FromResult(new LargestTwoDto(max, second));
        }
    }
}