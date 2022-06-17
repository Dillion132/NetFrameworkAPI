using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using NetFrameworkAPI.Data;
using NetFrameworkAPI.Models;

namespace NetFrameworkAPI.Controllers
{
    public class TodoController : ApiController
    {
        private NetFrameworkAPIContext db = new NetFrameworkAPIContext();

        // GET: api/Todo
        public IQueryable<TodoModel> GetTodoModels()
        {
            return db.TodoModels;
        }

        // GET: api/Todo/5
        [ResponseType(typeof(TodoModel))]
        public IHttpActionResult GetTodoModel(int id)
        {
            TodoModel todoModel = db.TodoModels.Find(id);
            if (todoModel == null)
            {
                return NotFound();
            }

            return Ok(todoModel);
        }

        // PUT: api/Todo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTodoModel(int id, TodoModel todoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != todoModel.TodoId)
            {
                return BadRequest();
            }

            db.Entry(todoModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Todo
        [ResponseType(typeof(TodoModel))]
        public IHttpActionResult PostTodoModel(TodoModel todoModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TodoModels.Add(todoModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = todoModel.TodoId }, todoModel);
        }

        // DELETE: api/Todo/5
        [ResponseType(typeof(TodoModel))]
        public IHttpActionResult DeleteTodoModel(int id)
        {
            TodoModel todoModel = db.TodoModels.Find(id);
            if (todoModel == null)
            {
                return NotFound();
            }

            db.TodoModels.Remove(todoModel);
            db.SaveChanges();

            return Ok(todoModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TodoModelExists(int id)
        {
            return db.TodoModels.Count(e => e.TodoId == id) > 0;
        }
    }
}