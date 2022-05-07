using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.Dto.CheckIn
{
    public class CheckInDto
    {
        public Guid IdCheckIn { get; set; }
        public Guid IdPasajero { get; set; }
        public int NumeroAsiento { get; set; }
        public ICollection<DetalleCheckInDto> Detalle { get; set; }

        public CheckInDto()
        {
            Detalle = new List<DetalleCheckInDto>();
        }
    }
}
