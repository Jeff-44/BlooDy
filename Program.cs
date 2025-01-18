
using BlooDyWeb.Data;
using BlooDyWeb.Repository;
using BlooDyWeb.Repository.DistributionModule;
using BlooDyWeb.Repository.IRepository;
using BlooDyWeb.Repository.IRepository.IDistributionModule;
using BlooDyWeb.Repository.IRepository.ITransfusionModule;
using BlooDyWeb.Repository.TransfusionModule;
using BlooDyWeb.Services;
using BlooDyWeb.Services.DistributionModule;
using BlooDyWeb.Services.IServices;
using BlooDyWeb.Services.IServices.IDistributionModule;
using BlooDyWeb.Services.IServices.ITransfusionModule;
using BlooDyWeb.Services.TransfusionModule;
using Microsoft.EntityFrameworkCore;
using BlooDyWeb.Data.Security;
using Microsoft.AspNetCore.Identity;
using BlooDyWeb.Models.Security;
using Microsoft.AspNetCore.Authorization;
using BlooDyWeb.CustomAttribute;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options => 
{
    options.Filters.Add<SessionCheckAttribute>();
});
builder.Services.AddDbContext<BlooDyContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddDbContext<AuthContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services
       .AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
       .AddRoles<IdentityRole>()
       .AddEntityFrameworkStores<AuthContext>()
       .AddDefaultTokenProviders();

builder.Services.AddRazorPages();


builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
});

//HANDLE SESSION
builder.Services.AddSession(options => 
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.LogoutPath = "/Identity/Account/Logout";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});

builder.Services.AddScoped<IDonateurRepository, DonateurRepository>();
builder.Services.AddScoped<IDonateurService, DonateurService>();
builder.Services.AddScoped<ICentreRepository, CentreRepository>();
builder.Services.AddScoped<ICentreService, CentreService>();
builder.Services.AddScoped<IExamenMedicalRepository, ExamenMedicalRepository>();
builder.Services.AddScoped<IExamenMedicalService, ExamenMedicalService>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped<ICollecteRepository, CollecteRepository>();
builder.Services.AddScoped<ICollecteService, CollecteService>();
builder.Services.AddScoped<IDonRepository, DonRepository>();
builder.Services.AddScoped<IDonService, DonService>();
builder.Services.AddScoped<IComposanteRepository, ComposanteRepository>();
builder.Services.AddScoped<IComposanteService, ComposanteService>();
builder.Services.AddScoped<ITypeComposanteRepository, TypeComposanteRepository>();
builder.Services.AddScoped<ITypeComposanteService, TypeComposanteService>();
//DISTRIBUTION MODULE
builder.Services.AddScoped<IDistributionRepository, DistributionRepository>();
builder.Services.AddScoped<IDistributionService, DistributionService>();
builder.Services.AddScoped<IDemandeRepository, DemandeRepository>();
builder.Services.AddScoped<IDemandeService, DemandeService>();

builder.Services.AddScoped<IChauffeurRepository, ChauffeurRepository>();
builder.Services.AddScoped<IChauffeurService, ChauffeurService>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped<IDocumentService, DocumentService>();

builder.Services.AddScoped<IInstitutionSanteRepository, InstitutionSanteRepository>();
builder.Services.AddScoped<IInstitutionSanteService, InstitutionSanteService>();

builder.Services.AddScoped<ITransportRepository, TransportRepository>();
builder.Services.AddScoped<ITransportService, TransportService>();

//TRANSFUSION MODULE
builder.Services.AddScoped<ITransfusionRepository, TransfusionRepository>();
builder.Services.AddScoped<ITransfusionService, TransfusionService>();

builder.Services.AddScoped<IBeneficiaireRepository, BeneficiaireRepository>();
builder.Services.AddScoped<IBeneficiaireService, BeneficiaireService>();

builder.Services.AddScoped<IMedecinRepository, MedecinRepository>();
builder.Services.AddScoped<IMedecinService, MedecinService>();

// HANDLE AUTHENTICATION / AUTHORIZATION

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.UseSession();

app.MapControllerRoute(
    name: "dossiers",
    pattern: "{controller=Dossier}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "donateurs",
    pattern: "{controller=Donateur}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "collectes",
    pattern: "{controller=Collecte}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "dons",
    pattern: "{controller=Don}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "typecomposantes",
    pattern: "{controller=TypeComposante}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "composantes",
    pattern: "{controller=Composante}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "distributions",
    pattern: "{controller=Distribution}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "demandes",
    pattern: "{controller=Demande}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "chauffeurs",
    pattern: "{controller=Chauffeur}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "institutions",
    pattern: "{controller=Institution}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "transports",
    pattern: "{controller=Transport}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "documents",
    pattern: "{controller=Document}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "beneficiaires",
    pattern: "{controller=Beneficiaire}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "medecins",
    pattern: "{controller=Medecin}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "transfusions",
    pattern: "{controller=Transfusion}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "users",
    pattern: "{controller=User}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "roles",
    pattern: "{controller=Role}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
