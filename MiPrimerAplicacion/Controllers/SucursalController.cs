using MiPrimerAplicacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiPrimerAplicacion.Controllers
{
    public class SucursalController : Controller
    {
        // GET: Sucursal
        public ActionResult Index()
        {
            List<SucursalCLS> listaSucursal = null;
            using (var bd = new BDPasajesEntities())
            {
                listaSucursal = (from sucursal in bd.Sucursal
                                 where sucursal.BHABILITADO == 1
                                 select new SucursalCLS
                                 {
                                     iidsucursal = sucursal.IIDSUCURSAL,
                                     nombre = sucursal.NOMBRE,
                                     direccion = sucursal.DIRECCION,
                                     telefono = sucursal.TELEFONO,
                                     email = sucursal.EMAIL,
                                     fechaapertura = (DateTime)sucursal.FECHAAPERTURA,
                                     bhabilitado = (int)sucursal.BHABILITADO
                                 }).ToList();
            }
            return View(listaSucursal);
        }

        [HttpPost]
        public ActionResult Agregar(SucursalCLS oSucursalCLS)
        {
            if (!ModelState.IsValid)
            {
                return View(oSucursalCLS);
            }
            else
            {
                using (var db = new BDPasajesEntities())
                {
                    Sucursal oSucursal = new Sucursal();
                    oSucursal.NOMBRE = oSucursalCLS.nombre;
                    oSucursal.DIRECCION = oSucursalCLS.direccion;
                    oSucursal.TELEFONO = oSucursalCLS.telefono;
                    oSucursal.EMAIL = oSucursalCLS.email;
                    oSucursal.FECHAAPERTURA = oSucursalCLS.fechaapertura;
                    oSucursal.BHABILITADO = 1;
                    db.Sucursal.Add(oSucursal);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult Agregar()
        {
            return View();
        }
    }
}