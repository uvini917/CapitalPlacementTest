namespace CandidateApplication.Services
{
    public interface ICandidateService
    {
        Task<Candidate> CreateCandidateAsync(CandidateDTO candidateDto);
    }

}
