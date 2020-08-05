using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Dynamic;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    private readonly HairSalonContext _db;

    public ClientsController(HairSalonContext db)
    {
      _db = db;
    }

    public ActionResult Index(string sortOrder)
    {
      dynamic model = new ExpandoObject();
      ViewBag.ClientSort = sortOrder == "client" ? "client_desc" : "client";
      ViewBag.StylistSort = sortOrder == "stylist" ? "stylist_desc" : "stylist";

      switch(sortOrder)
      {
        case "client":
          model.Clients = _db.Clients.Include(client => client.Stylist)
            .OrderBy(client => client.Name)
            .ToList();
          break;
        case "client_desc":
          model.Clients = _db.Clients.Include(client => client.Stylist)
            .OrderByDescending(client => client.Name)
            .ToList();
          break;
        case "stylist":
          model.Clients = _db.Clients.Include(client => client.Stylist)
            .OrderBy(client => client.Stylist.Name)
            .ToList();
          break;
        case "stylist_desc":
          model.Clients = _db.Clients.Include(client => client.Stylist)
            .OrderByDescending(client => client.Stylist.Name)
            .ToList();
          break;
        default:
          model.Clients = _db.Clients.Include(client => client.Stylist).ToList();
          break;
      }

      model.Stylists = _db.Stylists.ToList();
      ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
      return View(model);
    }

    [HttpPost]
    public ActionResult Index(int StylistId)
    {
      int inputId = StylistId;
      dynamic model = new ExpandoObject();
      model.Clients =  _db.Clients
        .Include(client => client.Stylist)
        .Where(client => client.StylistId == inputId)
        .ToList();
      model.Stylists = _db.Stylists.ToList();
      ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Client client)
    {
      _db.Clients.Add(client);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Client thisClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
      return View(thisClient);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Client thisClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
      _db.Clients.Remove(thisClient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Client thisClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
      return View(thisClient);
    }

    public ActionResult Edit(int id)
    {
      Client thisClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
      ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "Name");
      return View(thisClient);
    }

    [HttpPost]
    public ActionResult Edit(Client client)
    {
      _db.Entry(client).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}