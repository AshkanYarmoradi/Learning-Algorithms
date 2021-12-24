using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LearningAlgorithms.Abstracts;

namespace LearningAlgorithms.Chapter1.Algorithms
{
    public class LargestNativeRequest : RequestAbstract<int>
    {
        public LargestNativeRequest(int[] array)
        {
            Array = array;
        }
        
        public int[] Array { get; set; }
    }
    
    public class LargestNativeHandler: RequestHandlerAbstract<LargestNativeRequest, int>
    {
        public override Task<int> Handle(LargestNativeRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(request.Array.Max());
        }
    }
}