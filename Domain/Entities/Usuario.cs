
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Usuario
    {
        public int Id;
        
        public ICollection<Tarefa> tarefas;
        public ICollection<dynamic> historico;
    }
}
