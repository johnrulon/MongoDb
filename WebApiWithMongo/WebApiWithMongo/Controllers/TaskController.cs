namespace WebApiWithMongo.Controllers
{
    using System.Web.Http;

    using WebApiWithMongo.DataAccess;
    using WebApiWithMongo.Models;
    
    public class TaskController : ApiController
    {
        private TaskDataAccess dal = new TaskDataAccess();
        //
        // GET: /MyTask/
        public IHttpActionResult Get()
        {
            return this.Ok(this.dal.GetAllTasks());
        }

        //
        // POST: /MyTask/Create

        [System.Web.Mvc.HttpPost]
        public IHttpActionResult Create(MyTask task)
        {
            dal.CreateTask(task);
            return this.Ok();
        }
    }
}