using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class BlogsController : Controller
    {
        BlogContext blogContext;
        public BlogsController(BlogContext blogContext)
        {
            this.blogContext = blogContext;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await blogContext.Blogs
                .OrderByDescending(b => b.Id)
                .ToListAsync();

            return View(blogs);
            // This will display Index.cshtml
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogDTO blogDTO)
        {
            if (!ModelState.IsValid)
                return View(blogDTO);
            Blog blog = new Blog()
            {
                Title = blogDTO.Title,
                Author = blogDTO.Author,
                Category = blogDTO.Category,
                Excerpt = blogDTO.Excerpt,
                CreatedDate = DateTime.Now
            };
            blogContext.Blogs.Add(blog);
            blogContext.SaveChanges();
            return RedirectToAction("Index", "Blogs");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Blog blog = await blogContext.Blogs.FindAsync(id);
            if (blog == null) return RedirectToAction("Index", "Blogs");
            BlogDTO blogDTO = new BlogDTO()
            {
                Title = blog.Title,
                Author = blog.Author,
                Excerpt = blog.Excerpt,
                Category = blog.Category
            };
            ViewData["BlogId"] = blog.Id;
            ViewData["CreatedDate"] = blog.CreatedDate.ToString("MM/dd/yyyy");
            return View(blogDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, BlogDTO blogDTO)
        {
            Blog blog = blogContext.Blogs.Find(id);
            if (blog == null) return RedirectToAction("Index", "Blogs");
            if (!ModelState.IsValid)
            {
                ViewData["BlogId"] = blog.Id;
                ViewData["CreatedDate"] = blog.CreatedDate.ToString("MM/dd/yyyy");
                return View(blogDTO);
            }
            blog.Title = blogDTO.Title;
            blog.Author = blogDTO.Author;
            blog.Category = blogDTO.Category;
            blog.Excerpt = blogDTO.Excerpt;
            
            blogContext.SaveChanges();
            return RedirectToAction("Index", "Blogs");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Blog blog = blogContext.Blogs.Find(id);
            if (blog == null) return RedirectToAction("Index", "Blogs");

            blogContext.Blogs.Remove(blog);
            blogContext.SaveChanges();
            return RedirectToAction("Index", "Blogs");
        }

    }
}
