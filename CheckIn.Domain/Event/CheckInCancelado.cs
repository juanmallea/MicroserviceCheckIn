
using ShareKernel.Core;
using ShareKernel.ValueObjects;
using System;

namespace CheckIn.Domain.Event
{
    public record CheckInCancelado : DomainEvent
    {
        public Guid IdCheckIn { get; }
        public Guid IdPasajero { get; }
        public NumeroAsientoValue NumeroAsiento { get; }

        public CheckInCancelado(Guid idCheckIn, Guid idPasajero) : base(DateTime.Now)
        {
            IdCheckIn = idCheckIn;
            IdPasajero = idPasajero;
        }
    }
}

