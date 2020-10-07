using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Onion.Core.BusinessRules;
using Onion.Core.Interfaces.Repository;
using Onion.Core.Interfaces.Services;
using Onion.Core.Models;
using Onion.CustomAttributes;

namespace Onion.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IProductDetailsRepository productDetailsRepository;
        private readonly IProductService _productService; 

        public ProductController(
            IProductRepository productRepository,
            IProductService productService)
        {
            this.productRepository = productRepository;
            _productService = productService; 
        }

        [HttpGet]
        [Log(LogEnum.Info, "Get product details from product controller")]
        public IEnumerable<ProductDetails> GetAllProductDetails()
        {
            var productDetails = _productService.GetProductsDetails();

            return productDetails;
        }



        // GET: Product
        [Log(LogEnum.Info, "Index Text")]
        public IActionResult Index()
        {
            var products = this.productRepository.SelectAll();

            return View(products);
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
        [Log(LogEnum.Info, "Create Product")]
        public IActionResult Create()
        {
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
