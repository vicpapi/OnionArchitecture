using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Onion.Core.Interfaces.Repository;
using Onion.Core.Models;

namespace Onion.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IProductDetailsRepository productDetailsRepository;
        private readonly ILog4NetRepository _loggerRepository;

        public ProductController(IProductRepository productRepository, ILog4NetRepository loggerRepository)
        {
            this.productRepository = productRepository; 
            _loggerRepository = loggerRepository;
        }

        [HttpGet]
        public List<ProductDetails> Get()
        {
            _loggerRepository.LogInfo("Test Get");
            List<ProductDetails> productDetails = new List<ProductDetails>();
            var prodcutList = productRepository.GetProduct().ToList();
            foreach (var product in prodcutList)
            {
                var productDetailList = productDetailsRepository.GetProductDetail(product.ProductId);
                ProductDetails details = new ProductDetails
                {
                    ProductId = product.ProductId,
                    Price = productDetailList.Price,
                    StockAvailable = productDetailList.StockAvailable,
                };
                productDetails.Add(details);
            }
            return productDetails;
        }



        // GET: Product
        public IActionResult Index()
        {
            _loggerRepository.LogInfo("Test Index");
            return View(this.productRepository.SelectAll());
        }

        // GET: Product/Details/5
        public IActionResult Details(int id)
        {
            var product = this.productRepository.Single(s=> s.ProductId == id);

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
            var product = this.productRepository.Select(s=> s.ProductId == id);
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
