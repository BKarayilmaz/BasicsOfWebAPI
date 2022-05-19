using System.Collections.Generic;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    //api/commands
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController: ControllerBase{
        private readonly ICommanderRepo _repository;

        public CommandsController(ICommanderRepo repository)//Dependency Injected Value
        {
         _repository=repository;   
        }
        //private readonly MockCommanderRepo _repository=new MockCommanderRepo();
        //Get api/commands
        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands(){
            var commandItems=_repository.GetAppCommands();
            return Ok(commandItems);    
        }
        //Get api/commands/id
        [HttpGet("{id}")]
        public ActionResult <Command> GetCommandById(int id){
            var commandItem=_repository.GetCommandById(id);
            return Ok(commandItem);
        }
    }
}