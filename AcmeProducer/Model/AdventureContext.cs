using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AcmeProducer.Model
{
    public partial class AdventureContext : DbContext
    {
        public AdventureContext()
        {
        }

        public AdventureContext(DbContextOptions<AdventureContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Fatura> Fatura { get; set; }
        public virtual DbSet<Instalacao> Instalacao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=exercicioApi;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("CLIENTE");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cpf).HasColumnName("CPF");

                entity.Property(e => e.DataNascimento)
                    .HasColumnName("DATA_NASCIMENTO")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdEndereco).HasColumnName("ID_ENDERECO");

                entity.Property(e => e.Nome).HasColumnName("NOME");

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.IdEndereco)
                    .HasConstraintName("FK_CLIENTE_ENDERECO");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.ToTable("ENDERECO");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bairro).HasColumnName("BAIRRO");

                entity.Property(e => e.Cidade).HasColumnName("CIDADE");

                entity.Property(e => e.Logradouro).HasColumnName("LOGRADOURO");

                entity.Property(e => e.Numero).HasColumnName("NUMERO");

                entity.Property(e => e.Uf)
                    .HasColumnName("UF")
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<Fatura>(entity =>
            {
                entity.ToTable("FATURA");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Codigo).HasColumnName("CODIGO");

                entity.Property(e => e.DataLeitura)
                    .HasColumnName("DATA_LEITURA")
                    .HasColumnType("datetime");

                entity.Property(e => e.DataVencimento)
                    .HasColumnName("DATA_VENCIMENTO")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdInstalacao).HasColumnName("ID_INSTALACAO");

                entity.Property(e => e.NumeroLeitura).HasColumnName("NUMERO_LEITURA");

                entity.Property(e => e.ValorConta)
                    .HasColumnName("VALOR_CONTA")
                    .HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdInstalacaoNavigation)
                    .WithMany(p => p.Fatura)
                    .HasForeignKey(d => d.IdInstalacao)
                    .HasConstraintName("FK_FATURA_INSTALACAO");
            });

            modelBuilder.Entity<Instalacao>(entity =>
            {
                entity.ToTable("INSTALACAO");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Codigo).HasColumnName("CODIGO");

                entity.Property(e => e.DataInstalacao)
                    .HasColumnName("DATA_INSTALACAO")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");

                entity.Property(e => e.IdEndereco).HasColumnName("ID_ENDERECO");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Instalacao)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_INSTALACAO_CLIENTE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
