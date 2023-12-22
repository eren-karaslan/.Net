using hafta1.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace hafta1.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> Studentlist = new List<Student>
        {
            new Student
            {
                Age = 13,
                Name = "Ali",
                Score = 70,
                isSuccess = true,
            },
            new Student
            {
                Age = 11,
                Name = "Ayşe",
                Score = 40,
                isSuccess = false,
            },
            new Student
            {
                Age = 14,
                Name = "Veli",
                Score = 88,
                isSuccess = true,
            },
        };



        [HttpGet("Listeleme")]
        public IActionResult Listeleme()
        {
            return Ok(Studentlist);
        }

        [HttpGet("getByName")]
        public IActionResult GetByName([FromQuery] string name)
        {
            var finded_student = Studentlist.SingleOrDefault(s => s.Name == name);
            return Ok(finded_student);
        }

        [HttpGet("sortScore")]
        public IActionResult SortScore()
        {
            for (int i = 0; i < Studentlist.Count-1; i++)
            {
                if (Studentlist[i].Score > Studentlist[i + 1].Score)
                {
                    var lowerValue = Studentlist[i + 1];
                    Studentlist[i + 1] = Studentlist[i];
                    Studentlist[i] = lowerValue;
                }
            }
            return Ok(Studentlist);
        }


        [HttpPost("{name}")]
        public IActionResult Add(string name,[FromBody] Student student)
        {
            var student_old = Studentlist.SingleOrDefault(s => s.Name == name);
            if (student_old is null)
            {
                return BadRequest();
            }

            Studentlist.Add(student);
            return Ok();
        }



        [HttpPut("{name}")]
        public IActionResult Update(string name, [FromBody] Student student)
        {
            var student_old = Studentlist.SingleOrDefault(s => s.Name == name);
            if (student_old is null)
            {
                return BadRequest();
            }

            student_old.Name = student.Name;
            student_old.Age = student.Age;
            student_old.Age = student.Age;
            student_old.isSuccess = student.isSuccess;
            return Ok();
        }



        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            var student_old = Studentlist.SingleOrDefault(s => s.Name == name);
            if (student_old is null)
            {
                return BadRequest();
            }


            Studentlist.Remove(student_old);
            return Ok();
        }



        [HttpPatch("{name}")]
        public IActionResult ScoreUpdate(string name, [FromBody] double score)
        {
            var student_old = Studentlist.SingleOrDefault(s => s.Name == name);
            if (student_old is null)
            {
                return BadRequest();
            }

            student_old.Score = score;
            return Ok();
        }



        [HttpGet("PageNotFound")]
        public IActionResult PageNotFound()
        {
            return StatusCode(404);
        }

        [HttpGet("InternalServerError")]
        public IActionResult InternalServerError()
        {
            return StatusCode(500);
        }
    }
}
