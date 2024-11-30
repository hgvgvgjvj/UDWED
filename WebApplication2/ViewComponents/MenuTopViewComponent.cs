

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.ViewComponents
{
    public class MenuTopViewComponent : ViewComponent
    {
        private readonly PtwebContext _context;

        public MenuTopViewComponent(PtwebContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TbMenu.Where(m => (bool)m.IsActive).
                   OrderBy(mbox => mbox.Position).ToList();
            return await Task.FromResult<IViewComponentResult>(View(items));
        }
    }
}