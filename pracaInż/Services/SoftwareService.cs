using ErrorOr;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using pracaInż.Data;
using pracaInż.Models.DTO.SoftwareDTOs;
using pracaInż.Models.Entities;
using pracaInż.Validators;

namespace pracaInż.Services
{
    public interface ISoftwareService
    {
        Task<ErrorOr<Created>> AddNewSoftwareInfo(AddSoftwareDTO softwareDTO);
        Task<ErrorOr<Updated>> UpdateSoftwareInfo(SoftwareDTO softwareDTO);
        Task<ErrorOr<Deleted>> DeleteSoftwareInfo(int id);
        Task<ErrorOr<SoftwareDTO>> GetSoftwareInfo(int id);
        Task<ErrorOr<List<SoftwareDTO>>> GetAllSoftwareInfo();
    }
    public class SoftwareService : ISoftwareService
    {
        private readonly AppDbcontext _context;

        public SoftwareService(AppDbcontext context)
        {
            _context = context;
        }

        public async Task<ErrorOr<Created>> AddNewSoftwareInfo(AddSoftwareDTO softwareDTO)
        {
            ErrorOr<Created> result;
            AddSoftwareValidator validator = new AddSoftwareValidator();
            ValidationResult validationResult = validator.Validate(softwareDTO);
            if (validationResult.IsValid)
            {
                Software software = new Software(softwareDTO);
                _context.Software.Add(software);
                await _context.SaveChangesAsync();
                result = Result.Created;
                return result;
            }

            result = Error.Validation(description: validationResult.Errors[0].ErrorMessage);
            return result;

        }

        public async Task<ErrorOr<Deleted>> DeleteSoftwareInfo(int id)
        {
            ErrorOr<Deleted> result;

            var software = await _context.Software.FindAsync(id);
            if(software == null)
            {
                result = Error.NotFound(description: "Wystąpił błąd podczas usuwania! Spróbuj ponownie później");
                return result;
            }

            _context.Software.Remove(software);
            await _context.SaveChangesAsync();

            result = Result.Deleted;
            return result;
        }

        public async Task<ErrorOr<List<SoftwareDTO>>> GetAllSoftwareInfo()
        {
            ErrorOr<List<SoftwareDTO>> result;

            var rawSoftwareList = await _context.Software.ToListAsync();
            if(rawSoftwareList.Count == 0)
            {
                result = Error.NotFound(description: "Błąd podczas ładowania elementów");
                return result;
            }

            List<SoftwareDTO> softwareDTOs = new List<SoftwareDTO>();
            rawSoftwareList.ForEach(element => softwareDTOs.Add(new SoftwareDTO(element)));

            result = softwareDTOs;
            return result;
        }

        public async Task<ErrorOr<SoftwareDTO>> GetSoftwareInfo(int id)
        {
            ErrorOr<SoftwareDTO> result;
            var sofware = await _context.Software.FindAsync(id);
            if(sofware == null)
            {
                result = Error.NotFound(description: "Nie można wczytać wybranego oprogramowania");
                return result;
            }

            result = new SoftwareDTO(sofware);
            return result;
        }

        public async Task<ErrorOr<Updated>> UpdateSoftwareInfo(SoftwareDTO softwareDTO)
        {
            ErrorOr<Updated> result;
            SoftwareValidator validator = new SoftwareValidator();
            ValidationResult validationResult = validator.Validate(softwareDTO);

            if (validationResult.IsValid)
            {
                Software software = new Software(softwareDTO);
                _context.Software.Update(software);
                await _context.SaveChangesAsync();

                result = Result.Updated;
                return result;
            }

            result = Error.Validation(description: validationResult.Errors[0].ErrorMessage);
            return result;
        }
    }
}
