using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckIn.Application.Dto.CheckIn
{
    public class DetalleCheckInDto
    {
        public Guid IdCheckIn { get; set; }
        public Guid IdPasajero { get; set; }
        public int NumeroAsiento { get; set; }

    }
}
