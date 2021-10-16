using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MediatR.Pipeline;

namespace LearningAlgorithms.Abstracts
{
    public abstract class RequestAbstract<T>: RequestBase, IRequest<T> { }

    public abstract class RequestHandlerAbstract<T, TV> : IRequestHandler<T, TV> where T: RequestAbstract<TV>
    {
        public abstract Task<TV> Handle(T request, CancellationToken cancellationToken);
    }

    public class RequestPreProcessorAbstract<RequestAbstract> : IRequestPreProcessor<RequestAbstract> where RequestAbstract: RequestBase
    {
        public Task Process(RequestAbstract request, CancellationToken cancellationToken)
        {
            request.StartTime = DateTime.Now;
            Console.WriteLine($"Request Start at: {request.StartTime.ToLongTimeString()}");
            return Task.CompletedTask;
        }
    }
    
    public class RequestPostProcessorAbstract<RequestAbstract, T> : IRequestPostProcessor<RequestAbstract, T> where RequestAbstract: RequestBase
    {
        public Task Process(RequestAbstract request, T response, CancellationToken cancellationToken)
        {
            request.EndTime = DateTime.Now;
            Console.WriteLine($"Request End at: {request.EndTime.ToLongTimeString()}");
            Console.WriteLine($"Total Milliseconds: {(request.EndTime - request.StartTime).TotalMilliseconds}");
            return Task.CompletedTask;
        }
    }
}