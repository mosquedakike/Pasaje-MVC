using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiPrimerAplicacion.Models;

namespace MiPrimerAplicacion.Controllers
{
    public class MarcaController : Controller
    {
        // GET: Marca
        public ActionResult Index()
        {
            List<MarcaCLS> listaMarca = null;
            using (var bd = new BDPasajesEntities())
            {
                listaMarca = (from marca in bd.Marca
                              where marca.BHABILITADO == 1
                              select new MarcaCLS
                              {
                                  iidmarca = marca.IIDMARCA,
                                  nombre = marca.NOMBRE,
                                  descripcion = marca.DESCRIPCION
                              }).ToList();
            }
            return View(listaMarca);
        }

        //vista agregar (insert)
        [HttpPost]
        public ActionResult Agregar(MarcaCLS oMarcaCLS)
        {
            if (!ModelState.IsValid)
            {
                return View(oMarcaCLS);
            }
            else
            {
                using (var db = new BDPasajesEntities())
                { 
                    Marca oMarca = new Marca();
                    oMarca.NOMBRE = oMarcaCLS.nombre;
                    oMarca.DESCRIPCION = oMarcaCLS.descripcion;
                    oMarca.BHABILITADO = 1;
                    db.Marca.Add(oMarca);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        
        public ActionResult Editar(int id)
        {
            MarcaCLS oMarcaCLS = new MarcaCLS();
            using (var db = new BDPasajesEntities())
            {
                var oMarca = db.Marca.First(p => p.IIDMARCA.Equals(id)); 
                //Marca oMarca = db.Marca.Where(p => p.IIDMARCA.Equals(id)).First();

                oMarcaCLS.iidmarca = oMarca.IIDMARCA;
                oMarcaCLS.nombre = oMarca.NOMBRE;
                oMarcaCLS.descripcion = oMarca.DESCRIPCION;
            }
            return View(oMarcaCLS);
        }

        public ActionResult Eliminar(int id)
        {
            return View();
        }

        //muestra la vista
        public ActionResult Agregar()
        {
            return View();
        }
    }
}