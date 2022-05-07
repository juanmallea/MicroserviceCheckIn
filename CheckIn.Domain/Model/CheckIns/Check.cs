using CheckIn.Domain.Event;
using ShareKernel.Core;
using ShareKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CheckIn.Domain.Model.CheckIns
{
    public class Check : AggregateRoot<Guid>
    {
        public Guid IdCheckIn { get; private set; }
        public Guid IdPasajero { get; private set; }
        public NumeroAsientoValue NumeroAsiento { get; private set; }

        private readonly ICollection<DetalleCheckIn> _detalle;

        public IReadOnlyCollection<DetalleCheckIn> Detalle
        {
            get
            {
                return new ReadOnlyCollection<DetalleCheckIn>(_detalle.ToList());
            }
        }

        private Check() { }

        internal Check(Guid idPasajero, NumeroAsientoValue numeroAsiento)
        {
            IdCheckIn = Guid.NewGuid();
            IdPasajero = idPasajero;
            NumeroAsiento = numeroAsiento;
            _detalle = new List<DetalleCheckIn>();
        }

        public void AgregarItem(Guid idCheckIn, Guid idPasajero, NumeroAsientoValue numeroAsiento)
        {
            var detalleCheckIn = _detalle.FirstOrDefault(x => x.IdCheckIn == idCheckIn);
            if (detalleCheckIn is null)
            {
                detalleCheckIn = new DetalleCheckIn(idCheckIn, idPasajero, numeroAsiento);
                _detalle.Add(detalleCheckIn);
            }
            else
            {
                detalleCheckIn.ModificarCheckIn(idPasajero, numeroAsiento);
            }

            AddDomainEvent(new ItemCheckInAgregado(idCheckIn, idPasajero, numeroAsiento));
        }

        public void ConsolidarCheckIn()
        {
            var evento = new CheckInRegistrado(IdCheckIn, IdPasajero, NumeroAsiento);
            AddDomainEvent(evento);
        }
    }
}
