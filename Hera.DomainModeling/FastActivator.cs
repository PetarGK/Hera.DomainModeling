using Hera.DomainModeling.AggregareRoot;
using Hera.DomainModeling.Entity;
using Hera.DomainModeling.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hera.DomainModeling
{
    internal static class FastActivator
    {
        public static IAggregateRoot CreateAggregate()
        {
            return null;
        }
        public static IEntity CreateEntity(IAggregateRoot root, IIdentity entityId)
        {
            return null;
        }
    }
}
