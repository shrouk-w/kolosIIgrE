using kolosE.Models.DTOs;

namespace kolosE.Services;

public interface INurseriesService
{
    Task<InfoReplyDTO> GetBatchesForIdAsync(int id, CancellationToken token);
    Task InsertNewBatchAsync(BatchRequestDTO request, CancellationToken token);
}