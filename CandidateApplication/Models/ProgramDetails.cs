using Newtonsoft.Json;
using System.Collections.Generic;

public class ProgramDetails
{
    [JsonProperty("programID")]
    public string ProgramID { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("additionalQuestions")]
    public List<string> AdditionalQuestions { get; set; }
}

public class ProgramDTO
{
    public string ProgramID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<string> AdditionalQuestions { get; set; }
}
