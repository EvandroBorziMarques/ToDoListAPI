using AutoMapper;
using Domain.DTO;
using Domain.Entity;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IToDo _toDo;

        public ToDoController(IMapper mapper, IToDo toDo)
        {
            _mapper = mapper;
            _toDo = toDo;
        }

        /// <summary>
        /// Create new To Do
        /// </summary>
        /// <returns></returns>
        [HttpPost("create")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ToDoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ToDoDTO> ToDoListCreate([FromBody] ToDoDTO toDoDTO)
        {
            try
            {
                bool response = _toDo.ToDoCreate(toDoDTO);
                return response ? Created(string.Empty, "Created Successfuly") : BadRequest("Error: to do not created!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error to process the request. {ex.Message}");
            }
        }

        /// <summary>
        /// Get list of to do
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ToDoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ToDoDTO> ToDoList()
        {
            try
            {
                List<ToDo> toDo = _toDo.ToDoList();
                return Ok(_mapper.Map<List<ToDo>>(toDo));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error to process the request. {ex.Message}");
            }
        }

        /// <summary>
        /// Get to do by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ToDoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ToDoDTO> ToDoGetById(int id)
        {
            try
            {
                ToDo toDo = _toDo.ToDoGetById(id);
                return Ok(_mapper.Map<ToDoDTO>(toDo));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error to process the request. {ex.Message}");
            }
        }

        /// <summary>
        /// Update information of the to do
        /// </summary>
        /// <param name="toDo"></param>
        /// <returns></returns>
        [HttpPut("update")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ToDo), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ToDoDTO> ToDoUpdate([FromBody] ToDo toDo)
        {
            try
            {
                bool response = _toDo.ToDoUpdate(toDo);

                return response ? Ok("Updated Successfuly!") : BadRequest("Error: to do not found!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error to process the request. {ex.Message}");
            }
        }

        /// <summary>
        /// Delete to do
        /// </summary>
        /// <param name="id"></param>
        /// <param name="toDoDTO"></param>
        /// <returns></returns>
        [HttpDelete("delete/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<bool> ToDoDelete(int id)
        {
            try
            {
                bool response = _toDo.ToDoDelete(id);
                return response ? Ok("Deleted Successfuly!") : BadRequest("Error: to do not deleted!.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error to process the request. {ex.Message}");
            }
        }
    }
}
