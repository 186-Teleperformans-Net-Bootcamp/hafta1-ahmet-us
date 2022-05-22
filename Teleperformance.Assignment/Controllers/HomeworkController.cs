using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teleperformance.Assignment.Model;
using Newtonsoft;
using Microsoft.AspNetCore.JsonPatch;

namespace Teleperformance.Assignment.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class HomeworkController : ControllerBase
    {
        private static List<Homework> HomeworkList = new List<Homework>
     {
         new Homework
         {
             Id = 1,
             StudentName = "Ali",
             StudentLastName = "Demir",
             AssignmentWeek = 1,
             Result = 100,
         },
         new Homework
         {
             Id = 2,
             StudentName = "Deniz",
             StudentLastName = "Yildirim",
             AssignmentWeek = 1,
             Result = 90,
         },
         new Homework
         {
             Id = 3,
             StudentName = "Fatih",
             StudentLastName = "Seren",
             AssignmentWeek = 1,
             Result = 80,
         },
         new Homework
         {
             Id = 4,
             StudentName = "Seren",
             StudentLastName = "Kana",
             AssignmentWeek = 2,
             Result = 70,
         },

     };
        [HttpGet]

        public IActionResult GetAll()
        {
            return Ok(HomeworkList);
        }

        [HttpGet("assignmentWeek")]

        public IActionResult GetAll(int assignmentWeek)
        {
            var homework = HomeworkList.Where(a => a.AssignmentWeek == assignmentWeek).ToList();
            if (homework.Count <1)
            {
                return BadRequest();
            }
            return Ok(homework);
        }

        [HttpGet("studentDetails")]
        
        public IActionResult studentDetails(string firstName, string lastName)
        {
            var student = HomeworkList.Where(a => a.StudentName == firstName && a.StudentLastName == lastName).ToList();

            if(student.Count <1)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var homeworkId = HomeworkList.Find(a => a.Id == id);

            if(homeworkId == null)
            {
                return NotFound();
            }
            HomeworkList.Remove(homeworkId);
            return Ok();
        }

        [HttpPatch("/Homeworks/{id}")]

        public IActionResult updateHomeworkResult(int id, [FromBody] float reviewedResult)
        {
            var homeworkResult = HomeworkList.Find(a => a.Id == id);
            if (homeworkResult == null)
            {
                return NotFound();
            }
            homeworkResult.Result = reviewedResult;
            return Ok();
        }

        [HttpPost]

        public void Post([FromBody]Homework homework)
        {
            
            HomeworkList.Add(homework);
        }

        [HttpPut]

        public void Put([FromBody] Homework homework)
        {

            HomeworkList.Add(homework);
        }
    }
}
