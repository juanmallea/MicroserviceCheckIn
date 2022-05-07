using CheckIn.Domain.Model.CheckIns;

namespace CheckIn.Domain.Factories
{
    public interface ICheckInFactory
    {
        Check Create(string IdCheckIn);
    }
}
