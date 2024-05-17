using Newtonsoft.Json;
using System.Collections.Generic;

public class Question
{
    [JsonProperty("questionID")]
    public string QuestionID { get; set; }

    [JsonProperty("programID")]
    public string ProgramID { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("question")]
    public string QuestionText { get; set; }

    [JsonProperty("choices")]
    public List<string> Choices { get; set; }

    [JsonProperty("enableOtherOption")]
    public bool EnableOtherOption { get; set; }

    [JsonProperty("maxChoicesAllowed")]
    public int MaxChoicesAllowed { get; set; }
}

public class QuestionDTO
{
    public string QuestionID { get; set; }
    public string ProgramID { get; set; }
    public string Type { get; set; }
    public string QuestionText { get; set; }
    public List<string> Choices { get; set; }
    public bool EnableOtherOption { get; set; }
    public int MaxChoicesAllowed { get; set; }
}
