using Application.Query.PatronProfile;
using Domain.DTOs.PatronProfileDTOs;

namespace Application.Handler.PatronProfileHandler;

public interface IPatronProfileQueryHandler
{
    Task<List<PatronProfile>> Handel(PatronProfileQuery query);
}