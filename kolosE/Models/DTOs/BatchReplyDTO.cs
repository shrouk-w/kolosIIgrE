namespace kolosE.Models.DTOs;

public class BatchReplyDTO
{
    public int BatchId { get; set; }
    public int Quantity { get; set; }
    public DateTime SownDate { get; set; }
    public DateTime? ReadyDate { get; set; }
    public SpeciesReplyDTO Species { get; set; }
    public List<ResponsibleReplyDTO> Responsible { get; set; }
}