using System.Collections.Generic;
using System.Web.Mvc;
using JJ.Framework.Mvc.TestViews.ViewModels;
// ReSharper disable RedundantAssignment

namespace JJ.Framework.Mvc.TestViews.Controllers
{
    public class ItemsController : Controller
    {
        // GET: /Items/Details/5

        public ActionResult Details(int id)
        {
            ItemViewModel viewModel = CreateViewModel();

            return View(viewModel);
        }

        // GET: /Items/Edit/5

        public ActionResult Edit(int id)
        {
            ItemViewModel viewModel = CreateViewModel();

            return View(viewModel);
        }

        // POST: /Items/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, ItemViewModel viewModel)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(ActionNames.Details), new { viewModel.ID });
            }
            catch
            {
                return View();
            }
        }

        // Helpers

        public ItemViewModel CreateViewModel()
        {
            var i = 1;

            return new ItemViewModel
            {
                ID = i++,
                Name = "Root",
                Children = new List<ItemViewModel>
                {
                    new ItemViewModel
                    {
                        ID = i++,
                        Name = "Parent A",
                        Children = new List<ItemViewModel>
                        {
                            new ItemViewModel { ID = i++, Name = "Child A", Children = new List<ItemViewModel>() },
                            new ItemViewModel { ID = i++, Name = "Child B", Children = new List<ItemViewModel>() },
                            new ItemViewModel { ID = i++, Name = "Child C", Children = new List<ItemViewModel>() }
                        }
                    },
                    new ItemViewModel
                    {
                        ID = i++,
                        Name = "Parent B",
                        Children = new List<ItemViewModel>
                        {
                            new ItemViewModel { ID = i++, Name = "Child D", Children = new List<ItemViewModel>() },
                            new ItemViewModel { ID = i++, Name = "Child E", Children = new List<ItemViewModel>() }
                        }
                    }
                }
            };
        }
    }
}