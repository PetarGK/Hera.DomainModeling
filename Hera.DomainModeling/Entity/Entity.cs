using Hera.DomainModeling.AggregareRoot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hera.DomainModeling.Entity
{
    public abstract class Entity<TAggregateRoot, TEntityState> : IEntity 
        where TAggregateRoot: IAggregateRoot
        where TEntityState : EntityState, new()
    {
        #region Fields

        private TAggregateRoot _root;
        private TEntityState _state;

        #endregion

        #region Properties

        public TEntityState State
        {
            get { return _state; }
        }
        public TAggregateRoot Root
        {
            get { return _root; }
        }
        IEntityState IHaveState<IEntityState>.State
        {
            get { return _state; }
        }
        IAggregateRoot IHaveRoot<IAggregateRoot>.Root
        {
            get { return _root; }
        }

        #endregion

        #region Constructors

        protected Entity(TAggregateRoot root, Guid id)
        {
            _root = root;

            _state = new TEntityState();
            _state.Id = id;

            _root.RegisterEntity(id, this);
        }

        #endregion

        #region Methods

        protected void Apply(IEvent @event)
        {
            var entityEvent = new EntityEvent(_state.Id, @event);
            var ar = (dynamic)_root;
            ar.Apply((dynamic)entityEvent);
        }

        #endregion
    }
}
