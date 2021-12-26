using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiPrimerAplicacion.Models;

namespace MiPrimerAplicacion.Controllers
{
    public class ViajeController : Controller
    {
        // GET: Viaje
        public ActionResult Index()
        {
            List<ViajeCLS> listaViaje = null;
            using (var db = new BDPasajesEntities())
            {
                listaViaje = (
                    from viaje in db.Viaje
                    join lugarorigen in db.Lugar on viaje.IIDLUGARORIGEN equals lugarorigen.IIDLUGAR
                    join lugardestino in db.Lugar on viaje.IIDLUGARDESTINO equals lugardestino.IIDLUGAR
                    join bus in db.Bus on viaje.IIDBUS equals bus.IIDBUS
                    where viaje.BHABILITADO == 1
                    select new ViajeCLS
                    {
                        iidviaje = viaje.IIDVIAJE,
                        nombrelugarorigen = lugarorigen.NOMBRE,
                        nombrelugardestino = lugardestino.NOMBRE,
                        nombrebus = bus.PLACA
                    }).ToList();
            }
            return View(listaViaje);
        }
    }
}