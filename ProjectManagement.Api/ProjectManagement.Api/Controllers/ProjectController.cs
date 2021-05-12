using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data.Interfaces;
using ProjectManagement.Entities;

namespace ProjectManagement.Api.Controllers
{
    [ApiController]
    [EnableCors]
    [Route("api/Project")]
    public class ProjectController : BaseController<Project>
    {
        public ProjectController(IBaseRepository<Project> repository) : base(repository)
        {
        }
    }
}
