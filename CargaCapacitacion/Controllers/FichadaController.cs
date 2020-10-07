using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CargaCapacitacion.Models;
using CargaCapacitacion.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CargaCapacitacion.Controllers
{
    [AllowAnonymous]
    public class FichadaController : Controller
    {
        private readonly CapacitacionContext _capacitacionDb;
        private readonly MaestrosContext _maestrosDb;
        public UserSession usuario;
            

        public FichadaController(CapacitacionContext capacitacionDb, MaestrosContext maestrosDb)
        {
            _capacitacionDb = capacitacionDb;
            _maestrosDb = maestrosDb;
        }

        [HttpGet]
        public IActionResult Index()
        {
            usuario = GetUserSession();
            ViewBag.usuario = usuario.Name;
            GetUserLocation();
            ViewBag.rol = usuario.Lugar;
            if(usuario.Lugar != "")
            {
                FichadaViewModel model = new FichadaViewModel();
                model.Usuario = usuario.Name;

                List<HHRR> empleados = new List<HHRR>();

                if (usuario.Lugar != "ALL"  )
                {
                    empleados = _maestrosDb.HHRR.Where(e => e.DESCRIPCION_LOCAL == usuario.Lugar).ToList();
                }
                else
                {
                    empleados = _maestrosDb.HHRR.ToList();
                }

                foreach (var emp in empleados)
                {
                    EmpleadoViewModel empleado = new EmpleadoViewModel();
                    empleado.Legajo = emp.LEGAJO;
                    empleado.Nombre = emp.NOMBRE;
                    empleado.Apellido = emp.APELLIDO;
                    empleado.IsChecked = false;
                    model.Empleados.Add(empleado);
                }

                var cursos = _capacitacionDb.Cursos.ToList();
                var cursosHabilitados = new List<Curso>();

                foreach (var cur in cursos)
                {
                    if (cur.FechaInicio.Year == DateTime.Today.Year || cur.FechaFin.Year == DateTime.Today.Year)
                    {
                        CursoViewModel curso = new CursoViewModel();
                        curso.Id = cur.Id;
                        curso.Curso = cur.Titulo;
                        curso.FechaInicio = cur.FechaInicio;
                        curso.FechaFin = cur.FechaFin;
                        model.Cursos.Add(curso);
                    }
                }

                ViewBag.FechaHoy = DateTime.Today;
        
                return View(model);
            }

            return View();
        }

        [HttpPost]
        [Obsolete]
        public IActionResult PostFichada([FromBody] CreateFichadaViewModel model)
        {
            var fecha = model.Fecha.ToString();
            foreach (var item in model.Usuarios)
            {
                _capacitacionDb.Database.ExecuteSqlCommand("SP_CARGA_MANUAL @Legajo, @Curso, @Fecha", new SqlParameter("@Legajo", item), new SqlParameter("@Curso", model.Curso), new SqlParameter("@Fecha", fecha));
            }
            return RedirectToAction("Index", "Fichada");
            //return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Create() 
        {
            var userId = this.User.Identity.Name;

            ViewBag.userId = userId;
            FichadaViewModel model = new FichadaViewModel();
            model.Usuario = Global.GetUserSesion();
            ViewBag.usuario = model.Usuario;
            //Harcodeo usuario // no funciona deployado, trae: CargaCapacitacion // login?
            var user = "AR03345051";
            usuario = new UserSession();
            usuario.Legajo = model.Usuario;
            model.Usuario = user; // Borrar en productivo
            if (model.Usuario == "AR03345051" || model.Usuario == "AR01355912")
            {
                usuario.Lugar = "MONTE GRANDE";
            }
            else if (model.Usuario == "AR03881587")
            {
                usuario.Lugar = "PLANTA ALCORTA";
            }
            else if (model.Usuario == "AR01001748" || model.Usuario == "AR015563275")
            {
                usuario.Lugar = "PARRAL";
            }
            else if (model.Usuario == "AR01016107" || model.Usuario == "AR03590695")
            {
                usuario.Lugar = "LOMA HERMOSA";
            }
            else if (model.Usuario == "AR03352615")
            {
                usuario.Lugar = "ADM.CENTRAL";
            }
            else if (model.Usuario == "AR01681565" || model.Usuario == "AR00024685")
            {
                usuario.Lugar = "U. O. OESTE";
            }
            else if (model.Usuario == "AR03559888" || model.Usuario == "AR03084017")
            {
                usuario.Lugar = "ROCA/SERVET";
            }
            else if (model.Usuario == "AR03770054")
            {
                usuario.Lugar = "";
            }
            
            var empleados = await _maestrosDb.HHRR.Where(e=> e.DESCRIPCION_LOCAL == usuario.Lugar).ToListAsync();
            foreach(var emp in empleados)
            {
                EmpleadoViewModel empleado = new EmpleadoViewModel();
                empleado.Legajo = emp.LEGAJO;
                empleado.Nombre = emp.NOMBRE;
                empleado.Apellido = emp.APELLIDO;
                empleado.IsChecked = false;
                model.Empleados.Add(empleado);
            }

            var cursos = await _capacitacionDb.Cursos.ToListAsync();
            var cursosHabilitados = new List<Curso>();

            foreach(var cur in cursos)
            {
                
                if(cur.FechaInicio.Year == DateTime.Today.Year || cur.FechaFin.Year == DateTime.Today.Year)
                {
                    CursoViewModel curso = new CursoViewModel();
                    curso.Id = cur.Id;
                    curso.Curso = cur.Titulo;
                    curso.FechaInicio = cur.FechaInicio;
                    curso.FechaFin = cur.FechaFin;
                    model.Cursos.Add(curso);
                }
            }
            
            ViewBag.FechaHoy = DateTime.Today;
            if (usuario.Lugar == "" || usuario.Lugar == null)
            {
                var empleadosT = await _maestrosDb.HHRR.ToListAsync();
                foreach (var emp in empleadosT)
                {
                    EmpleadoViewModel empleado = new EmpleadoViewModel();
                    empleado.Legajo = emp.LEGAJO;
                    empleado.Nombre = emp.NOMBRE;
                    empleado.Apellido = emp.APELLIDO;
                    empleado.IsChecked = false;
                    model.Empleados.Add(empleado);
                }
            }
            
            return View(model);
        }

        public UserSession GetUserSession()
        {
            var userId = this.User.Identity.Name.ToUpper();
            if (userId == "DESKTOP-U3KKVUL\\SILVE" || userId.ToUpper() == "SA\\TARTGVVTEDES") // PARA PROBAR EN MAQUINAS DEV
            {
                //userId = "SA\\AR03770054"; //all
                userId = "SA\\AR03345051"; //monte grande
            }
            string legajo;
            var userName = userId.Split('\\');
            if (userName.Length > 1)
            {
                legajo = userName[1];
                legajo = legajo.Remove(0, 2);
            }
            else
            {
                legajo = userName[0];
            }

            UserSession userSession = new UserSession();

            var user = _maestrosDb.HHRR.Where(u => u.LEGAJO == legajo).FirstOrDefault();

            if (user != null)
            {
                userSession.Legajo = user.LEGAJO;
                userSession.Name = user.APELLIDO + ", " + user.NOMBRE;
            }

            return userSession;
        }

        public void GetUserLocation()
        {
            switch (usuario.Legajo)
            {
                case "03345051": case "01355912":
                    usuario.Lugar = "MONTE GRANDE";
                    break;
                case "03881587": case "00025061": case "00025109":
                    usuario.Lugar = "PLANTA ALCORTA";
                    break;
                case "03559888": case "03084017":
                    usuario.Lugar = "ROCA/SERVET";
                    break;
                case "01001748": case "015563275":
                    usuario.Lugar = "PARRAL";
                    break;
                case "01016107": case "03590695":
                    usuario.Lugar = "LOMA HERMOSA";
                    break;
                case "03352615":
                    usuario.Lugar = "ADM.CENTRAL";
                    break;
                case "01681565": case "00024685":
                    usuario.Lugar = "U. O. OESTE";
                    break;
                case "03770054":
                    usuario.Lugar = "ALL";
                    break;
                default:
                    usuario.Lugar = "";
                    break;
            }
        }
    }
}