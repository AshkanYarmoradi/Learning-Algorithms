using LearningAlgorithms.Generators;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LearningAlgorithms
{
    public abstract class UnitTestBase
    {
        protected readonly ServiceProvider _serviceProvider;

        protected readonly IMediator _mediator;
        
        public UnitTestBase()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddMediatR(typeof(UnitTestBase));

            serviceCollection.AddSingleton<IArrayGenerator, ArrayGenerator>();

            _serviceProvider = serviceCollection.BuildServiceProvider();

            _mediator = _serviceProvider.GetRequiredService<IMediator>();
        }
    }
}