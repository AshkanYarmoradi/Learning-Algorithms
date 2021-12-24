using System;
using System.Threading;
using System.Threading.Tasks;
using LearningAlgorithms.Abstracts;

namespace LearningAlgorithms.Chapter1.Algorithms
{
    public class LargestAlternateRequest : RequestAbstract<int>
    {
        public LargestAlternateRequest(int[] array)
        {
            Array = array;
        }
        
        public int[] Array { get; set; }
    }
    
    public class LargestAlternateHandler: RequestHandlerAbstract<LargestAlternateRequest, int>
    {
        public override Task<int> Handle(LargestAlternateRequest request, CancellationToken cancellationToken)
        {
            foreach (var v in request.Array)
            {
                var vIsLargest = true;
                foreach (var x in request.Array)
                {
                    if (v < x)
                    {
                        vIsLargest = false;
                        break;
                    }
                }

                if (vIsLargest)
                {
                    return Task.FromResult(v);
                }
            }

            throw new Exception("Array is Empty!");
        }
    }
}