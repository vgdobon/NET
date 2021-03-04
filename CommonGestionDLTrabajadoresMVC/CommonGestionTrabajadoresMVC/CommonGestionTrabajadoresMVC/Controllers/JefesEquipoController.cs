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
        List<JefeEquipoDTO> ljeDTO = new List<JefeEquipoDTO>();

        // GET: JefesEquipo
        public ActionResult Index(string filtro = "")
        {
            MapearListaJefesEquipoBDAListaJefeEquipoDTO(filtro);
            ViewBag.Filtro = filtro;
            return View(ljeDTO);
        }

        // GET: JefesEquipo/Details/5
        public ActionResult Details(int? id)
        {
            //MapearListaJefesEquipoBDAListaJefeEquipoDTO();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JefesEquipo jefesEquipoDB = db.JefesEquipo.Find(id);

            if (jefesEquipoDB == null)
            {
                return HttpNotFound();
            }
            JefeEquipoDTO jeDTO = MapearJefesEquipoDBaJefeEquipoDTO(jefesEquipoDB);
            return View(jeDTO);
        }

        // GET: JefesEquipo/Create
        public ActionResult Create()
        {
            //ViewBag.Id = new SelectList(db.TrabajadoresDTecnico, "Id", "Id");
            ViewBag.SelectListProyectos = new SelectList(GetProjects(), "Id", "Nombre");
            ViewBag.SelectListTecnologias = new SelectList(GetTecnologias(), "Id", "Nombre");
            return View();
        }

        // POST: JefesEquipo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JefeEquipoDTO jDTO, String[] ListaTecnologias, String[] ListaProyectos)
        {
            List<int> tecnologiasId = ListaTecnologias.Select(x => Int32.Parse(x)).ToList();
            List<int> proyectosId = ListaProyectos.Select(x => Int32.Parse(x)).ToList();
            JefesEquipo jefesEquipo = MapearJefeEquipoDTOAJefesEquipo(jDTO, tecnologiasId, proyectosId);
            if (jefesEquipo != null)
            {
                db.JefesEquipo.Add(jefesEquipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SelectListProyectos = new SelectList(GetProjects(), "Id", "Nombre");
            ViewBag.SelectListTecnologias = new SelectList(GetTecnologias(), "Id", "Nombre");
            return View(jDTO);
        }

        // GET: JefesEquipo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JefeEquipoDTO jefeEquipo = MapearJefesEquipoDBaJefeEquipoDTO(db.JefesEquipo.Find(id));
            if (jefeEquipo == null)
            {
                return HttpNotFound();
            }

            ViewBag.SelectListProyectos = new SelectList(GetProjects(), "Id", "Nombre");
            ViewBag.SelectListTecnologias = new SelectList(GetTecnologias(), "Id", "Nombre");
            return View(jefeEquipo);
        }

        // POST: JefesEquipo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(JefeEquipoDTO jDTO, List<string> ListaTecnologias, List<string> ListaProyectos)
        {
            List<int> tecnologiasId = ListaTecnologias.Select(x => Int32.Parse(x)).ToList();
            List<int> proyectosId = ListaProyectos.Select(x => Int32.Parse(x)).ToList();
            JefesEquipo jefesEquipo = editarJefesEquipoDesdeUnJefeEquipoDTO(jDTO, tecnologiasId, proyectosId);

            if (jefesEquipo != null)
            {
               // db.Entry(jefesEquipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SelectListProyectos = new SelectList(GetProjects(), "Id", "Nombre");
            ViewBag.SelectListTecnologias = new SelectList(GetTecnologias(), "Id", "Nombre");
            return View(jDTO);
        }

        // GET: JefesEquipo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JefeEquipoDTO jefeEquipoDTO = MapearJefesEquipoDBaJefeEquipoDTO(db.JefesEquipo.Find(id));
            if (jefeEquipoDTO == null)
            {
                return HttpNotFound();
            }
            return View(jefeEquipoDTO);
        }

        // POST: JefesEquipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JefesEquipo jefesEquipo = db.JefesEquipo.Find(id);
            jefesEquipo.TrabajadoresDTecnico.Proyectos.Clear();
            jefesEquipo.TrabajadoresDTecnico.TiposTecnologia.Clear();
            jefesEquipo.TrabajadoresDTecnico.Trabajadores.Borrado = true;
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

        public ActionResult Lista()
        {
            ViewBag.Filtro = "";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Lista(string Filtro)
        {
            return RedirectToAction("Index", new { filtro = Filtro });
        }


        private void MapearListaJefesEquipoBDAListaJefeEquipoDTO(string filtro = "")
        {
            if (filtro == "")
            {
                db.JefesEquipo.ToList().ForEach(jeDB =>
                {
                    if (jeDB.TrabajadoresDTecnico.Trabajadores.Borrado == false)
                        ljeDTO.Add(MapearJefesEquipoDBaJefeEquipoDTO(jeDB));
                });
            }
            else
            {
                filtro = filtro.ToLower();
                db.JefesEquipo.ToList().ForEach(jeDB =>
                {
                    if (jeDB.TrabajadoresDTecnico.Trabajadores.Borrado == false)
                    {
                        if(jeDB.TrabajadoresDTecnico.Trabajadores.Nombre.ToLower().Contains(filtro) || jeDB.TrabajadoresDTecnico.Trabajadores.Apellidos.ToLower().Contains(filtro))
                        {
                            ljeDTO.Add(MapearJefesEquipoDBaJefeEquipoDTO(jeDB));
                        }
                    }
                });
            }
        }

        private JefeEquipoDTO MapearJefesEquipoDBaJefeEquipoDTO(JefesEquipo jeDB)
        {

            JefeEquipoDTO jeDTO = new JefeEquipoDTO()
            {
                Id = jeDB.Id,
                Dni = jeDB.TrabajadoresDTecnico.Trabajadores.Dni,
                Nombre = jeDB.TrabajadoresDTecnico.Trabajadores.Nombre,
                Apellidos = jeDB.TrabajadoresDTecnico.Trabajadores.Apellidos,
                FechaNacimiento = jeDB.TrabajadoresDTecnico.Trabajadores.FechaNacimiento,
                Direccion = jeDB.TrabajadoresDTecnico.Trabajadores.Direccion,
                FechaBaja = jeDB.TrabajadoresDTecnico.Trabajadores.FechaBaja,
                AnyosExp = jeDB.TrabajadoresDTecnico.AnyosExperiencia,
                ListaTecnologias = MapearListaTiposTecnologiaDBATiposTecnologiaDTO(jeDB),
                ListaProyectos = MapearListaDeProyectosDBAListaProyectosDTO(jeDB),
                TfnoEmpresa = jeDB.Tfno
                
            };
            return jeDTO;
        }


        private List<TipoTecnologiaDTO> MapearListaTiposTecnologiaDBATiposTecnologiaDTO(JefesEquipo jeDB)
        {
            List<TipoTecnologiaDTO> listaTecnologias = new List<TipoTecnologiaDTO>();
            jeDB.TrabajadoresDTecnico.TiposTecnologia.ToList().ForEach(tt =>
            {
                TipoTecnologiaDTO ttDTO = new TipoTecnologiaDTO()
                {
                    Id = tt.Id,
                    Nombre = tt.Nombre
                };
                listaTecnologias.Add(ttDTO);
            });

            return listaTecnologias;
        }

        private List<ProyectoDTO> MapearListaDeProyectosDBAListaProyectosDTO(JefesEquipo jeDB)
        {
            List<ProyectoDTO> listaProyectos = new List<ProyectoDTO>();
            jeDB.TrabajadoresDTecnico.Proyectos.ToList().ForEach(p =>
            {
                ProyectoDTO pDTO = new ProyectoDTO()
                {
                    Id = p.Id,
                    Nombre = p.Nombre,
                    FechaLimite = p.FechaLimite ?? DateTime.MinValue
                };
                listaProyectos.Add(pDTO);
            });


            return listaProyectos;
        }

        private List<ProyectoDTO> GetProjects()
        {
            List<ProyectoDTO> proyectos = new List<ProyectoDTO>();

            db.Proyectos.ToList().ForEach(pDB =>
            {
                ProyectoDTO p = new ProyectoDTO()
                {
                    Id = pDB.Id,
                    Nombre = pDB.Nombre,
                    FechaLimite = default
                };
                proyectos.Add(p);
            });

            return proyectos;
        }

        private List<ProyectoDTO> GetProjectsByJefeEquipoId(int id)
        {
            List<ProyectoDTO> proyectos = new List<ProyectoDTO>();

            db.Proyectos.ToList().ForEach(pDB =>
            {
                ProyectoDTO p = new ProyectoDTO()
                {
                    Id = pDB.Id,
                    Nombre = pDB.Nombre,
                    FechaLimite = default
                };
                proyectos.Add(p);
            });

            return proyectos;

        }

        private List<TipoTecnologiaDTO> GetTecnologias()
        {
            List<TipoTecnologiaDTO> tecnologias = new List<TipoTecnologiaDTO>();

            db.TiposTecnologia.ToList().ForEach(tDB =>
            {
                TipoTecnologiaDTO tDTO = new TipoTecnologiaDTO()
                {
                    Id = tDB.Id,
                    Nombre = tDB.Nombre
                };

                tecnologias.Add(tDTO);
            });
            return tecnologias;
        }

        private List<TipoTecnologiaDTO> GetTecnologiasByJefeEquipoDTO(JefeEquipoDTO jeDTO)
        {
            List<TipoTecnologiaDTO> tecnologias = new List<TipoTecnologiaDTO>();

            db.TiposTecnologia.ToList().ForEach(tDB =>
            {
                if (jeDTO.ListaTecnologias.Any(t => t.Id == tDB.Id))
                {
                    TipoTecnologiaDTO tDTO = new TipoTecnologiaDTO()
                    {
                        Id = tDB.Id,
                        Nombre = tDB.Nombre
                    };
                    tecnologias.Add(tDTO);
                }
            });
            return tecnologias;
        }

        private JefesEquipo MapearJefeEquipoDTOAJefesEquipo(JefeEquipoDTO jDTO, List<int> tecnologiasId, List<int> proyectosId)
        {

            JefesEquipo jDB = new JefesEquipo()
            {
                Tfno = jDTO.TfnoEmpresa,
                TrabajadoresDTecnico = new TrabajadoresDTecnico() {
                    AnyosExperiencia = jDTO.AnyosExp,
                    Trabajadores = new Trabajadores()
                    {
                        Nombre = jDTO.Nombre,
                        Apellidos = jDTO.Apellidos,
                        FechaNacimiento = jDTO.FechaNacimiento,
                        Direccion = jDTO.Direccion,
                        Dni = jDTO.Dni
                    }                  
                    
                    //TiposTecnologia = GenerarListaDeTecnologiasMedianteId(jDB, tecnologiasId),
                    //Proyectos = GenerarListaDeProyectosMedianteId(jDB, proyectosId) 
                }
            };
            jDB.TrabajadoresDTecnico.TiposTecnologia = new List<TiposTecnologia>();
            jDB.TrabajadoresDTecnico.TiposTecnologia = GenerarListaDeTecnologiasMedianteId(jDB, tecnologiasId);

            jDB.TrabajadoresDTecnico.Proyectos = new List<Proyectos>();
            jDB.TrabajadoresDTecnico.Proyectos = GenerarListaDeProyectosMedianteId(jDB, proyectosId);

            return jDB;
        }

        private List<TiposTecnologia> GenerarListaDeTecnologiasMedianteId(JefesEquipo jDB, List<int> tecnologiasId)
        {
            List<TiposTecnologia> ttListDB = jDB.TrabajadoresDTecnico.TiposTecnologia.ToList();

            db.TiposTecnologia.ToList().ForEach(ttDB =>
            {
                if (tecnologiasId.Contains(ttDB.Id))
                {
                    ttListDB.Add(ttDB);
                }
            });
            return ttListDB;
        }

        private List<Proyectos> GenerarListaDeProyectosMedianteId(JefesEquipo jDB, List<int> proyectosId)
        {
            List<Proyectos> pListDB = jDB.TrabajadoresDTecnico.Proyectos.ToList();

            db.Proyectos.ToList().ForEach(pDB =>
            {
                if (proyectosId.Contains(pDB.Id))
                {
                    pListDB.Add(pDB);
                }
            });
            return pListDB;
        }

        private JefesEquipo editarJefesEquipoDesdeUnJefeEquipoDTO(JefeEquipoDTO jDTO, List<int> tecnologiasId, List<int> proyectosId)
        {

            JefesEquipo jDB = db.JefesEquipo.Find(jDTO.Id);

            jDB.Tfno = jDTO.TfnoEmpresa;
            jDB.TrabajadoresDTecnico.AnyosExperiencia = jDTO.AnyosExp;
            jDB.TrabajadoresDTecnico.Trabajadores.Nombre = jDTO.Nombre;
            jDB.TrabajadoresDTecnico.Trabajadores.Apellidos = jDTO.Apellidos;
            jDB.TrabajadoresDTecnico.Trabajadores.FechaNacimiento = jDTO.FechaNacimiento;
            jDB.TrabajadoresDTecnico.Trabajadores.Direccion = jDTO.Direccion;
            jDB.TrabajadoresDTecnico.Trabajadores.Dni = jDTO.Dni;
            jDB.TrabajadoresDTecnico.TiposTecnologia.Clear();
            jDB.TrabajadoresDTecnico.TiposTecnologia = GenerarListaDeTecnologiasMedianteId(jDB, tecnologiasId);
            jDB.TrabajadoresDTecnico.Proyectos.Clear();
            jDB.TrabajadoresDTecnico.Proyectos = GenerarListaDeProyectosMedianteId(jDB, proyectosId);
            return jDB;
        }
    }
}
