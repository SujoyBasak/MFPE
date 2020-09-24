using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AuditManagementPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AuditManagementPortal.Controllers
{
    public class AuthorizationController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44311/api");   //Port No.
        HttpClient client;

        public AuthorizationController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;

        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Authenticate user)
        {
            string data = JsonConvert.SerializeObject(user);
            string Token = "";
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/Token/", content).Result;
            if (response.IsSuccessStatusCode)
            {
                Token = response.Content.ReadAsStringAsync().Result;
                return RedirectToAction("Home");

            }
            return View(Token);

        }
        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checklist(AuditDetail audittype)
        {
            ChecklistController con = new ChecklistController();
            List<ChecklistQuestions> ls = new List<ChecklistQuestions>();
            ls = con.Index(audittype.Type);

            return View(ls);
        }
        [HttpPost]
        public IActionResult AuditForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Severity(AuditRequest req)
        {
            if (req.Auditdetails.Type == "Internal")
                return RedirectToAction("Internal",req);
            else if (req.Auditdetails.Type == "SOX")
                return View();
            return View();

            
        }
        [HttpGet]
        public IActionResult Internal(AuditRequest req)
        {
            return View();
        }
        [HttpPost]
        public IActionResult AuditResponseView(InternalQuestions questions)
        {   
            SeverityController con = new SeverityController();
            AuditResponse ls = new AuditResponse();
            ls = con.Index(questions);

            return View(ls);
            
        }
    }
}