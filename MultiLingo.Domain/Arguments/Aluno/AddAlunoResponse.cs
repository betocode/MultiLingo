namespace MultiLingo.Domain.Arguments.Aluno
{
    public class AddAlunoResponse
    {
        public string Nome { get; set; }
        public string Matricula { get; set; }

        public static explicit operator AddAlunoResponse(Entities.Aluno aluno)
        {
            return new AddAlunoResponse { Nome = aluno.Nome, Matricula = aluno.Matricula };
        }
    }
}
