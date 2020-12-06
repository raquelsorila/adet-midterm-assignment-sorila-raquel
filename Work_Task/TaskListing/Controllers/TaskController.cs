using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskListing.Data;
using TaskListing.Models;

namespace TaskListing.Controllers
{
    public class TaskController : Controller
    {
        
        
            private readonly TaskListContext _db;

            public TaskList Task { get; set; }

            public TaskController(TaskListContext db)
            {
                _db = db;
            }

            // GET: TaskLists
            public async Task<IActionResult> Index()
            {
                return View(await _db.Tasks.ToListAsync());
            }



            // GET: TaskLists/Details/5
            public IActionResult Upsert(int? id)
            {
                Task = new TaskList(); //Walang Laman
                if (id == null)
                {
                    //create
                    return View(Task);
                }

                Task = _db.Tasks.FirstOrDefault(i => i.Id == id); //Lalagyan
                if (Task == null)
                {
                    return NotFound(); //404
                }
                return View(Task);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
                public IActionResult Upsert(int id)
            {
                Task = new TaskList();
                if (ModelState.IsValid)
                {
                    Task.TaskName = this.Request.Form["TaskName"];
                    Task.Id = id;
                    if (Task.Id == 0)
                    {
                        Task.TaskStatus = "To Do";
                        Task.TotalHours = "0";
                        Task.DateCreated = DateTime.Now;
                        _db.Tasks.Add(Task);
                    }
                    else
                    {
                        _db.Update(Task);
                    }
                        _db.SaveChanges();
                        return RedirectToAction("Index");
                    }

                    return View(Task);
                }
            public async Task<IActionResult> Delete(int id)
            {
                var task = await _db.Tasks.FindAsync(id);
                if (task == null)
                {
                    return NotFound();
                }
                else
                {
                    _db.Tasks.Remove(task);
                    _db.SaveChanges();
                }
                return RedirectToAction("index");

            }

           
                public async Task<IActionResult> ChangeState(int id)
            {
                var task = await _db.Tasks.FindAsync(id);
              
       
                if (task == null)
                {
                    return NotFound();
                }

                else
                {
                    if (task.TaskStatus == "To Do")
                    {
                        task.TaskStatus = "Doing";
                        task.DateStarted = DateTime.Now;
                    }
                    else if (task.TaskStatus == "Doing")
                    {
                        task.TaskStatus = "Finished";
                        task.DateFinished = DateTime.Now;
                        TimeSpan TotalHours = DateTime.Parse(task.DateFinished.ToString()).Subtract(DateTime.Parse(task.DateStarted.ToString()));
                        task.TotalHours = TotalHours.ToString();
                    }
                    _db.Update(task);
                    _db.SaveChanges();

                }
                return RedirectToAction("index");
            }
        }
            }

        
             


     
           