using Microsoft.AspNetCore.Mvc;
using Tamagotchi.Models;
using System.Collections.Generic;
using System;

namespace Tamagotchi.Controllers
{
  public class ItemsController : Controller
  {
    [HttpGet("/items")]
    public ActionResult Index()
    {
      List<Item> allItems = Item.GetAll();
      return View(allItems);
    }

    [HttpGet("/items/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/items")]
    public ActionResult Create(string description)
    {
      Item myItem = new Item(description);
      return RedirectToAction("Index");
    }

    [HttpPost("/items/delete")]
    public ActionResult DeleteAll()
    {
      Item.ClearAll();
      return View();
    }

    [HttpGet("/items/{id}")]
    public ActionResult Show(int id)
    {
      Item item = Item.Find(id);
      return View(item);
    }

    [HttpPost("/items/{id}/feed")]
    public ActionResult Feed(int id)
    {
        Item item = Item.Find(id);
        item.SetHunger(item.GetHunger()+30);
        foreach(Item itemm in Item.GetAll())
        {
          itemm.Tick();
        }
      return RedirectToAction("Show",id);
    }

    [HttpPost("/items/{id}/rest")]
    public ActionResult Rest(int id)
    {
        Item item = Item.Find(id);
        item.SetRest(item.GetRest()+30);
        foreach(Item itemm in Item.GetAll())
          {
            itemm.Tick();
          }
      return RedirectToAction("Show",id);
    }

    [HttpPost("/items/{id}/poop")]
    public ActionResult Poop(int id)
    {
        Item item = Item.Find(id);
        item.SetPoop(0);
        foreach(Item itemm in Item.GetAll())
          {
            itemm.Tick();
          }
      return RedirectToAction("Show",id);
    }
    [HttpPost("/items/{id}/attention")]
    public ActionResult Attention(int id)
    {

        Item item = Item.Find(id);
        item.SetAttention(item.GetAttention()+30);
        foreach(Item itemm in Item.GetAll())
          {
            itemm.Tick();
          }
      return RedirectToAction("Show",id);
    }
  }
}
