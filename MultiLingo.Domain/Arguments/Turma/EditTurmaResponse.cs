namespace MultiLingo.Domain.Arguments.Turma
{
    public class EditTurmaResponse
    {
        public string Nome { get; set; }

        public static explicit operator EditTurmaResponse(Entities.Turma turma)
        {
            return new EditTurmaResponse { Nome = turma.Nome };
        }
    }
}
