using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SecilStore.ApplicationCore.Entities;
using SecilStore.Infrastructure.Data;
using SecilStore.Web.Models;
using System.Diagnostics;

namespace SecilStore.Web.Controllers
{
    public class HomeController : BaseController<Configuration>
    {
        public HomeController(ConfigurationRepository configurationRepository) : base(configurationRepository)
        {
        }
    }
}
