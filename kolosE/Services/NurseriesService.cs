using kolokwiumA.Exceptions;
using kolosE.DAL;
using kolosE.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace kolosE.Services;

public class NurseriesService : INurseriesService
{
    private readonly BatchDbContext _DbContext;
    
    public NurseriesService(BatchDbContext dbContext)
    {
        _DbContext = dbContext;
    }

    public async Task<InfoReplyDTO> GetBatchesForIdAsync(int id, CancellationToken token)
    {
        if (id <= 0)
        {
            throw new BadRequestException("Id must be greater than 0");
        }
        
        var nursery = await _DbContext.Nurseries.FindAsync(id, token);
        
        if (nursery == null)
            throw new NotFoundException("Nursery not found");

        var response = new InfoReplyDTO
        {
            NurseryId = nursery.NurseryId,
            Name = nursery.Name,
            EstablishedDate = nursery.EstablishedDate,
        };

        var batches = await _DbContext.SeedlingBatches.Where(n => n.NurseryId == id).ToListAsync(token);

        response.Batches = new List<BatchReplyDTO>();
        
        foreach (var batch in batches)
        {
            var toAdd = new BatchReplyDTO()
            {
                BatchId = batch.BatchId,
                Quantity = batch.Quantity,
                ReadyDate = batch.ReadyDate,
                SownDate = batch.SownDate,
                Species = new SpeciesReplyDTO()
                {
                    LatinName = await _DbContext.TreeSpecies.Where(p=>batch.SpeciesId == p.SpeciesId).Select(p=>p.LatinName).FirstOrDefaultAsync(token),
                    GrowthTimeInYears = await _DbContext.TreeSpecies.Where(p=>batch.SpeciesId == p.SpeciesId).Select(p=>p.GrowthTimeInYears).FirstOrDefaultAsync(token),
                },
                Responsible = new List<ResponsibleReplyDTO>()
                
            };
            
            var responsibles = await _DbContext.Responsibles.Where(n => n.BatchId == batch.BatchId).ToListAsync(token);

            foreach (var res in responsibles)
            {
                var responsible = new ResponsibleReplyDTO()
                {
                    Role = res.Role,
                    FirstName = await _DbContext.Employees.Where(e => e.EmployeeId == res.EmployeeId).Select(e => e.FirstName).FirstOrDefaultAsync(token),
                    LastName = await _DbContext.Employees.Where(e => e.EmployeeId == res.EmployeeId).Select(e => e.LastName).FirstOrDefaultAsync(token),
                };
                
                toAdd.Responsible.Add(responsible);

            }
            
            response.Batches.Add(toAdd);

        }
        
        return response;

    }
}