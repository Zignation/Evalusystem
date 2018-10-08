using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace DAL
{
    public class EvalContext : DbContext
    {
        // database mapping to class models

        public DbSet<Course> Course { get; set; }

        public DbSet<Evaluation> Evaluation { get; set; }

        public DbSet<Questionnaire> Questionnaire { get; set; }

        public DbSet<Question> Question { get; set; }

        public DbSet<QuestionOption> Question_Option { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseMySql(
                "server=localhost;" +
                "database=evaluation;" +
                "uid=root;" +
                "pwd=root;"

            );
        }

        // f�r modellerne i EF er lavet kan vi override nogle selvdefinerede regler mm.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite key defineres her
            //modelBuilder.Entity<Tags>().HasKey(t => new { t.post_id, t.tag });

        }

    }
}

