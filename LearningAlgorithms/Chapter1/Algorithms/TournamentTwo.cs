using System.Threading;
using System.Threading.Tasks;
using LearningAlgorithms.Abstracts;
using LearningAlgorithms.Chapter1.Dtos;

namespace LearningAlgorithms.Chapter1.Algorithms
{
    public class TournamentTwoRequest : RequestAbstract<LargestTwoDto>
    {
        public TournamentTwoRequest(int[] array)
        {
            Array = array;
        }
        
        public int[] Array { get; set; }
    }
    
    public class TournamentTwoHandler: RequestHandlerAbstract<TournamentTwoRequest, LargestTwoDto>
    {
        public override Task<LargestTwoDto> Handle(TournamentTwoRequest request, CancellationToken cancellationToken)
        {
            var N = request.Array.Length;
            var winner = new int[N - 1];
            var loser = new int[N - 1];
            var prior = new int [N - 1];
            prior[0] = -1;

            var idx = 0;

            for (var i = 0; i < N; i += 2)
            {
                if (request.Array[i] < request.Array[i + 1])
                {
                    winner[idx] = request.Array[i + 1];
                    loser[idx] = request.Array[i];
                }
                else
                {
                    winner[idx] = request.Array[i];
                    loser[idx] = request.Array[i+1];
                }

                idx += 1;
            }

            var m = 0;

            while (idx < N - 1)
            {
                if (winner[m] < winner[m + 1])
                {
                    winner[idx] = winner[m + 1];
                    loser[idx] = winner[m];
                    prior[idx] = m + 1;
                }
                else
                {
                    winner[idx] = winner[m];
                    loser[idx] = winner[m + 1];
                    prior[idx] = m;
                }

                m += 2;
                idx += 2;
            }

            var largest = winner[m];
            var second = loser[m];
            
            while (m >= 0)
            {
                if (second < loser[m])
                {
                    second = loser[m];
                }

                m = prior[m];
            }
            
            return Task.FromResult(new LargestTwoDto(largest, second));
        }
    }
}