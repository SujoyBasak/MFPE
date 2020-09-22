﻿using AuditSeverityModule.Models;
using AuditSeverityModule.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditSeverityModule.Providers
{
    public class SeverityProvider
    {
        ISeverity obj;
        public SeverityProvider(ISeverity _obj)
        {
            obj = _obj;
        }
        //Severity obj = new Severity();

        public AuditResponse SeverityResponse(AuditRequest Req)
        {
            if (Req == null)
                return null;
            try
            {
                var ls = obj.Response();
                if (ls == null)
                {
                    return null;
                }
                int count = 0, acceptableNo = 0;

                if (Req.Auditdetails.questions.Question1 == false)
                    count++;
                if (Req.Auditdetails.questions.Question2 == false)
                    count++;
                if (Req.Auditdetails.questions.Question3 == false)
                    count++;
                if (Req.Auditdetails.questions.Question4 == false)
                    count++;
                if (Req.Auditdetails.questions.Question5 == false)
                    count++;

                if (Req.Auditdetails.Type == ls[0].AuditType)
                    acceptableNo = ls[0].BenchmarkNoAnswers;
                else if (Req.Auditdetails.Type == ls[1].AuditType)
                    acceptableNo = ls[1].BenchmarkNoAnswers;
                else
                    return null;

                AuditResponse res = new AuditResponse();
                if (Req.Auditdetails.Type == "Internal" && count <= acceptableNo)
                {
                    res.AuditId = 1;
                    res.ProjectExexutionStatus = "GREEN";
                    res.RemedialActionDuration = "No Action Needed";
                }
                else if (Req.Auditdetails.Type == "Internal" && count > acceptableNo)
                {
                    res.AuditId = 1;
                    res.ProjectExexutionStatus = "RED";
                    res.RemedialActionDuration = "Action to be taken in 2 weeks";
                }
                else if (Req.Auditdetails.Type == "SOX" && count <= acceptableNo)
                {
                    res.AuditId = 1;
                    res.ProjectExexutionStatus = "GREEN";
                    res.RemedialActionDuration = "No Action Needed";
                }
                else if (Req.Auditdetails.Type == "SOX" && count > acceptableNo)
                {
                    res.AuditId = 1;
                    res.ProjectExexutionStatus = "RED";
                    res.RemedialActionDuration = "Action to be taken in 2 weeks";
                }


                return res;
            }
            catch(Exception)
            {
                return null;
            }
                  
        }
    }
}