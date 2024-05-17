namespace CandidateApplication.Services
{
    public interface IQuestionService
    {
        Task<IEnumerable<Question>> GetQuestionsByTypeAsync(string type);
        Task CreateQuestionAsync(Question question);
        Task UpdateQuestionAsync(string questionId, Question question);
    }
}
