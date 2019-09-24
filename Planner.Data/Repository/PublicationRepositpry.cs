using Planner.Data.BaseRepository;
using Planner.Entities.Domain;
using Planner.RepositoryInterfaces.ObjectInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Planner.Data.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Planner.Data.Repository
{
    public class PublicationRepositpry : BaseRepository<Publication>, IPublicationRepositpry
    {
        public PublicationRepositpry(AppDbContext _context) : base(_context)
        {
        }

        public Publication GetById(String publicationId)
        {
            return Query.FirstOrDefault(s => s.PublicationId == publicationId);
        }

        public void AddUpdate(Publication publication)
        {
            InsertOrUpdateGraph(publication);
        }


        public IEnumerable<Publication> GetAllPublications()
        {
            return Query.Include(s => s.PublicationUsers)
                                .ThenInclude(c => c.User).ToList();
        }
    }
}
