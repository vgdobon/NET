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

            foreach (JefesEquipo jeDB in jefesEquipo)
            {
                if(jeDB.TrabajadoresDTecnico.Trabajadores.Borrado == false)
                {
                    jefeEquipoDTOs.Add(MapJefeEquipoDBToDTO(jeDB));
                }
            }

            return View(jefeEquipoDTOs);
        }

        public TiposTecnologia MapTiposTecnologiaDTOtoDB(TipoTecnologiaDTO tipTecDTO, TiposTecnologia tipoTecnologia)
        {
            tipoTecnologia.Id = tipTecDTO.Id;
            tipoTecnologia.Nombre = tipTecDTO.Nombre;
            return tipoTecnologia;
        }

        public JefesEquipo MapJefeEquipoDTOToDB(JefeEquipoDTO jefeEquipoDTO, JefesEquipo jefesEquipoDB)
        {

            jefesEquipoDB.TrabajadoresDTecnico.Trabajadores.Dni = jefeEquipoDTO.Dni;
            jefesEquipoDB.TrabajadoresDTecnico.Trabajadores.Nombre = jefeEquipoDTO.Nombre;
            jefesEquipoDB.TrabajadoresDTecnico.Trabajadores.Apellidos = jefeEquipoDTO.Apellidos;
            jefesEquipoDB.TrabajadoresDTecnico.Trabajadores.FechaNacimiento = jefeEquipoDTO.FechaNacimiento;
            jefesEquipoDB.TrabajadoresDTecnico.Trabajadores.Direccion = jefeEquipoDTO.Direccion;
            jefesEquipoDB.TrabajadoresDTecnico.Trabajadores.FechaBaja = jefeEquipoDTO.FechaBaja;
            jefesEquipoDB.TrabajadoresDTecnico.AnyosExperiencia = jefeEquipoDTO.AnyosExp;
            jefesEquipoDB.TrabajadoresDTecnico.TiposTecnologia.Clear();

            foreach (int tipo in jefeEquipoDTO.IdTecnologias)
            {
                TiposTecnologia tipoTecnologia = db.TiposTecnologia.FirstOrDefault(x => x.Id == tipo);
                jefesEquipoDB.TrabajadoresDTecnico.TiposTecnologia.Add(tipoTecnologia);
            }

            jefesEquipoDB.TelefonoEmpresa = jefeEquipoDTO.TfnoEmpresa;

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

            jefeEquipoDTO.IdTecnologias = new List<int>();
            foreach (TiposTecnologia tipos in jefesEquipoDB.TrabajadoresDTecnico.TiposTecnologia){
                TipoTecnologiaDTO tipoTecnologiaDTO = new TipoTecnologiaDTO();
                tipoTecnologiaDTO.Id = tipos.Id;
                tipoTecnologiaDTO.Nombre = tipos.Nombre;
                jefeEquipoDTO.IdTecnologias.Add(tipos.Id);
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
            ViewBag.TecnologiaList = new MultiSelectList(db.TiposTecnologia, "Id", "Nombre");
            return View();
        }

        // POST: JefesEquipo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JefeEquipoDTO jefeEquipoDTO)
        {

            JefesEquipo jeDB = new JefesEquipo();
            jeDB.TrabajadoresDTecnico = new TrabajadoresDTecnico();
            jeDB.TrabajadoresDTecnico.Trabajadores = new Trabajadores();
            MapJefeEquipoDTOToDB(jefeEquipoDTO, jeDB);


            db.JefesEquipo.Add(jeDB);
            db.Entry(jeDB).State = EntityState.Added;
            db.SaveChanges();

            ViewBag.TecnologiaList = new MultiSelectList(db.TiposTecnologia, "Id", "Nombre");
            return RedirectToAction("Index");
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
            ViewBag.TecnologiaList = new MultiSelectList(db.TiposTecnologia, "Id", "Nombre", jefesEquipoDTO.ListaTecnologias.Select(x => x.Id));
            
            return View(jefesEquipoDTO);
        }

        // POST: JefesEquipo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(JefeEquipoDTO jefesEquipoDTO)
        {
            JefesEquipo jeDB = db.JefesEquipo.Find(jefesEquipoDTO.Id);
            MapJefeEquipoDTOToDB(jefesEquipoDTO , jeDB);
            if (ModelState.IsValid)
            {
                db.Entry(jeDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TecnologiaList = new MultiSelectList(db.TiposTecnologia, "Id", "Nombre",jefesEquipoDTO.ListaTecnologias.Select(x => x.Id));
            return View(jefesEquipoDTO);
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
            Trabajadores jefesEquipo = db.Trabajadores.Find(id);
            jefesEquipo.Borrado = true;
            db.Entry(jefesEquipo).State = EntityState.Modified;
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
