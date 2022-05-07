using CheckIn.Domain.Model.ValueObjects;
using CheckIn.Domain.ValueObjects;
using ShareKernel.Core;
using ShareKernel.ValueObjects;
using System;

namespace CheckIn.Domain.Model.CheckIns
{
    public class DetalleCheckIn : Entity<Guid>
    {
        //TODO: Crear value objects para las propiedades
        public Guid IdCheckIn { get; private set; }
        public Guid IdPasajero { get; private set; }
        public NumeroAsientoValue NumeroAsiento { get; private set; }


        internal DetalleCheckIn(Guid idCheckIn, Guid idPasajero, NumeroAsientoValue numeroAsiento)
        {
            Id = Guid.NewGuid();
            IdCheckIn = idCheckIn;
            IdPasajero = idPasajero;
            NumeroAsiento = numeroAsiento;
        }

        private DetalleCheckIn() { }

        internal void ModificarCheckIn(Guid idPasajero, NumeroAsientoValue numeroAsiento)
        {
            IdPasajero = idPasajero;
            NumeroAsiento = numeroAsiento;
        }
    }
}
