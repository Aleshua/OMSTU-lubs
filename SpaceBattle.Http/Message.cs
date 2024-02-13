namespace SpaceBattle.Http;

[DataContract(Name = "Message")]
public class Message {
    [DataMember(Name = "SimpleProperty", Order = 1)]
    public required string GameID { get; set; }

    [DataMember(Name="CommandName")]
    public required string CommandName { get; set; }

    [DataMember(Name="args")]
    public Dictionary<string, string> args { get; set; } = new Dictionary<string, string>();
}
