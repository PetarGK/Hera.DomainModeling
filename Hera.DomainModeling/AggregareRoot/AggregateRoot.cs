using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReflectionMagic;
using Hera.DomainModeling.Entity;

namespace Hera.DomainModeling.AggregareRoot
{
    public abstract class AggregateRoot<TState> : IAggregateRoot
        where TState : IAggregateRootState, new()
    {
        #region Fields

        private int _revision;
        private TState _state;
        private List<IEvent> _uncommittedEvents;
        private Dictionary<Guid, IEntity> _entities;

        #endregion

        #region Constructors

        protected AggregateRoot()
        {
            _revision = 0;
            _state = new TState();
            _uncommittedEvents = new List<IEvent>();
        }

        #endregion

        #region Properties

        public TState State
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
        IEnumerable<IEvent> IAmEventSourced.UncommittedEvents
        {
            get { return _uncommittedEvents.AsReadOnly(); }
        }

        #endregion

        #region Methods

        protected void Apply(IEvent @event)
        {
            Mutate(@event);
            _uncommittedEvents.Add(@event);
        }
        void IAmEventSourced.ReplayEvents(List<IEvent> events, int revision)
        {
            _revision = revision;
            foreach (IEvent @event in events)
            {
                Mutate(@event);
            }
        }
        void IAmEventSourced.RegisterEntity(Guid entityId, IEntity entity)
        {
            _entities.Add(entityId, entity);
        }
        private void Mutate(IEvent @event)
        {
            EntityEvent entityEvent = @event as EntityEvent;
            if (entityEvent != null)
                MutateEntity(_entities[entityEvent.EntityId], @event);
            else
                MutateAggregate(@event);
        }
        private void MutateAggregate(IEvent @event)
        {
            this.AsDynamic().When((dynamic)@event);
        }
        private void MutateEntity(IEntity entity, IEvent @event)
        {
            entity.AsDynamic().When((dynamic)@event);
        }

        #endregion
    }
}
