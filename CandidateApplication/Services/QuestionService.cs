using Microsoft.Azure.Cosmos;

namespace CandidateApplication.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly CosmosClient _cosmosClient;
        private readonly Container _container;


        public QuestionService(CosmosClient cosmosClient)
        {
            _cosmosClient = cosmosClient;
            _container = _cosmosClient.GetContainer("CanditateApplication", "QuestionsContainer");
        }

        public async Task<IEnumerable<Question>> GetQuestionsByTypeAsync(string type)
        {
            var query = _container.GetItemQueryIterator<Question>(new QueryDefinition($"SELECT * FROM c WHERE c.Type = @type").WithParameter("@type", type));
            var results = new List<Question>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }

        public async Task CreateQuestionAsync(Question question)
        {
            await _container.CreateItemAsync(question, new PartitionKey(question.QuestionID));
        }

        public async Task UpdateQuestionAsync(string questionID, Question question)
        {
            await _container.UpsertItemAsync(question, new PartitionKey(questionID));
        }

    }


}
