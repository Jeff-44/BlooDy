using BlooDyWeb.Data;
using BlooDyWeb.Models.DistributionModule;
using BlooDyWeb.Repository.IRepository.IDistributionModule;

namespace BlooDyWeb.Repository.DistributionModule
{
    public class DocumentRepository : GenericRepository<Document>, IDocumentRepository
    {
        public DocumentRepository(BlooDyContext context) : base(context)
        {

        }
    }
}
