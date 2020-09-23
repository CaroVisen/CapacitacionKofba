using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CargaCapacitacion.Models;
using CargaCapacitacion.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CargaCapacitacion.Controllers
{
    public class FichadaController : Controller
    {
            private readonly CapacitacionContext _contextC;
            private readonly MaestrosContext _contextM;
            public UserSession usuario;
            

        public FichadaController(CapacitacionContext contextc, MaestrosContext contextm)
        {
                _contextC = contextc;
                _contextM = contextm;
        }
            

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Create() 
        {
            FichadaPantallaViewModel model = new FichadaPantallaViewModel();
            model.Usuario = Global.GetUserSesion();
            ViewBag.usuario = model.Usuario;
            //Harcodeo usuario
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
            
            var empleados = await _contextM.HHRR.Where(e=> e.DESCRIPCION_LOCAL == usuario.Lugar).ToListAsync();
            foreach(var emp in empleados)
            {
                EmpleadoViewModel empleado = new EmpleadoViewModel();
                empleado.Legajo = emp.LEGAJO;
                empleado.Nombre = emp.NOMBRE;
                empleado.Apellido = emp.APELLIDO;
                empleado.IsChecked = false;
                model.Empleados.Add(empleado);
            }

            var cursos = await _contextC.Cursos.ToListAsync();
            var cursosHabilitados = new List<Curso>();

            foreach(var cur in cursos)
            {
                CursoViewModel curso = new CursoViewModel();
                curso.Id = cur.Id;
                curso.Curso = cur.Titulo;
                curso.FechaInicio = cur.FechaInicio;
                curso.FechaFin = cur.FechaFin;
                if(cur.FechaInicio <= DateTime.Today && cur.FechaFin>= DateTime.Today)
                {
                    model.Cursos.Add(curso);
                }
            }

            if (usuario.Lugar == "" || usuario.Lugar == null)
            {
                foreach(var emp in empleados)
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


        [HttpPost]
        public ActionResult Create(FichadaPantallaViewModel modelo) 
        {
            FichadaSPViewModel fichada = new FichadaSPViewModel();
            foreach (var emp in modelo.Empleados) {
                if (emp.IsChecked)
                {
                    fichada.Legajo = emp.Legajo;
                    fichada.Fecha = modelo.Fecha;
                    fichada.Curso = modelo.Curso;
                }
                //mando al sp
            }
            //clsDAO.SqlExec();
            return View();
        }
    }
}