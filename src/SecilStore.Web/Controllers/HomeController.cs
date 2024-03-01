using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SecilStore.ApplicationCore.Entities;
using SecilStore.ApplicationCore.Interfaces;
using SecilStore.Web.Models;
using System.Diagnostics;

namespace SecilStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<Configuration> _configurationRepository;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IRepository<Configuration> configurationRepository, IMapper mapper)
        {
            _logger = logger;
            _configurationRepository = configurationRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _configurationRepository.GetAllAsync();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddConfiguration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddConfiguration(ConfigurationViewModel model)
        {
            var vm = _mapper.Map<Configuration>(model);
            await _configurationRepository.AddAsync(vm);
            return View();
        }

        public async Task<IActionResult> DeleteConfiguration(int id)
        {
            await _configurationRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateConfiguration(int id)
        {
            var model =  await _configurationRepository.GetByIdAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateConfiguration(UpdateConfigurationViewModel model)
        {
            var vm = _mapper.Map<Configuration>(model);
            await _configurationRepository.UpdateAsync(vm);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
