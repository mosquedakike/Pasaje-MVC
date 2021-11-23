using MiPrimerAplicacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiPrimerAplicacion.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            List<ClienteCLS> listaCliente = null;
            using (var bd = new BDPasajeEntities())
            {
                listaCliente = (from cliente in bd.Cliente
                                where cliente.BHABILITADO == 1
                                select new ClienteCLS
                                {
                                    iidclinete = cliente.IIDCLIENTE,
                                    nombre = cliente.NOMBRE,
                                    appaterno = cliente.APPATERNO,
                                    apmaterno = cliente.APMATERNO,
                                    email = cliente.EMAIL,
                                    direccion = cliente.DIRECCION,
                                    iidsexo = (int)cliente.IIDSEXO,
                                    telefonofijo = cliente.TELEFONOFIJO,
                                    telefonocelular = cliente.TELEFONOCELULAR,
                                    bhabilitado = (int)cliente.BHABILITADO
                                }).ToList();
            }
            return View(listaCliente);
        }
    }
}