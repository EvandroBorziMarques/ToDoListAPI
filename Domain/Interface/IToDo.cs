using Domain.DTO;
using Domain.Entity;

namespace Domain.Interface
{
    public interface IToDo
    {
        bool ToDoCreate(ToDoDTO toDoDTO);
        List<ToDo> ToDoList();
        ToDo ToDoGetById(int id);
        bool ToDoUpdate(ToDo toDo);
        bool ToDoDelete(int id);
    }
}
