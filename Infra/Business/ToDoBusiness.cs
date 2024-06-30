using Dapper;
using Domain.DTO;
using Domain.Entity;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Business
{
    public class ToDoBusiness : IToDo
    {
        private readonly IToDoRepository _toDoRepository;

        public ToDoBusiness(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public bool ToDoCreate(ToDoDTO toDoDTO)
        {
            bool response = _toDoRepository.ToDoCreate(toDoDTO);
            return response;
        }

        public List<ToDo> ToDoList()
        {
            List<ToDo> toDo = _toDoRepository.ToDoList();
            return toDo;
        }

        public ToDo ToDoGetById(int id)
        {
            ToDo toDo = _toDoRepository.ToDoGetById(id);
            return toDo;
        }

        public bool ToDoUpdate(int id, ToDoDTO toDoDTO)
        {
            bool response = _toDoRepository.ToDoUpdate(id, toDoDTO);
            return response;
        }

        public bool ToDoDelete(int id)
        {
            bool response = _toDoRepository.ToDoDelete(id);
            return response;
        }

    }
}
