using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArt.Domain.Abstractions
{
    public abstract class Entity 
    {
        private readonly List<IDomaintEvent> _domainEvents = new();

        protected Entity(Guid id) 
        {
            Id=id;
        }
        public Guid Id { get; set; }

        public IReadOnlyList<IDomaintEvent>GetDomaintEvents()
        {
            return _domainEvents.ToList();
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        protected void RaiseDomainEvent(IDomaintEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
