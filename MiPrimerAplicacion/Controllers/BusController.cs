using MiPrimerAplicacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiPrimerAplicacion.Controllers
{
    public class BusController : Controller
    {
        // GET Bus
        public ActionResult Index()
        {
            List<BusCLS> listaBus = null;
            using (var db = new BDPasajesEntities())
            {
                listaBus = (
                    from bus in db.Bus
                    join sucursal in db.Sucursal on bus.IIDSUCURSAL equals sucursal.IIDSUCURSAL
                    join tipobus in db.TipoBus on bus.IIDTIPOBUS equals tipobus.IIDTIPOBUS
                    join tipomodelo in db.Modelo on bus.IIDMODELO equals tipomodelo.IIDMODELO
                    where bus.BHABILITADO == 1
                    select new BusCLS
                    {
                        iidbus = bus.IIDBUS,
                        placa = bus.PLACA,
                        nombremodelo = tipomodelo.NOMBRE,
                        nombresucursal = sucursal.NOMBRE,
                        nombretipobus = tipobus.NOMBRE,
                    }).ToList();
            }
            return View(listaBus);
        }
    }
}