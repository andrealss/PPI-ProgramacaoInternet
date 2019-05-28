﻿// <auto-generated />
using EstudoProva.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace EstudoProva.Migrations
{
    [DbContext(typeof(EstudoProvaContext))]
    [Migration("20190522195859_passo1")]
    partial class passo1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EstudoProva.Models.Aluno", b =>
                {
                    b.Property<string>("ra")
                        .HasMaxLength(18);

                    b.Property<string>("cpf")
                        .HasMaxLength(14);

                    b.Property<DateTime>("data_nasc");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("rg")
                        .HasMaxLength(14);

                    b.Property<string>("sexo")
                        .IsRequired();

                    b.HasKey("ra");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("EstudoProva.Models.Curso", b =>
                {
                    b.Property<int>("identificador")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("duracao_semestres");

                    b.Property<string>("nome")
                        .IsRequired();

                    b.HasKey("identificador");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("EstudoProva.Models.Disciplina", b =>
                {
                    b.Property<int>("identificador")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("identificador");

                    b.ToTable("Disciplina");
                });
#pragma warning restore 612, 618
        }
    }
}
