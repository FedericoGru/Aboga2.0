using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplicacion_Aboga2.Models;
namespace Aplicacion_Aboga2.Controllers
{
    public class BackofficeController : Controller
    {
        // GET: Backoffice
        public ActionResult Menu()
        {
            return View();
        }
        /*public ActionResult ABMContactos(Contactos cts)
        {
            ViewBag.Contactos = BD.TraerContactos();
            return View();
        }
        public ActionResult InsertarContactos(string Accion)
        {
            ViewBag.Accion = Accion;
            return View();
        }
        public ActionResult FormContactos(string Accion, int IdCts)
        {
            ViewBag.Contactos = BD.TraerContactos();
            return View();
        }*/

        public ActionResult ABMExpedientes(Expediente ex)
        {
            ViewBag.Expedientes = BD.TraerExpedientes();
            return View();
        }
        public ActionResult InsertarExpediente(string Accion)
        {
            ViewBag.Accion = Accion;
            return View();
        }
        public ActionResult FormExpediente(string Accion, int IdEx)
        {
            Expediente UnExpediente = BD.TraerExpediente(IdEx);
            ViewBag.Accion = Accion;
            if (Accion == "Obtener")
            {
               return View("EdicionExpediente", UnExpediente);
            }
            if (Accion=="Eliminar")
            {
                BD.Eliminar(IdEx);
                ViewBag.Expedientes = BD.TraerExpedientes();
                return View("ABMExpedientes");
            }
            return View("SinAccion");
        }
        [HttpPost]
        public ActionResult EdicionExpediente(Expediente ex, string Accion)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Expedientes = BD.TraerExpedientes();
                return View("ABMExpedientes");
            }
            else
            {
                if(Accion == "Obtener")
                {
                    BD.ModificarExpediente(ex);
                    ViewBag.Expedientes = BD.TraerExpedientes();
                    return View("ABMExpedientes");
                    
                }
                else
                {
                    if (Accion == "Insertar")
                    {
                        if (!ModelState.IsValid)
                        {
                            ViewBag.Expedientes = BD.CrearExpediente();
                            return View("InsertarExpediente");
                        }
                        else
                        {
                            BD.InsertarExpediente(ex);
                            ViewBag.Expedientes = BD.CrearExpediente();
                            return View("ABMExpedientes");
                        }
                    }
                }
            }
            ViewBag.Expedientes = BD.TraerExpedientes();
            return View("ABMExpedientes");
        }
    }
}