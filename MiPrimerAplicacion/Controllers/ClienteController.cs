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
            using (var bd = new BDPasajesEntities())
            {
                listaCliente = (
                                from cliente in bd.Cliente
                                join tiposexo in bd.Sexo on cliente.IIDSEXO equals tiposexo.IIDSEXO 
                                where cliente.BHABILITADO == 1
                                select new ClienteCLS
                                {
                                    iidclinete = cliente.IIDCLIENTE,
                                    nombre = cliente.NOMBRE,
                                    appaterno = cliente.APPATERNO,
                                    apmaterno = cliente.APMATERNO,
                                    email = cliente.EMAIL,
                                    direccion = cliente.DIRECCION,
                                    nombreTipoSexo = tiposexo.NOMBRE,
                                    telefonofijo = cliente.TELEFONOFIJO,
                                    telefonocelular = cliente.TELEFONOCELULAR,
                                    bhabilitado = (int)cliente.BHABILITADO
                                }).ToList();
            }
            return View(listaCliente);
        }

        [HttpPost]
        public ActionResult Agregar(ClienteCLS oClienteCLS)
        {
            if (!ModelState.IsValid)
            {
                llenadoSexo();
                ViewBag.lista = listaSexo;
                return View(oClienteCLS);
            }
            else
            {
                using (var db = new BDPasajesEntities())
                {
                    Cliente oCliente = new Cliente();
                    oCliente.NOMBRE = oClienteCLS.nombre;
                    oCliente.APPATERNO = oClienteCLS.appaterno;
                    oCliente.APMATERNO = oClienteCLS.apmaterno;
                    oCliente.EMAIL = oClienteCLS.email;
                    oCliente.DIRECCION = oClienteCLS.direccion;
                    oCliente.IIDSEXO = oClienteCLS.iidsexo;
                    oCliente.TELEFONOFIJO = oClienteCLS.telefonofijo;
                    oCliente.TELEFONOCELULAR = oClienteCLS.telefonocelular;
                    oCliente.BHABILITADO = 1;
                    db.Cliente.Add(oCliente);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        List<SelectListItem> listaSexo;
        private void llenadoSexo() 
        {
            using (var db = new BDPasajesEntities())
            {
                listaSexo = (from sexo in db.Sexo
                            where sexo.BHABILITADO == 1
                            select new SelectListItem
                            { 
                                Text=sexo.NOMBRE,
                                Value=sexo.IIDSEXO.ToString()
                            }).ToList();
                listaSexo.Insert(0,new SelectListItem{ Text = "--Seleccione--",Value = ""});
            }
        }

        public ActionResult Editar(int id)
        {
            ClienteCLS oClienteCLS = new ClienteCLS();
            using (var db = new BDPasajesEntities())
            {
                var oCliente = db.Cliente.First(p => p.IIDCLIENTE.Equals(id));
                oCliente.NOMBRE = oClienteCLS.nombre;
                oCliente.APPATERNO = oClienteCLS.appaterno;
                oCliente.APMATERNO = oClienteCLS.apmaterno;
                oCliente.EMAIL = oClienteCLS.email;
                oCliente.DIRECCION = oClienteCLS.direccion;
                oCliente.IIDSEXO = oClienteCLS.iidsexo;
                oCliente.TELEFONOFIJO = oClienteCLS.telefonofijo;
                oCliente.TELEFONOCELULAR = oClienteCLS.telefonocelular;
            }

            return View(oClienteCLS);
        }

        public ActionResult Eliminar(int id)
        {
            return View();
        }

        public ActionResult Agregar()
        {
            llenadoSexo();
            ViewBag.lista = listaSexo;
            return View();
        }
    }
}