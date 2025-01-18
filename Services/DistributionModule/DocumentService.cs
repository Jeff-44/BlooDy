using BlooDyWeb.Models.DistributionModule;
using BlooDyWeb.Repository.IRepository.IDistributionModule;
using BlooDyWeb.Services.IServices.IDistributionModule;

namespace BlooDyWeb.Services.DistributionModule
{
    public class DocumentService : GenericService<Document>, IDocumentService
    {
        public DocumentService(IDocumentRepository repository) : base(repository)
        {
            
        }
    }
}
