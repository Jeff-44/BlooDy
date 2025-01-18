using BlooDyWeb.Models.DistributionModule;
using BlooDyWeb.Services.DistributionModule;
using BlooDyWeb.Services.IServices.IDistributionModule;
using Microsoft.AspNetCore.Mvc;

namespace BlooDyWeb.Controllers
{
    public class DocumentController : Controller
    {
        private readonly IDocumentService _documentService;
        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }
        public IActionResult Index()
        {
            IEnumerable<Document> documents = Enumerable.Empty<Document>();
            try 
            {
                documents = _documentService.RechercherEntites();

            } catch(Exception ex) { }
            return View(documents);
        }

        public IActionResult Details(long id)
        {
            return View();
        }
    }
}
