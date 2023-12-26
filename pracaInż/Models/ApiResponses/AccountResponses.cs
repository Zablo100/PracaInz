using pracaInż.Models.DTO.Employees;

namespace pracaInż.Models.ApiResponses
{
    public record LoginResponse(EmployeeDTO User, string Token);
    public record RegisterResponse(string User, string Token);

}
