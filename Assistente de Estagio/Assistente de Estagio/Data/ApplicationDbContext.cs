using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Assistente_de_Estagio.Models;

namespace Assistente_de_Estagio.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Documento> Documento { get; set; }
        public virtual DbSet<Ficharegistro> Ficharegistro { get; set; }
        public virtual DbSet<Jsonrequisitospreenchidos> Jsonrequisitospreenchidos { get; set; }
        public virtual DbSet<Requisitodedocumento> Requisitodedocumento { get; set; }
        public virtual DbSet<Requisitodeusuario> Requisitodeusuario { get; set; }
        public virtual DbSet<Requisitos> Requisitos { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server = sql141.main-hosting.eu;  user = u911430744_geren; password = FGJPWADS321123; database = u911430744_pedid");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => new { e.IdCurso, e.DocumentoIdDocumento });

                entity.ToTable("curso", "u911430744_pedid");

                entity.HasIndex(e => e.DocumentoIdDocumento)
                    .HasName("fk_curso_documento1_idx");

                entity.Property(e => e.IdCurso)
                    .HasColumnName("idCurso")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DocumentoIdDocumento)
                    .HasColumnName("documento_idDocumento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CoordenadorCurso)
                    .HasColumnName("coordenadorCurso")
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.DescricaoCurso)
                    .HasColumnName("descricaoCurso")
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.FaculdadeCurso)
                    .HasColumnName("faculdadeCurso")
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'FacisaBH'");

                entity.Property(e => e.NomeCurso)
                    .HasColumnName("nomeCurso")
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'Curso Padrão'");

                entity.HasOne(d => d.DocumentoIdDocumentoNavigation)
                    .WithMany(p => p.Curso)
                    .HasForeignKey(d => d.DocumentoIdDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_curso_documento1");
            });

            modelBuilder.Entity<Documento>(entity =>
            {
                entity.HasKey(e => e.IdDocumento);

                entity.ToTable("documento", "u911430744_pedid");

                entity.Property(e => e.IdDocumento)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.AutorDocumento)
                    .IsRequired()
                    .HasColumnName("autorDocumento")
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'FacisaBH'");

                entity.Property(e => e.CaminhoDocumento)
                    .IsRequired()
                    .HasColumnName("caminhoDocumento")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.CursoIdCurso)
                    .HasColumnName("Curso_idCurso")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DescricaoDocumento)
                    .IsRequired()
                    .HasColumnName("descricaoDocumento")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.PosicaoDocumento)
                    .HasColumnName("posicaoDocumento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PreenchimentoDocumento)
                    .IsRequired()
                    .HasColumnName("preenchimentoDocumento")
                    .IsUnicode(false);

                entity.Property(e => e.RequisitoDocumento)
                    .HasColumnName("requisitoDocumento")
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.TiposRequisitos)
                    .HasColumnName("tiposRequisitos")
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.TituloDocumento)
                    .IsRequired()
                    .HasColumnName("tituloDocumento")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ficharegistro>(entity =>
            {
                entity.HasKey(e => e.IdFichaRegistro);

                entity.ToTable("ficharegistro", "u911430744_pedid");

                entity.HasIndex(e => e.Data)
                    .HasName("Data_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Identificador)
                    .HasName("Identificador_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.UsuarioIdUsuario)
                    .HasName("usuario_IdUsuario_idx");

                entity.Property(e => e.IdFichaRegistro)
                    .HasColumnName("idFichaRegistro")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Atividades)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Classe)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'input-group'");

                entity.Property(e => e.IdUsuario).HasColumnType("int(11)");

                entity.Property(e => e.Identificador)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioIdUsuario)
                    .HasColumnName("usuario_IdUsuario")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Jsonrequisitospreenchidos>(entity =>
            {
                entity.HasKey(e => e.IdJsonRequisitosPreenchidos);

                entity.ToTable("jsonrequisitospreenchidos", "u911430744_pedid");

                entity.HasIndex(e => e.DocumentoIdDocumento)
                    .HasName("documento_IdDocumento_idx");

                entity.HasIndex(e => e.UsuarioIdUsuario)
                    .HasName("usuario_IdUsuario_idx");

                entity.Property(e => e.IdJsonRequisitosPreenchidos)
                    .HasColumnName("idJsonRequisitosPreenchidos")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DadosJson)
                    .IsRequired()
                    .HasColumnType("mediumtext");

                entity.Property(e => e.DocumentoIdDocumento)
                    .HasColumnName("documento_idDocumento")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.UsuarioIdUsuario)
                    .HasColumnName("usuario_idUsuario")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("NULL");

                entity.HasOne(d => d.DocumentoIdDocumentoNavigation)
                    .WithMany(p => p.Jsonrequisitospreenchidos)
                    .HasForeignKey(d => d.DocumentoIdDocumento)
                    .HasConstraintName("documento_IdDocumento");

                entity.HasOne(d => d.UsuarioIdUsuarioNavigation)
                    .WithMany(p => p.Jsonrequisitospreenchidos)
                    .HasForeignKey(d => d.UsuarioIdUsuario)
                    .HasConstraintName("usuario_IdUsuario");
            });

            modelBuilder.Entity<Requisitodedocumento>(entity =>
            {
                entity.HasKey(e => e.IdRequisitoDeDocumento);

                entity.ToTable("requisitodedocumento", "u911430744_pedid");

                entity.HasIndex(e => e.RequisitosIdRequisito)
                    .HasName("fk_requisitodedocumento_requisitos1_idx");

                entity.Property(e => e.IdRequisitoDeDocumento)
                    .HasColumnName("idRequisitoDeDocumento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DocumentoIdDocumento)
                    .HasColumnName("documento_idDocumento")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.OrdemRequisito)
                    .HasColumnName("ordemRequisito")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.RequisitosIdRequisito)
                    .HasColumnName("requisitos_idRequisito")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Requisitodeusuario>(entity =>
            {
                entity.HasKey(e => e.IdRequisitoDeUsuario);

                entity.ToTable("requisitodeusuario", "u911430744_pedid");

                entity.HasIndex(e => e.RequisitosIdRequisito)
                    .HasName("fk_requisitodeusuario_requisitos1_idx");

                entity.Property(e => e.IdRequisitoDeUsuario)
                    .HasColumnName("idRequisitoDeUsuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.OrdemRequisito)
                    .HasColumnName("ordemRequisito")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.RequisitosIdRequisito)
                    .HasColumnName("requisitos_idRequisito")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UsuarioIdUsuario)
                    .HasColumnName("usuario_idUsuario")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("NULL");
            });

            modelBuilder.Entity<Requisitos>(entity =>
            {
                entity.HasKey(e => e.IdRequisito);

                entity.ToTable("requisitos", "u911430744_pedid");

                entity.HasIndex(e => e.IdCampo)
                    .HasName("IdCampo")
                    .IsUnique();

                entity.HasIndex(e => e.NomeRequisito)
                    .HasName("NomeRequisito")
                    .IsUnique();

                entity.Property(e => e.IdRequisito)
                    .HasColumnName("idRequisito")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClassCampo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'input-group'");

                entity.Property(e => e.Dados)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.IdCampo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'EMPTY'");

                entity.Property(e => e.NomeRequisito)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Opcoes)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Tag)
                    .HasColumnName("tag")
                    .HasColumnType("enum('input','select','textarea')")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("usuario", "u911430744_pedid");

                entity.HasIndex(e => e.DocumentoIdDocumento)
                    .HasName("fk_Usuario_Documento1_idx");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.DataCriacaoUltimoDocumento)
                    .HasColumnName("dataCriacaoUltimoDocumento")
                    .HasColumnType("date")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.DocumentoIdDocumento)
                    .HasColumnName("Documento_idDocumento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EmailUsuario)
                    .HasColumnName("emailUsuario")
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.NomeUsuario)
                    .HasColumnName("nomeUsuario")
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Prioridade)
                    .IsRequired()
                    .HasColumnType("enum('1','2')")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.SenhaUsuario)
                    .HasColumnName("senhaUsuario")
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NULL");

                entity.HasOne(d => d.DocumentoIdDocumentoNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.DocumentoIdDocumento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Usuario_Documento1");
            });
        }
}
}
