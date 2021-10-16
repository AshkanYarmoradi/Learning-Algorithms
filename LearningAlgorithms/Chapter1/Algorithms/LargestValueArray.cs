using System.Threading;
using System.Threading.Tasks;
using LearningAlgorithms.Abstracts;

namespace LearningAlgorithms.Chapter1.Algorithms
{
    public class LargestValueArrayRequest : RequestAbstract<int>
    {
        public LargestValueArrayRequest(int[] array)
        {
            Array = array;
        }
        
        public int[] Array { get; set; }
    }
    
    public class LargestValueArrayHandler: RequestHandlerAbstract<LargestValueArrayRequest, int>
    {
        public override Task<int> Handle(LargestValueArrayRequest request, CancellationToken cancellationToken)
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