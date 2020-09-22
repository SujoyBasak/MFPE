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
        private readonly IChecklist obj;
        public ChecklistProvider(IChecklist _obj)
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

                if (list != null)
                    return list;
                else
                    return null;
            }
            catch(Exception)
            {
                return null;
            }
            
            
        }
    }
}
