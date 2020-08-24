using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MultiLingo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiLingo.Infra.Persistence
{
    public class MultiLingoContext : DbContext
    {
        public MultiLingoContext(DbContextOptions<MultiLingoContext> options) : base(options)
        {
          

        }

    

      protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // equivalent of modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                entityType.Relational().TableName = entityType.DisplayName();
               

                // equivalent of modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                // and modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }
          
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AlunoTurma>().HasKey(at => new { at.IdAluno, at.IdTurma });
            modelBuilder.Entity<AlunoTurma>().HasOne(a => a.Aluno).WithMany(at => at.Turmas).HasForeignKey(a => a.IdAluno);
            modelBuilder.Entity<AlunoTurma>().HasOne(t=> t.Turma).WithMany(at => at.Alunos).HasForeignKey(t=>t.IdTurma);

        }


        // #entities
        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Turma> Turma { get; set; }

    }
}
