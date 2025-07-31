namespace CarStore.Hexagonal.Domain.Base
{
    public interface IEventHandler
    {
        void Handle(object @event);
    }
}
