using System.Threading;
using System.Threading.Tasks;
using LearningAlgorithms.Abstracts;

namespace LearningAlgorithms.Chapter1.Algorithms
{
    public class LargestRequest : RequestAbstract<int>
    {
        public LargestRequest(int[] array)
        {
            Array = array;
        }
        
        public int[] Array { get; set; }
    }
    
    public class LargestHandler: RequestHandlerAbstract<LargestRequest, int>
    {
        public override Task<int> Handle(LargestRequest request, CancellationToken cancellationToken)
        {
            var max = request.Array[0];
            for (var i = 1; i < request.Array.Length; i++)
            {
                if (max < request.Array[i])
                {
                    max = request.Array[i];
                }
            }

            return Task.FromResult(max);
        }
    }
}