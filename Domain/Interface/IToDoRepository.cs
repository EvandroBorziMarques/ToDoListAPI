using Domain.DTO;
using Domain.Entity;

namespace Domain.Interface
{
    public interface IToDoRepository
    {
        public bool ToDoCreate(ToDoDTO toDoDTO);
        public ToDo ToDoGetById(int id);
        public List<ToDo> ToDoList();
        public bool ToDoUpdate(int id, ToDoDTO toDoDTO);
        public bool ToDoDelete(int id);
    }
}
