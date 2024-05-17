using Microsoft.Azure.Cosmos;

namespace CandidateApplication.Services
{

    public class CandidateService : ICandidateService
    {
        private readonly CosmosClient _cosmosClient;
        private readonly Container _container;

        public CandidateService(CosmosClient cosmosClient)
        {
            _cosmosClient = cosmosClient;
            _container = _cosmosClient.GetContainer("CandidateApplication", "CandidateContainer");
        }

        public async Task<Candidate> CreateCandidateAsync(CandidateDTO candidateDto)
        {
            var candidate = new Candidate
            {
                CandidateID = Guid.NewGuid().ToString(),
                PersonalInformation = ConvertToPersonalInformation(candidateDto.PersonalInformation),
                Answers = candidateDto.Answers
            };

            await _container.CreateItemAsync(candidate, new PartitionKey(candidate.ProgramID));
            return candidate;
        }

        private PersonalInformation ConvertToPersonalInformation(PersonalInformationDTO dto)
        {
            return new PersonalInformation
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                Nationality = dto.Nationality,
                CurrentResidence = dto.CurrentResidence,
                IDNumber = dto.IDNumber,
                DateOfBirth = dto.DateOfBirth,
                Gender = dto.Gender
            };
        }
    }

}
