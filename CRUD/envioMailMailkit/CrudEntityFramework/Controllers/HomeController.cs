using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CrudEntityFramework.Models;
using CrudEntityFramework.Data;
using Microsoft.EntityFrameworkCore;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;

namespace CrudEntityFramework.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ////Para envío de correo
            //var mensaje = new MimeMessage();
            //mensaje.From.Add(new MailboxAddress("Test envio email", "joseandresmont@gmail.com.co"));
            //mensaje.To.Add(new MailboxAddress("Test enviado", "joseandresmontoya@hotmail.com"));
            //mensaje.Subject = "Test email asp.net core";
            //mensaje.Body = new TextPart("plain")
            //{
            //    Text = "Hola saludo desde asp.net core"
            //};

            //using (var cliente = new SmtpClient())
            //{
            //    cliente.Connect("smtp.gmail.com", 465);
            //    cliente.Authenticate("joseandresmonto@gmail.com", "elite8359*");
            //    cliente.Send(mensaje);
            //    cliente.Disconnect(true);
            //}

              return View(await _context.Usuario.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuario.Add(usuario);
                await _context.SaveChangesAsync();

                ////Para envío de correo
                var mensaje = new MimeMessage();
                mensaje.From.Add(new MailboxAddress("Test envio email", "joseandresmont@gmail.com.co"));
                mensaje.To.Add(new MailboxAddress("Test enviado", "joseandresmontoya@hotmail.com"));
                mensaje.Subject = "Test email asp.net core";
                mensaje.Body = new TextPart("plain")
                {
                    Text = "Hola saludo desde asp.net core"
                };

                using (var cliente = new SmtpClient())
                {
                    cliente.Connect("smtp.gmail.com", 465);
                    cliente.Authenticate("joseandresmonto@gmail.com", "elite8359*");
                    cliente.Send(mensaje);
                    cliente.Disconnect(true);
                }

                return RedirectToAction(nameof(Index));
            }

            return View();
        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = _context.Usuario.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Update(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(usuario);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = _context.Usuario.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = _context.Usuario.Find(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRegistro(int? id)
        {
            var usuario = await _context.Usuario.FindAsync(id);

            if(usuario == null)
            {
                return View();
            }
           
            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));           
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
