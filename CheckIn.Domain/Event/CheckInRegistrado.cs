using ShareKernel.Core;
using ShareKernel.ValueObjects;
using System;

namespace CheckIn.Domain.Event
{
    public record CheckInRegistrado : DomainEvent
    {
        public Guid IdCheckIn { get; }
        public Guid IdPasajero { get; }
        public NumeroAsientoValue NumeroAsiento { get; }

        public CheckInRegistrado(Guid idCheckIn, Guid idPasajero, NumeroAsientoValue numeroAsiento) : base(DateTime.Now)
        {
            IdCheckIn = idCheckIn;
            IdPasajero = idPasajero;
            NumeroAsiento = numeroAsiento;
        }
    }
}

