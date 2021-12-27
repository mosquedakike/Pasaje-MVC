using MiPrimerAplicacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiPrimerAplicacion.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET Empleado
        public ActionResult Index()
        {
            List<EmpleadoCLS> listaEmpleado = null;
            using (var db = new BDPasajesEntities())
            {
                listaEmpleado = (
                    from empleado in db.Empleado
                    join tipousuario in db.TipoUsuario on empleado.IIDTIPOUSUARIO equals tipousuario.IIDTIPOUSUARIO
                    join tipocontrato in db.TipoContrato on empleado.IIDTIPOCONTRATO equals tipocontrato.IIDTIPOCONTRATO
                    where empleado.BHABILITADO == 1
                    select new EmpleadoCLS
                    {
                        iidEmpleado = empleado.IIDEMPLEADO,
                        nombre = empleado.NOMBRE,
                        apPaterno = empleado.APPATERNO,
                        apMaterno = empleado.APMATERNO,
                        nombreTipoUsuario = tipousuario.NOMBRE,
                        nombreTipoContrato = tipocontrato.NOMBRE
                    }).ToList();
            }
            return View(listaEmpleado);
        }

        [HttpPost]
        public ActionResult Agregar(EmpleadoCLS oEmpleadoCLS)
        {
            if (!ModelState.IsValid)
            {
                listarCombos();
                return View(oEmpleadoCLS);
            }
            else
            {
                using (var db = new BDPasajesEntities())
                {
                    Empleado oEmpleado = new Empleado();
                    oEmpleado.NOMBRE = oEmpleadoCLS.nombre;
                    oEmpleado.APPATERNO = oEmpleadoCLS.apPaterno;
                    oEmpleado.APMATERNO = oEmpleadoCLS.apMaterno;
                    oEmpleado.FECHACONTRATO = oEmpleadoCLS.fechaContrato;
                    oEmpleado.SUELDO = oEmpleadoCLS.sueldo;
                    oEmpleado.IIDTIPOUSUARIO = oEmpleadoCLS.iidTipoUsuario;
                    oEmpleado.IIDTIPOCONTRATO = oEmpleadoCLS.iidTipoContrato;
                    oEmpleado.IIDSEXO = oEmpleadoCLS.iidsexo;
                    oEmpleado.BHABILITADO = 1;
                    db.Empleado.Add(oEmpleado);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
        
        public void listarComboSexo()
        {
            //agregar
            List<SelectListItem> lista;
            using (var db = new BDPasajesEntities())
            {
                lista = (from sexo in db.Sexo
                    where sexo.BHABILITADO == 1
                    select new SelectListItem
                    {
                        Text = sexo.NOMBRE,
                        Value = sexo.IIDSEXO.ToString()
                    }).ToList();
                lista.Insert(0,new SelectListItem{ Text = "--Seleccione--", Value = ""});
                ViewBag.listaSexo = lista;
            }
        }

        public void litarTipoUsuario()
        {
            //agregar
            List<SelectListItem> lista;
            using (var db = new BDPasajesEntities())
            {
                lista = (from tipousuario in db.TipoUsuario
                    where tipousuario.BHABILITADO == 1
                    select new SelectListItem
                    {
                        Text = tipousuario.NOMBRE,
                        Value = tipousuario.IIDTIPOUSUARIO.ToString()
                    }).ToList();
                lista.Insert(0,new SelectListItem{ Text = "--Seleccione--", Value = ""});
                ViewBag.listatipousuario = lista;
            }
        }

        public void listarTipoContrato()
        {
            List<SelectListItem> lista;
            using (var db = new BDPasajesEntities())
            {
                lista = (from tipocontrato in db.TipoContrato
                    where tipocontrato.BHABILITADO == 1
                    select new SelectListItem
                    {
                        Text = tipocontrato.NOMBRE,
                        Value = tipocontrato.IIDTIPOCONTRATO.ToString()
                    }).ToList();
                lista.Insert(0, new SelectListItem{ Text = "--Seleccion--", Value = ""});
                ViewBag.listatipocontrato = lista;
            }
        }

        public void listarCombos()
        {
            listarComboSexo();
            litarTipoUsuario();
            listarTipoContrato();
        }

        public ActionResult Agregar()
        {
            listarCombos();
            return View();
        }
    }
}