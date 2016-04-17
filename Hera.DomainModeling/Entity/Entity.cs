using Hera.DomainModeling.AggregareRoot;
using Hera.DomainModeling.DomainEvent;
using Hera.DomainModeling.Identity;

namespace Hera.DomainModeling.Entity
{
    public abstract class Entity<TEntityState> : IEntity 
        where TEntityState : IEntityState, new()
    {
        #region Fields

        private IAggregateRoot _root;
        private TEntityState _state;

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

        #region Constructors

        protected Entity(IAggregateRoot root, IIdentity id)
        {
            _root = root;

            _state = new TEntityState();
            _state.Id = id;

            _root.RegisterEntity(id, this);
        }

        #endregion

        #region Methods

        protected void Apply(IDomainEvent @event)
        {
            var entityEvent = new EntityEvent(_state.Id, @event);
            var ar = (dynamic)_root;
            ar.Apply((dynamic)entityEvent);
        }

        #endregion
    }
}
