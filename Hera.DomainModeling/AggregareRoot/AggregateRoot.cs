using System.Collections.Generic;
using Hera.DomainModeling.Entity;
using Hera.DomainModeling.Identity;
using Hera.DomainModeling.DomainEvent;

namespace Hera.DomainModeling.AggregareRoot
{
    public abstract class AggregateRoot<TAggregateRootState> : IAggregateRoot
        where TAggregateRootState : IAggregateRootState, new()
    {
        #region Fields

        private int _revision;
        private TAggregateRootState _state;
        private List<IDomainEvent> _uncommittedEvents;
        private Dictionary<IIdentity, IEntity> _entities;

        #endregion

        #region Constructors

        protected AggregateRoot()
        {
            _revision = 0;
            _state = new TAggregateRootState();
            _state.Root = this;
            _uncommittedEvents = new List<IDomainEvent>();
            _entities = new Dictionary<IIdentity, IEntity>();
        }

        #endregion

        #region Properties

        protected TAggregateRootState State
        {
            get { return _state; }
        }
        int IAmEventSourced.Revision
        {
            get { return _uncommittedEvents.Count > 0 ? _revision + 1 : _revision; }
        }
        IAggregateRootState IHaveState<IAggregateRootState>.State
        {
            get { return _state; }
        }
        IEnumerable<IDomainEvent> IAmEventSourced.UncommittedEvents
        {
            get { return _uncommittedEvents.AsReadOnly(); }
        }

        #endregion

        #region Methods

        internal protected void Apply(IDomainEvent @event)
        {
            Mutate(@event);
            _uncommittedEvents.Add(@event);
         }
        void IAmEventSourced.ReplayEvents(IEnumerable<IDomainEvent> events, int revision)
        {
            _revision = revision;
            foreach (IDomainEvent @event in events)
            {
                Mutate(@event);
            }
        }
        void IAmEventSourced.RegisterEntity(IIdentity entityId, IEntity entity)
        {
            _entities.Add(entityId, entity);
        }
        private void Mutate(IDomainEvent @event)
        {
            EntityEvent entityEvent = @event as EntityEvent;
            if (entityEvent != null)
                MutateEntity(_entities[entityEvent.EntityId], entityEvent.Event);
            else
                MutateAggregate(@event);
        }
        private void MutateAggregate(IDomainEvent @event)
        {
            ((dynamic)State).When((dynamic)@event);
        }
        private void MutateEntity(IEntity entity, IDomainEvent @event)
        {
            ((dynamic)entity.State).When((dynamic)@event);
        }

        #endregion
    }
}
