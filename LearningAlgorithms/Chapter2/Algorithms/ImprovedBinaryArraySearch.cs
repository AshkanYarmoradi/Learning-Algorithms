using System.Threading;
using System.Threading.Tasks;
using LearningAlgorithms.Abstracts;

namespace LearningAlgorithms.Chapter2.Algorithms
{
    public class ImprovedBinaryArraySearchRequest : RequestAbstract<int>
    {
        public ImprovedBinaryArraySearchRequest(int[] sortedArray, int target)
        {
            SortedArray = sortedArray;
            Target = target;
        }

        public int[] SortedArray { get; set; }

        public int Target { get; set; }
    }

    public class ImprovedBinaryArraySearchHandler : RequestHandlerAbstract<ImprovedBinaryArraySearchRequest, int>
    {
        public override Task<int> Handle(ImprovedBinaryArraySearchRequest request, CancellationToken cancellationToken)
        {
            var lo = 0;
            var hi = request.SortedArray.Length - 1;

            while (lo <= hi)
            {
                var mid = (hi + lo) / 2;

                var diff = request.Target - request.SortedArray[mid];

                if (diff < request.Target)
                {
                    hi = mid - 1;
                }
                else if(diff > request.Target)
                {
                    lo = mid + 1;
                }
                else
                {
                    return Task.FromResult(mid);
                }
            }

            return Task.FromResult(-1);
        }
    }
}