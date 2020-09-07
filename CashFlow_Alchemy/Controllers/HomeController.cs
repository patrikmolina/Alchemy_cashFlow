using CashFlow_Alchemy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CashFlow_Alchemy.Controllers
{
    public class HomeController : Controller

    {
        // GET: Home
        public ActionResult Index()
        {
            acciones acc = new acciones();
            return View(acc.RecuperarTodos());
        }

        public ActionResult Alta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Alta(FormCollection collection)
        {
            acciones acc = new acciones();
            Operaciones op = new Operaciones
            {
                Fecha = DateTime.Parse(collection["Fecha"].ToString()),
                Concepto = collection["Concepto"],
                Monto = float.Parse(collection["Monto"].ToString()),
                Tipo = collection["Tipo"]
            };
            acc.Alta(op);
            return RedirectToAction("Index");
        }

        public ActionResult Baja(int id)
        {
            acciones acc = new acciones();
            acc.Borrar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Modificacion(int Id)
        {
            acciones acc = new acciones();
            Operaciones op = acc.Recuperar(Id);
            return View(op);
        }

        [HttpPost]
        public ActionResult Modificacion(FormCollection collection)
        {
            acciones acc = new acciones();
            Operaciones op = new Operaciones
            {
                Id = int.Parse(collection["Id"].ToString()),
                Fecha = DateTime.Parse(collection["Fecha"].ToString()),
                Concepto = collection["Concepto"].ToString(),
                Monto = float.Parse(collection["Monto"].ToString())
            };
            acc.Modificar(op);
            return RedirectToAction("Index");
        }




    }
}