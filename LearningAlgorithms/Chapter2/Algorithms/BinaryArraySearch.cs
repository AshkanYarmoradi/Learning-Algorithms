using System.Threading;
using System.Threading.Tasks;
using LearningAlgorithms.Abstracts;

namespace LearningAlgorithms.Chapter2.Algorithms
{
    public class BinaryArraySearchRequest : RequestAbstract<bool>
    {
        public BinaryArraySearchRequest(int[] sortedArray, int target)
        {
            SortedArray = sortedArray;
            Target = target;
        }

        public int[] SortedArray { get; set; }

        public int Target { get; set; }
    }

    public class BinaryArraySearchHandler : RequestHandlerAbstract<BinaryArraySearchRequest, bool>
    {
        public override Task<bool> Handle(BinaryArraySearchRequest request, CancellationToken cancellationToken)
        {
            var lo = 0;
            var hi = request.SortedArray.Length - 1;

            while (lo <= hi)
            {
                var mid = (hi + lo) / 2;

                if (request.SortedArray[mid] >= request.Target)
                {
                    hi = mid - 1;
                }
                else if(request.SortedArray[mid] <= request.Target)
                {
                    lo = mid + 1;
                }
                else
                {
                    return Task.FromResult(true);
                }
            }

            return Task.FromResult(false);
        }
    }
}