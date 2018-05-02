using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AngularSample.Models;

namespace AngularSample.api
{
    // Route  
    [RoutePrefix("/api/Student")]
    public class StudentController : ApiController
    {
        // StudentDBEntities object point 
        StudentDBEntities dbContext = null;
        // Constructor  
        public StudentController()
        {
            // create instance of an object 
            dbContext = new StudentDBEntities();
        }
        [ResponseType(typeof(tblStudent))]
        [HttpPost]
        public HttpResponseMessage SaveStudent(tblStudent astudent)
        {
            int result = 0;
            try
            {
                dbContext.tblStudents.Add(astudent);
                dbContext.SaveChanges();
                result = 1;
            }
            catch (Exception e)
            {

                result = 0;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
