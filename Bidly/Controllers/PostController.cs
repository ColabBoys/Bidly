using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bidly.Models;
using Bidly.ViewModels;
using Microsoft.AspNet.Identity;

namespace Bidly.Controllers
{
    public class PostController : Controller
    {
        private ApplicationDbContext _context;

        public PostController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: POSTS
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ViewResult New()
        {
            var categories = _context.Categories.ToList();
            //var types = _context.EventTypes.ToList();

            var viewModel = new PostsFormViewModel
            {
                Categories = categories

            };

            return View("PostForm", viewModel);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var posts = _context.Posts.SingleOrDefault(c => c.Id == id);

            if (posts == null)
                return HttpNotFound();

            var viewModel = new PostsFormViewModel(posts)
            {
                //Movie = movie,
                Categories = _context.Categories.ToList()
            };

            return View("PostForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var post = _context.Posts.SingleOrDefault(m => m.Id == id);

            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }
        [Authorize]
        public ActionResult Save(Post posts)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new PostsFormViewModel
                {
                    Categories = _context.Categories.ToList()
                };

                return View("PostForm", viewModel);
            }

            if (posts.Id == 0)
            {
                string currentUserId = User.Identity.GetUserId();
                ApplicationUser currentUser = _context.Users.FirstOrDefault(x => x.Id == currentUserId);

                posts.DateAdded = DateTime.Now;
                posts.OwnerId = currentUserId; //User.Identity.GetUserId();
                _context.Posts.Add(posts);
            }
            else
            {
                // add stuff
                var postInDb = _context.Posts.Single(m => m.Id == posts.Id);
                postInDb.CategoryId = posts.CategoryId;
                // doesnt apply for edit movieInDb.DateAdded = movie.DateAdded;
                postInDb.Name = posts.Name;
            }

            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Index", "Post");
        }
    }
}