using Microsoft.AspNetCore.Mvc;
using SecilStore.ApplicationCore.Entities;
using SecilStore.Infrastructure.Data;

namespace SecilStore.Web.Controllers
{
    public class BaseController<T> : Controller where T : BaseEntity
    {
        public BaseRepository<T> BaseRepository { get; set; }

        public BaseController(BaseRepository<T> baseRepository)
        {
            this.BaseRepository = baseRepository;
        }
        public virtual IActionResult Index()
        {
            var list = this.BaseRepository.GetList();
            return View(list);
        }

        public virtual IActionResult Edit(string id)
        {
            var model = this.BaseRepository.GetById(id);
            return View(model);
        }

        [HttpPost]
        public virtual IActionResult Edit(string id, [Bind("Name,IsActive,Value,Type,ApplicationName,Id")] T model)
        {
            try
            {
                this.BaseRepository.Update(id, model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }

        public virtual IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,IsActive,Value,Type,ApplicationName")] T model)
        {
            this.BaseRepository.Create(model);
            return RedirectToAction(nameof(Index));
        }

        public virtual IActionResult Delete(string id)
        {
            try
            {
                this.BaseRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
