using Hera.DomainModeling.AggregareRoot;
using Hera.DomainModeling.DomainEvent;
using Hera.DomainModeling.Identity;
using System.Runtime.Serialization;
using System;

namespace Hera.DomainModeling.Entity
{
    public abstract class Entity<TEntityState> : ISerializable, IEntity
        where TEntityState : IEntityState, new()
    {
        #region Fields

        private IAggregateRoot _root;
        private TEntityState _state;

        #endregion

        #region Constructors

        protected Entity(IAggregateRoot root, IIdentity id)
        {
            _root = root;

            _state = new TEntityState();
            _state.Id = id;

            _root.RegisterEntity(id, this);
        }
        public Entity(SerializationInfo info, StreamingContext context)
        {
            _root = (IAggregateRoot)info.GetValue("_root", typeof(IAggregateRoot));
            _state = (TEntityState)info.GetValue("_state", typeof(TEntityState));
        }

        #endregion

        #region Properties

        protected TEntityState State
        {
            get { return _state; }
        }
        IEntityState IHaveState<IEntityState>.State
        {
            get { return _state; }
        }
        IAggregateRoot IHaveRoot<IAggregateRoot>.Root
        {
            get { return _root; }
            set { }
        }

        #endregion

        #region Methods

        protected void Apply(IDomainEvent @event)
        {
            var entityEvent = new EntityEvent(_state.Id, @event);
            var ar = (dynamic)_root;
            ar.Apply((dynamic)entityEvent);
        }
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("_root", _root, typeof(IAggregateRoot));
            info.AddValue("_state", _state, typeof(TEntityState));
        }

        #endregion
    }
}
