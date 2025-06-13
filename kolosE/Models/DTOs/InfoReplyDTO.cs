namespace kolosE.Models.DTOs;

public class InfoReplyDTO
{
    public int NurseryId { get; set; }
    public string Name { get; set; }
    public DateTime EstablishedDate { get; set; }
    public List<BatchReplyDTO> Batches { get; set; }
}