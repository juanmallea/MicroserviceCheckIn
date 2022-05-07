using CheckIn.Domain.Model.ValueObjects;
using ShareKernel.Core;
using ShareKernel.ValueObjects;
using System;

namespace CheckIn.Domain.Event
{
    public record ItemCheckInAgregado : DomainEvent
    {
        public Guid IdCheckIn { get; }
        public Guid IdPasajero { get; }
        public NumeroAsientoValue NumeroAsiento { get; }

        public ItemCheckInAgregado(Guid idCheckIn, Guid idPasajero, NumeroAsientoValue numeroAsiento) : base(DateTime.Now)
        {
            IdCheckIn = idCheckIn;
            IdPasajero = idPasajero;
            NumeroAsiento = numeroAsiento;
        }
    }
}

