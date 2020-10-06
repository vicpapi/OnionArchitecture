using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Onion.Core.Interfaces.Repository;
using Onion.Core.Interfaces.Services;
using Onion.Core.Models;
using Onion.Helpers;

namespace Onion.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IProductDetailsRepository productDetailsRepository;
        private readonly IProductService _productService;
        private readonly ILoggingRepository _loggerRepository;

        public ProductController(
            IProductRepository productRepository,
            IProductService productService,
            ILoggingRepository loggerRepository)
        {
            this.productRepository = productRepository;
            _productService = productService;
            _loggerRepository = loggerRepository;
        }

        [HttpGet]
        public IEnumerable<ProductDetails> GetAllProductDetails()
        {
            _loggerRepository.LogInfo("Get product details from product controller");

            var productDetails = _productService.GetProductsDetails();

            return productDetails;
        }



        // GET: Product
        public IActionResult Index()
        {
            //try
            //{
                var cero = 0;
                var error = 5 / cero;

            //}
            //catch (Exception exp)
            //{
            //    Logger.SaveErrorLog(exp);
            //}

            return View(this.productRepository.SelectAll());
        }

        // GET: Product/Details/5
        public IActionResult Details(int id)
        {
            var product = this.productRepository.Single(s => s.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            _loggerRepository.LogInfo("Test Get");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ProductName,ProductId")] Product product)
        {
            if (ModelState.IsValid)
            {

            }
            this.productRepository.Create(product);

            return View(product);
        }

        // GET: Product/Edit/5
        public IActionResult Edit(int id)
        {
            var product = this.productRepository.Select(s => s.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ProductName,ProductId")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
    }
}
