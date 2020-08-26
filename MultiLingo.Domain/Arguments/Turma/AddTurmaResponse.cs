namespace MultiLingo.Domain.Arguments.Turma
{
    public class AddTurmaResponse
    {
        public string Nome {get;set;}
        public static explicit operator AddTurmaResponse(Entities.Turma turma)
        {
            return new AddTurmaResponse { Nome = turma.Nome };
        }
    }
}
