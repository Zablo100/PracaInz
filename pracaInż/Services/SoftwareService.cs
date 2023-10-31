using ErrorOr;
using pracaInż.Models.Entities;

namespace pracaInż.Services
{
    public interface ISoftwareService
    {
        Task<ErrorOr<Created>> AddNewSoftwareInfo();
        Task<ErrorOr<Updated>> UpdateSoftwareInfo();
        Task<ErrorOr<Deleted>> DeleteSoftwareInfo();
        Task<ErrorOr<Software>> GetSoftwareInfo();
    }
    public class SoftwareService
    {
    }
}
