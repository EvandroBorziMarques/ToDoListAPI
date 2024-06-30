using Dapper;
using Domain.DTO;
using Domain.Entity;
using Domain.Interface;

namespace Infra.Repositories.ToDoRepository
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly IBaseRepository _baseRepository;

        public ToDoRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public bool ToDoCreate(ToDoDTO toDoDTO)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Note", toDoDTO.Note);
            parameters.Add("Concluded", toDoDTO.Concluded);

            return _baseRepository.Execute("ToDoCreate", parameters);
        }

        public ToDo ToDoGetById(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("ID", id);

            return _baseRepository.QueryFirst<ToDo>("ToDoGetById", parameters);
        }

        public List<ToDo> ToDoList()
        {
            DynamicParameters parameters = new DynamicParameters();
            return _baseRepository.Query<ToDo>("ToDoList", parameters);
        }

        public bool ToDoUpdate(int id, ToDoDTO toDoDTO)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("ID", id);
            parameters.Add("Note", toDoDTO.Note);
            parameters.Add("Concluded", toDoDTO.Concluded);

            return _baseRepository.Execute("ToDoUpdate", parameters);
        }

        public bool ToDoDelete(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("id", id);

            return _baseRepository.Execute("ToDoDelete", parameters);
        }
    }
}
