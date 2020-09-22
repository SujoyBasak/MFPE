using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditChecklistModule.Models;
using AuditChecklistModule.Providers;
using AuditChecklistModule.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuditChecklistModule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditChecklistController : ControllerBase
    {
        private readonly ChecklistProvider obj;
        readonly log4net.ILog _log4net;
                 
        public AuditChecklistController(ChecklistProvider _obj)
        {
            obj = _obj;
            _log4net = log4net.LogManager.GetLogger(typeof(AuditChecklistController));
        }

        // GET: api/AuditChecklist
        [HttpGet("{auditType}")]
        public IActionResult Get(string auditType)
        {
            _log4net.Info(" AuditChecklistController Http GET request called");
            if (string.IsNullOrEmpty(auditType))
                return BadRequest("No Input");
            try
            {
                //ChecklistProvider obj = new ChecklistProvider();

                var list = obj.QuestionsProvider(auditType);

                if (list != null)
                    return Ok(list);
                else
                    return BadRequest("Wrong Input");
            }
            catch(Exception)
            {
                _log4net.Info("Exception from AuditChecklist");
                return StatusCode(500);
            }
            
            

            
        }        
    }
}
