public class EmailQueueDto
{
    public int EmailQueueId { get; set; }
    public object? XmlData { get; set; }
    public string? XslName { get; set; }
    public string? IsoLanguage { get; set; }
    public string? Email { get; set; }
    public string? SendAt { get; set; }
    public int CompanyId { get; set; }
    public bool Sent { get; set; }
    public int Attempts { get; set; }
    public string? Subject { get; set; }
    public string? Message { get; set; }
    public string? Created_On { get; set; }
    public string? Created_By { get; set; }
    public string? Modified_On { get; set; }
    public string? Modified_By { get; set; }
}