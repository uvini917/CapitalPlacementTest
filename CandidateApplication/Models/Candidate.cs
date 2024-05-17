using Newtonsoft.Json;
using System.Collections.Generic;

public class Candidate
{
    [JsonProperty("candidateId")]
    public string CandidateID { get; set; }

    [JsonProperty("personalInformation")]
    public PersonalInformation PersonalInformation { get; set; }

    [JsonProperty("answers")]
    public Dictionary<string, string> Answers { get; set; }
}

public class CandidateDTO
{
    public string CandidateID { get; set; }
    public PersonalInformationDTO PersonalInformation { get; set; }
    public Dictionary<string, string> Answers { get; set; }
}

public class PersonalInformation
{
    [JsonProperty("firstName")]
    public string FirstName { get; set; }

    [JsonProperty("lastName")]
    public string LastName { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("phone")]
    public string Phone { get; set; }

    [JsonProperty("nationality")]
    public string Nationality { get; set; }

    [JsonProperty("currentResidence")]
    public string CurrentResidence { get; set; }

    [JsonProperty("idNumber")]
    public string IDNumber { get; set; }

    [JsonProperty("dateOfBirth")]
    public string DateOfBirth { get; set; }

    [JsonProperty("gender")]
    public string Gender { get; set; }
}

public class PersonalInformationDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Nationality { get; set; }
    public string CurrentResidence { get; set; }
    public string IDNumber { get; set; }
    public string DateOfBirth { get; set; }
    public string Gender { get; set; }
}
