using Microsoft.EntityFrameworkCore;
using Planner.Data.BaseRepository;
using Planner.Data.Context;
using Planner.Entities.Domain;
using Planner.RepositoryInterfaces.ObjectInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Planner.Data.Repository
{
    public class PublicationRepository : BaseRepository<Publication>, IPublicationRepository
    {
        public PublicationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Publication> GetById(string publicationId) => await Query
            .FirstOrDefaultAsync(s => s.PublicationId == publicationId);

        public void AddUpdate(Publication publication) => InsertOrUpdateGraph(publication);



        public async Task<IEnumerable<Publication>> GetAllPublications() =>
            await Query.Include(s => s.PublicationUsers)
                .ThenInclude(c => c.User).ToListAsync();
    }
}
