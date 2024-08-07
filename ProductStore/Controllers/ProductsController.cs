using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductStore.Infrastrucre.Mediator.Request;
using ProductStore.Infrastrucre.Repo;
using ProductStore.Infrastrucre.ValidateTable;
using ProductStore.Model;
using ProductStore.Model.Table;

namespace ProductStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductDbContext _context;
        private readonly IMediator _mediator;

        public ProductsController(ProductDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        // GET: ProductsController
        public ActionResult Index()
        {         
            var productSer = new ProductService(_context);
            var listProduct = productSer.GetList();
            return View(listProduct);
        }

        // GET: ProductsController/Details/5
        public async  Task<ActionResult> Details(Guid id)
        {
            var productQuery = new GetProductQuery();
            productQuery.Id = id;
            var product = await _mediator.Send(productQuery);
            return View(product);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddProductComand product)
        {
            var validator = new ProductValidator();
            var result = validator.Validate(product);
            if (result.IsValid)
            {
                await _mediator.Send(product);
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Error"] = result.Errors[0].ErrorMessage;
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
