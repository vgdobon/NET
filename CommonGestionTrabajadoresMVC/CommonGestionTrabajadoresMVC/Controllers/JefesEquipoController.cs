using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CommonGestionTrabajadoresMVC.DTOs;
using CommonGestionTrabajadoresMVC.Models;

namespace CommonGestionTrabajadoresMVC.Controllers
{
    public class JefesEquipoController : Controller
    {
        private CommonGestionTrabajadoresEntities db = new CommonGestionTrabajadoresEntities();

        // GET: JefesEquipo
        public ActionResult Index()
        {
            List<JefesEquipo> jefesEquipo = db.JefesEquipo.Include(j => j.TrabajadoresDTecnico).ToList();
            List<JefeEquipoDTO> jefeEquipoDTOs = new List<JefeEquipoDTO>();
            jefesEquipo.ForEach(x => jefeEquipoDTOs.Add(MapJefeEquipoDBToDTO(x)));
            
            return View(jefeEquipoDTOs);
        }

        public JefesEquipo MapJefeEquipoDTOToDB(JefeEquipoDTO jefeEquipoDTO, JefesEquipo jefesEquipoDB)
        {



            jefesEquipoDB.TrabajadoresDTecnico.Trabajadores.Dni = jefeEquipoDTO.Dni;
            jefesEquipoDB.TrabajadoresDTecnico.Trabajadores.Nombre = jefeEquipoDTO.Nombre;
            jefesEquipoDB.TrabajadoresDTecnico.Trabajadores.Apellidos = jefeEquipoDTO.Apellidos;
            jefesEquipoDB.TrabajadoresDTecnico.Trabajadores.FechaNacimiento = jefeEquipoDTO.FechaNacimiento;
            jefesEquipoDB.TrabajadoresDTecnico.Trabajadores.Direccion = jefeEquipoDTO.Direccion;
            jefeEquipoDTO.FechaBaja = jefesEquipoDB.TrabajadoresDTecnico.Trabajadores.FechaBaja;
            jefeEquipoDTO.AnyosExp = jefesEquipoDB.TrabajadoresDTecnico.AnyosExperiencia;

            jefeEquipoDTO.ListaTecnologias = new List<TipoTecnologiaDTO>();
            foreach (TiposTecnologia tipos in jefesEquipoDB.TrabajadoresDTecnico.TiposTecnologia)
            {
                TipoTecnologiaDTO tipoTecnologiaDTO = new TipoTecnologiaDTO();
                tipoTecnologiaDTO.Id = tipos.Id;
                tipoTecnologiaDTO.Nombre = tipos.Nombre;
                jefeEquipoDTO.ListaTecnologias.Add(tipoTecnologiaDTO);
            }

            foreach (Proyectos proyectoDB in jefesEquipoDB.TrabajadoresDTecnico.Proyectos)
            {
                ProyectoDTO proyecto = new ProyectoDTO();
                proyecto.Id = proyectoDB.Id;
                proyecto.Nombre = proyectoDB.Nombre;
                jefeEquipoDTO.ListaProyectos.Add(proyecto);
            }

            jefeEquipoDTO.TfnoEmpresa = jefesEquipoDB.TelefonoEmpresa;

            return jefesEquipoDB;
        }
        public JefeEquipoDTO MapJefeEquipoDBToDTO(JefesEquipo jefesEquipoDB)
        {
            JefeEquipoDTO jefeEquipoDTO = new JefeEquipoDTO();
            jefeEquipoDTO.Id = jefesEquipoDB.TrabajadoresDTecnico.Trabajadores.Id;
            jefeEquipoDTO.Dni = jefesEquipoDB.TrabajadoresDTecnico.Trabajadores.Dni;
            jefeEquipoDTO.Nombre = jefesEquipoDB.TrabajadoresDTecnico.Trabajadores.Nombre;
            jefeEquipoDTO.Apellidos = jefesEquipoDB.TrabajadoresDTecnico.Trabajadores.Apellidos;
            jefeEquipoDTO.FechaNacimiento = jefesEquipoDB.TrabajadoresDTecnico.Trabajadores.FechaNacimiento;
            jefeEquipoDTO.Direccion = jefesEquipoDB.TrabajadoresDTecnico.Trabajadores.Direccion;
            jefeEquipoDTO.FechaBaja = jefesEquipoDB.TrabajadoresDTecnico.Trabajadores.FechaBaja;
            jefeEquipoDTO.AnyosExp = jefesEquipoDB.TrabajadoresDTecnico.AnyosExperiencia;

            jefeEquipoDTO.ListaTecnologias = new List<TipoTecnologiaDTO>();
            foreach (TiposTecnologia tipos in jefesEquipoDB.TrabajadoresDTecnico.TiposTecnologia){
                TipoTecnologiaDTO tipoTecnologiaDTO = new TipoTecnologiaDTO();
                tipoTecnologiaDTO.Id = tipos.Id;
                tipoTecnologiaDTO.Nombre = tipos.Nombre;
                jefeEquipoDTO.ListaTecnologias.Add(tipoTecnologiaDTO);
            }

            foreach(Proyectos proyectoDB in jefesEquipoDB.TrabajadoresDTecnico.Proyectos)
            {
                ProyectoDTO proyecto = new ProyectoDTO();
                proyecto.Id = proyectoDB.Id;
                proyecto.Nombre = proyectoDB.Nombre;
                jefeEquipoDTO.ListaProyectos.Add(proyecto);
            }

            jefeEquipoDTO.TfnoEmpresa = jefesEquipoDB.TelefonoEmpresa;
            
            return jefeEquipoDTO;
        }

        // GET: JefesEquipo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JefeEquipoDTO jefesEquipoDTO = MapJefeEquipoDBToDTO(db.JefesEquipo.Find(id));
            if (jefesEquipoDTO == null)
            {
                return HttpNotFound();
            }
            return View(jefesEquipoDTO);
        }

        // GET: JefesEquipo/Create
        public ActionResult Create()
        {
            ViewBag.TecnologiaList = new SelectList(db.TiposTecnologia, "Id", "Nombre");
            return View();
        }

        // POST: JefesEquipo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TelefonoEmpresa")] JefesEquipo jefesEquipo)
        {
            if (ModelState.IsValid)
            {
                db.JefesEquipo.Add(jefesEquipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.TrabajadoresDTecnico, "Id", "Id", jefesEquipo.Id);
            return View(jefesEquipo);
        }

        // GET: JefesEquipo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JefeEquipoDTO jefesEquipoDTO = MapJefeEquipoDBToDTO(db.JefesEquipo.Find(id));
            if (jefesEquipoDTO == null)
            {
                return HttpNotFound();
            }
            //ViewBag.Id = new SelectList(db.TrabajadoresDTecnico, "Id", "Id", jefesEquipo.Id);
            return View(jefesEquipoDTO);
        }

        // POST: JefesEquipo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TelefonoEmpresa")] JefesEquipo jefesEquipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jefesEquipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.TrabajadoresDTecnico, "Id", "Id", jefesEquipo.Id);
            return View(jefesEquipo);
        }

        // GET: JefesEquipo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JefesEquipo jefesEquipo = db.JefesEquipo.Find(id);
            if (jefesEquipo == null)
            {
                return HttpNotFound();
            }
            return View(jefesEquipo);
        }

        // POST: JefesEquipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JefesEquipo jefesEquipo = db.JefesEquipo.Find(id);
            db.JefesEquipo.Remove(jefesEquipo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
