using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AuditManagementPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AuditManagementPortal.Controllers
{
    public class ChecklistController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44344/api");   //Port No.
        HttpClient client;

        public ChecklistController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;

        }
        public List<ChecklistQuestions> Index(string auditType)      //Chnage
        {
            List<ChecklistQuestions> ls = new List<ChecklistQuestions>();

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/AuditChecklist/"+ auditType).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                ls = JsonConvert.DeserializeObject<List<ChecklistQuestions>>(data);
            }
            return ls;
        }
    }
}