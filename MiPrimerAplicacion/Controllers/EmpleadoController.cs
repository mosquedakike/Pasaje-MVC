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
    }
}