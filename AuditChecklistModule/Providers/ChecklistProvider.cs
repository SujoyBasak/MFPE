using AuditChecklistModule.Models;
using AuditChecklistModule.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditChecklistModule.Providers
{
    public class ChecklistProvider
    {
        private readonly IChecklistRepo obj;
        public ChecklistProvider(IChecklistRepo _obj)
        {
            obj = _obj;
        }
        //Checklist obj = new Checklist();

       /// <summary>
       /// 
       /// </summary>
       /// <param name="type"></param>
       /// <returns></returns>
        public List<Questions> QuestionsProvider(string type)
        {
            if (string.IsNullOrEmpty(type))
                return null;
            try
            {
                var list = obj.GetQuestions(type);
                return list;
            }
            catch(Exception)
            {
                return null;
            }
            
            
        }
    }
}
