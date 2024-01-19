namespace APP.controllers;

using APP.models;
using APP.services;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

public class UserController : Controller{
    private readonly IUserService _svc;
    public UserController(IUserService svc){
        this._svc = svc;
    }

    [HttpGet]
    public IActionResult Index(){
        List<User> users = _svc.GetAll();
        TempData["allUsers"] = users;
        return View();
    }

    public IActionResult AddUser(){
        return View();
    }

    [HttpPost]
    public IActionResult AddUser(IFormCollection form){
        var id = int.Parse(form["id"].ToString());
        var name = form["name"].ToString();
        var email = form["email"].ToString();
        var address = form["address"].ToString();

        User user = new User(id,name,email,address);
        _svc.AddUser(user);
        return RedirectToAction("Index","User");
    }

    [HttpGet]
    public IActionResult UpdateUser(int id){
        List<User> users = _svc.GetAll();
        User user = users.Find((p)=>p.userId==id);
        return View(user);
    }

    [HttpPost]
    public IActionResult UpdateUser(IFormCollection form){
        var id = int.Parse(form["id"].ToString());
        var name = form["name"].ToString();
        var email = form["email"].ToString();
        var address = form["address"].ToString();

        User user = new User(id,name,email,address);
        _svc.Update(user);
        return RedirectToAction("Index","User");
    }

    public IActionResult Details(int id){
        User user = _svc.GetById(id);
        return View(user);
    }

    public IActionResult Delete(int id){
        _svc.DeleteById(id);
        return RedirectToAction("Index","User");
    }
}