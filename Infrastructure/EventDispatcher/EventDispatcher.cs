using Common;
using Domain.Events;
using MediatR;

namespace Infrastructure.EventDispatcher
{
    [MapServiceDependency("EventDispatcher")]
    internal class EventDispatcher : IEventDispatcher
    {
        public IMediator _mediator;

        public EventDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Publish(IEvent e)
        {
            _mediator.Publish(e);
        }
    }
}