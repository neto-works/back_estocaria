using EstocariaNet.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EstocariaNet.Shared.Context
{
    public class AppDbContext : IdentityDbContext<AplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Estoque>? Estoques { get; set; }
        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<Produto>? Produtos { get; set; }
        public DbSet<Admin>? Admins { get; set; }
        public DbSet<Estoquista>? Estoquistas { get; set; }
        public DbSet<Lancamento>? Lancamentos { get; set; }
        public DbSet<Relatorio>? Relatorios { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Configuração adicional de chaves estrangeiras, índices, etc.
            builder.Entity<Estoquista>().HasOne(e => e.AplicationUser).WithMany().HasForeignKey(e => e.AplicationUserEstoquistaId).OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Estoquista>().HasOne(e => e.Estoque).WithMany().HasForeignKey(e => e.EstoquistaEstoqueId).OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Admin>().HasOne(a => a.AplicationUser).WithMany().HasForeignKey(a => a.AplicationUserAdminId).OnDelete(DeleteBehavior.Cascade);

            // Insert data (seed data)
            this.InsertInto(builder);

        }

        private void InsertInto(ModelBuilder builder)
        {
            DateTime dataAtual = DateTime.Now;

            // Usuario
            builder.Entity<AplicationUser>().HasData(
                new AplicationUser
                {
                    Id = "usuarioEstoquistaRaiz",
                    RefreshToken = null,
                    RefreshTokenExpiryTime = DateTime.Parse("2045-12-02"),
                    TipoUsuario = 0,
                    AdminId = null,
                    EstoquistaId = null,
                    UserName = "Estoquista",
                    NormalizedUserName = "ESTOQUISTA",
                    Email = "estoquista@gmail.com",
                    NormalizedEmail = "ESTOQUISTA@GMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = "",
                    SecurityStamp = null,
                    ConcurrencyStamp = null,
                    PhoneNumber = "9981998199",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnd = DateTime.Parse("2045-12-02"),
                    LockoutEnabled = false,
                    AccessFailedCount = 0
                },
                new AplicationUser
                {
                    Id = "usuarioAdminRaiz",
                    RefreshToken = null,
                    RefreshTokenExpiryTime = DateTime.Parse("2045-12-02"),
                    TipoUsuario = 0,
                    AdminId = null,
                    EstoquistaId = null,
                    UserName = "Admin",
                    NormalizedUserName = "ADMIN",
                    Email = "Admins@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = "",
                    SecurityStamp = null,
                    ConcurrencyStamp = null,
                    PhoneNumber = "9981998199",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnd = DateTime.Parse("2045-12-02"),
                    LockoutEnabled = false,
                    AccessFailedCount = 0
                }
            );
            // admin
            builder.Entity<Admin>().HasData(
                new Admin { AdminId = "AdminId", Setor = "Vargas" }
            );

            // Estoquista
            builder.Entity<Estoquista>().HasData(
                new Estoquista
                {
                    EstoquistaId = "EstoquistaIdRaiz",
                    Cpf = "11800909862",
                    Celular = "567456546",
                    DataInicio = dataAtual
                }
            );

            // Estoque
            builder.Entity<Estoque>().HasData(
                new Estoque
                {
                    EstoqueId = 1,
                    Nome = "EST - Comestíveis SA",
                    Local = "Vale dos cangurus",
                    Capacidade = 1150.5f,
                    DataCriacao = dataAtual,
                    EstoqueAdminId = null
                },
                new Estoque
                {
                    EstoqueId = 2,
                    Nome = "EST - Prod Limpeza SA",
                    Local = "Vale dos cangurus",
                    Capacidade = 1650.5f,
                    DataCriacao = dataAtual,
                    EstoqueAdminId = null
                }
            );

            // Categorias
            builder.Entity<Categoria>().HasData(
                new Categoria { CategoriaId = 1, Nome = "Grãos" },
                new Categoria { CategoriaId = 2, Nome = "Em pó" }
            );

            //Produtos
            builder.Entity<Produto>().HasData(
            new Produto
            {
                ProdutoId = 1,
                Nome = "Arroz Integral",
                Descricao = "É o arroz descascado",
                Preco = 6.4m,
                ImagemUrl = "algumaimagem.png",
                QuantEstoqueMin = 0.0f,
                QuantEstoqueMax = 250.0f,
                Saldo = 0,
                DataCadastro = dataAtual,
                CategoriaId = 1,
                EstoqueId = 1
            },
            new Produto
            {
                ProdutoId = 2,
                Nome = "Feijão carioca",
                Descricao = "Variedade do feijão comum",
                Preco = 6.4m,
                ImagemUrl = "algumaimagem.png",
                QuantEstoqueMin = 0.0f,
                QuantEstoqueMax = 250.0f,
                Saldo = 0,
                DataCadastro = dataAtual,
                CategoriaId = 1,
                EstoqueId = 1
            },
            new Produto
            {
                ProdutoId = 3,
                Nome = "Farinha Granfind",
                Descricao = "Farinha de mandioca",
                Preco = 6.4m,
                ImagemUrl = "algumaimagem.png",
                QuantEstoqueMin = 0.0f,
                QuantEstoqueMax = 250.0f,
                Saldo = 0,
                DataCadastro = dataAtual,
                CategoriaId = 2,
                EstoqueId = 1
            },
            new Produto
            {
                ProdutoId = 4,
                Nome = "Café Itans",
                Descricao = "Café produzido em Caicó",
                Preco = 6.4m,
                ImagemUrl = "algumaimagem.png",
                QuantEstoqueMin = 0.0f,
                QuantEstoqueMax = 250.0f,
                Saldo = 0,
                DataCadastro = dataAtual,
                CategoriaId = 2,
                EstoqueId = 1
            },
            new Produto
            {
                ProdutoId = 5,
                Nome = "Açúcar Cristal",
                Descricao = "Açúcar refinado e cristalino",
                Preco = 6.4m,
                ImagemUrl = "algumaimagem.png",
                QuantEstoqueMin = 0.0f,
                QuantEstoqueMax = 250.0f,
                Saldo = 0,
                DataCadastro = dataAtual,
                CategoriaId = 2,
                EstoqueId = 1
            }
            );

            /*Lancamentos
                using System;

                namespace Inicial {
                    class Program
                    {
                        public static void Main(string[] args)
                        {
                            DateTime dataAtual = DateTime.Now;
                            Random random = new Random();
                            for (int x = 1; x <= 30; x++)  // Alterei de < 30 para <= 30 para gerar 30 objetos
                            {
                                int entradaAleatorio = random.Next(1, 81);
                                int saidaAleatorio = random.Next(1, 30);
                                int produtoId = random.Next(1, 6);  // Alterei o intervalo para gerar IDs de 1 a 5

                                // Formatando a data para exibir corretamente
                                string dataFormatada = dataAtual.AddDays(x).ToString("yyyy-MM-dd");

                                // Corrigindo a impressão da string para o formato desejado
                                Console.WriteLine($"new Lancamento{{LancamentoId = {x}, Data = DateTime.Parse(\"{dataFormatada}\"), QuantEntrada = {entradaAleatorio}, QuantSaida = {saidaAleatorio}, ProdutoId = {produtoId}, EstoquistaId = \"EstoquistaIdRaiz\"}},");
                            }

                        }
                    }
                }
            */
            builder.Entity<Lancamento>().HasData(
                new Lancamento { LancamentoId = 1, Data = DateTime.Parse("2024-07-14"), QuantEntrada = 18, QuantSaida = 20, ProdutoId = 1, EstoquistaId = "EstoquistaIdRaiz" },
                new Lancamento { LancamentoId = 2, Data = DateTime.Parse("2024-07-15"), QuantEntrada = 56, QuantSaida = 12, ProdutoId = 5, EstoquistaId = "EstoquistaIdRaiz" },
                new Lancamento { LancamentoId = 3, Data = DateTime.Parse("2024-07-16"), QuantEntrada = 54, QuantSaida = 4, ProdutoId = 1, EstoquistaId = "EstoquistaIdRaiz" },
                new Lancamento { LancamentoId = 4, Data = DateTime.Parse("2024-07-17"), QuantEntrada = 66, QuantSaida = 3, ProdutoId = 5, EstoquistaId = "EstoquistaIdRaiz" },
                new Lancamento { LancamentoId = 5, Data = DateTime.Parse("2024-09-18"), QuantEntrada = 47, QuantSaida = 3, ProdutoId = 3, EstoquistaId = "EstoquistaIdRaiz" },
                new Lancamento { LancamentoId = 6, Data = DateTime.Parse("2024-07-19"), QuantEntrada = 60, QuantSaida = 1, ProdutoId = 5, EstoquistaId = "EstoquistaIdRaiz" },
                new Lancamento { LancamentoId = 7, Data = DateTime.Parse("2024-07-20"), QuantEntrada = 36, QuantSaida = 20, ProdutoId = 4, EstoquistaId = "EstoquistaIdRaiz" },
                new Lancamento { LancamentoId = 8, Data = DateTime.Parse("2024-07-21"), QuantEntrada = 79, QuantSaida = 28, ProdutoId = 3, EstoquistaId = "EstoquistaIdRaiz" },
                new Lancamento { LancamentoId = 9, Data = DateTime.Parse("2024-09-22"), QuantEntrada = 36, QuantSaida = 24, ProdutoId = 4, EstoquistaId = "EstoquistaIdRaiz" },
                new Lancamento { LancamentoId = 10, Data = DateTime.Parse("2024-09-23"), QuantEntrada = 13, QuantSaida = 9, ProdutoId = 4, EstoquistaId = "EstoquistaIdRaiz" },
                new Lancamento { LancamentoId = 11, Data = DateTime.Parse("2024-09-24"), QuantEntrada = 19, QuantSaida = 5, ProdutoId = 2, EstoquistaId = "EstoquistaIdRaiz" },
                new Lancamento { LancamentoId = 12, Data = DateTime.Parse("2024-07-25"), QuantEntrada = 34, QuantSaida = 4, ProdutoId = 3, EstoquistaId = "EstoquistaIdRaiz" },
                new Lancamento { LancamentoId = 13, Data = DateTime.Parse("2024-09-26"), QuantEntrada = 10, QuantSaida = 7, ProdutoId = 1, EstoquistaId = "EstoquistaIdRaiz" },
                new Lancamento { LancamentoId = 14, Data = DateTime.Parse("2024-07-27"), QuantEntrada = 12, QuantSaida = 16, ProdutoId = 5, EstoquistaId = "EstoquistaIdRaiz" },
                new Lancamento { LancamentoId = 15, Data = DateTime.Parse("2024-07-28"), QuantEntrada = 59, QuantSaida = 11, ProdutoId = 3, EstoquistaId = "EstoquistaIdRaiz" },
                new Lancamento { LancamentoId = 16, Data = DateTime.Parse("2024-07-29"), QuantEntrada = 21, QuantSaida = 10, ProdutoId = 4, EstoquistaId = "EstoquistaIdRaiz" },
                new Lancamento { LancamentoId = 17, Data = DateTime.Parse("2024-07-30"), QuantEntrada = 26, QuantSaida = 20, ProdutoId = 1, EstoquistaId = "EstoquistaIdRaiz" },
                new Lancamento { LancamentoId = 18, Data = DateTime.Parse("2024-07-31"), QuantEntrada = 76, QuantSaida = 9, ProdutoId = 5, EstoquistaId = "EstoquistaIdRaiz" },
                new Lancamento { LancamentoId = 19, Data = DateTime.Parse("2024-08-01"), QuantEntrada = 68, QuantSaida = 20, ProdutoId = 1, EstoquistaId = "EstoquistaIdRaiz" },
                new Lancamento { LancamentoId = 20, Data = DateTime.Parse("2024-08-02"), QuantEntrada = 13, QuantSaida = 20, ProdutoId = 3, EstoquistaId = "EstoquistaIdRaiz" },
                new Lancamento { LancamentoId = 21, Data = DateTime.Parse("2024-08-03"), QuantEntrada = 19, QuantSaida = 4, ProdutoId = 1, EstoquistaId = "EstoquistaIdRaiz" },
                new Lancamento { LancamentoId = 22, Data = DateTime.Parse("2024-08-04"), QuantEntrada = 80, QuantSaida = 22, ProdutoId = 2, EstoquistaId = "EstoquistaIdRaiz" },
                new Lancamento { LancamentoId = 23, Data = DateTime.Parse("2024-08-05"), QuantEntrada = 27, QuantSaida = 18, ProdutoId = 2, EstoquistaId = "EstoquistaIdRaiz" },
                new Lancamento { LancamentoId = 24, Data = DateTime.Parse("2024-08-06"), QuantEntrada = 56, QuantSaida = 28, ProdutoId = 1, EstoquistaId = "EstoquistaIdRaiz" },
                new Lancamento { LancamentoId = 25, Data = DateTime.Parse("2024-08-07"), QuantEntrada = 66, QuantSaida = 25, ProdutoId = 2, EstoquistaId = "EstoquistaIdRaiz" },
                new Lancamento { LancamentoId = 26, Data = DateTime.Parse("2024-08-08"), QuantEntrada = 32, QuantSaida = 14, ProdutoId = 2, EstoquistaId = "EstoquistaIdRaiz" }
            );
        }

    }
}
