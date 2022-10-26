﻿//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using RainingCatsAndDogsOnWeb.Data;
//using RainingCatsAndDogsOnWeb.Data.Models;
//using RainingCatsAndDogsOnWeb.Web.ViewModels.Comments;
//using System.Linq;
//using System.Threading.Tasks;

//namespace RainingCatsAndDogsOnWeb.Web.Controllers
//{
//    public class CommentsController : Controller
//    {
//        private readonly ApplicationDbContext dbContext;

//        public CommentsController(ApplicationDbContext dbContext)
//        {
//            dbContext = dbContext;
//        }

//        [HttpGet]
//        public IActionResult Add()
//        {
//            return this.View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Add(AddCommentViewModel model)
//        {
//            var comment = new Comment()
//            {
//                Id = model.Id,
//                Content = model.Content,
//            };

//            //await this.dbContext.Comments.Add(comment);

//            //await this.dbContext.SaveChanges();

//            return RedirectToAction("All", "Comments");
//        }

//        public async Task<IActionResult> All()
//        {
//            var comments = await this.dbContext.Comments
//                                          .Select(c => new CommentViewModel
//                                          {
//                                              Id = c.Id,
//                                              Content = c.Content,
//                                              Replies = c.Replies,
//                                          }).ToListAsync();

//            return this.View(comments);
//        }
//    }
//}
