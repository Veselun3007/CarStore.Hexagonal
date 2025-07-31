namespace CarStore.Hexagonal.Domain.Base
{
    public abstract class AggregateRoot<TKey>: IEventHandler
    {
        public TKey Id { get; set; }

        protected abstract void When(object @event);

        private readonly List<object> _changes;

        protected AggregateRoot() => _changes = new List<object>();

        protected void Apply(object @event)
        {
            When(@event);
            _changes.Add(@event);
        }

        public IEnumerable<object> GetChanges() => _changes.AsEnumerable();

        public void ClearChanges() => _changes.Clear();

        protected void ApplyToEntity(IEventHandler entity, object @event)
            => entity?.Handle(@event);

        void IEventHandler.Handle(object @event) => When(@event);
    }
}
