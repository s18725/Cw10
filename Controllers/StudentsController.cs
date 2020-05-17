﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw5.Models;
using Cw5.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cw5.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentDbServices _db;

        public StudentsController(IStudentDbServices db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            var response = _db.GetStudents();
            return response;
        }

         [HttpGet("secured/{id}")]
        public IActionResult GetStudent(string id)
        {
            if (_db.GetStudent(id) != null)
            {
                return Ok(_db.GetStudent(id));
            }

            return NotFound("Nie znaleziono studenta");
        }
        [HttpPut("update")]
        public IActionResult updatestudent(Student student) {
            var res=_db.UpdateStudent(student);
            return Ok(res);
        }
        [HttpDelete("delete")]
        public IActionResult deletestudent(Student student) {
            var res = _db.DeleteStudent(student);
            if (res == null) 
            {
                return BadRequest("Podano null lub student nie istnieje");
            }
            return Ok(res);
        }
        
    }
}
