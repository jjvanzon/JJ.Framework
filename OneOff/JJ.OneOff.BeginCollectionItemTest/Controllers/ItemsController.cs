using JJ.OneOff.BeginCollectionItemTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JJ.OneOff.BeginCollectionItemTest.Controllers
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

                return RedirectToAction(ActionNames.Details, new { ID = viewModel.ID });
            }
            catch
            {
                return View();
            }
        }

        // Helpers

        public ItemViewModel CreateViewModel()
        {
            int i = 1;
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
                            new ItemViewModel { ID = i++, Name = "Child A", Children = new List<ItemViewModel>()},
                            new ItemViewModel { ID = i++, Name = "Child B", Children = new List<ItemViewModel>()},
                            new ItemViewModel { ID = i++, Name = "Child C", Children = new List<ItemViewModel>()}
                        }
                    },
                    new ItemViewModel
                    {
                        ID = i++,
                        Name = "Parent B",              
                        Children = new List<ItemViewModel>
                        {
                            new ItemViewModel { ID = i++, Name = "Child D", Children = new List<ItemViewModel>()},
                            new ItemViewModel { ID = i++, Name = "Child E", Children = new List<ItemViewModel>()}
                        }
                    },
                }
            };
        }
    }
}
