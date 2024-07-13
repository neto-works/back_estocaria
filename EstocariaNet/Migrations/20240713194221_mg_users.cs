using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EstocariaNet.Migrations
{
    /// <inheritdoc />
    public partial class mg_users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Setor = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AplicationUserAdminId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Estoques",
                columns: table => new
                {
                    EstoqueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Local = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Capacidade = table.Column<float>(type: "float", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EstoqueAdminId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LinkAdminAdminId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoques", x => x.EstoqueId);
                    table.ForeignKey(
                        name: "FK_Estoques_Admins_LinkAdminAdminId",
                        column: x => x.LinkAdminAdminId,
                        principalTable: "Admins",
                        principalColumn: "AdminId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Relatorios",
                columns: table => new
                {
                    RelatorioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RelatorioName = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ProdutoMaisSaiu = table.Column<int>(type: "int", nullable: true),
                    ProdutoMaisEntrou = table.Column<int>(type: "int", nullable: true),
                    TotalArrecadado = table.Column<double>(type: "double", nullable: true),
                    PredicaoProxMeses = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    MesAnoPred = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PredProdutoSaida = table.Column<int>(type: "int", nullable: true),
                    PredProdutoEntrada = table.Column<int>(type: "int", nullable: true),
                    PredTotalArrecadar = table.Column<double>(type: "double", nullable: true),
                    AdminId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatorios", x => x.RelatorioId);
                    table.ForeignKey(
                        name: "FK_Relatorios_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "AdminId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Preco = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    ImagemUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QuantEstoqueMin = table.Column<float>(type: "float", nullable: false),
                    QuantEstoqueMax = table.Column<float>(type: "float", nullable: false),
                    Saldo = table.Column<float>(type: "float", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CategoriaId = table.Column<int>(type: "int", nullable: true),
                    EstoqueId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_Produtos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId");
                    table.ForeignKey(
                        name: "FK_Produtos_Estoques_EstoqueId",
                        column: x => x.EstoqueId,
                        principalTable: "Estoques",
                        principalColumn: "EstoqueId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RefreshToken = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TipoUsuario = table.Column<int>(type: "int", nullable: true),
                    AdminId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EstoquistaId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "AdminId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Estoquistas",
                columns: table => new
                {
                    EstoquistaId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cpf = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Celular = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AplicationUserEstoquistaId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EstoquistaEstoqueId = table.Column<int>(type: "int", nullable: true),
                    EstoqueId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoquistas", x => x.EstoquistaId);
                    table.ForeignKey(
                        name: "FK_Estoquistas_AspNetUsers_AplicationUserEstoquistaId",
                        column: x => x.AplicationUserEstoquistaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estoquistas_Estoques_EstoqueId",
                        column: x => x.EstoqueId,
                        principalTable: "Estoques",
                        principalColumn: "EstoqueId");
                    table.ForeignKey(
                        name: "FK_Estoquistas_Estoques_EstoquistaEstoqueId",
                        column: x => x.EstoquistaEstoqueId,
                        principalTable: "Estoques",
                        principalColumn: "EstoqueId",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Lancamentos",
                columns: table => new
                {
                    LancamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    QuantEntrada = table.Column<float>(type: "float", nullable: false),
                    QuantSaida = table.Column<float>(type: "float", nullable: false),
                    EstoqueaId = table.Column<int>(type: "int", nullable: true),
                    ProdutoId = table.Column<int>(type: "int", nullable: true),
                    EstoquistaId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LinkEstoqueEstoqueId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lancamentos", x => x.LancamentoId);
                    table.ForeignKey(
                        name: "FK_Lancamentos_Estoques_LinkEstoqueEstoqueId",
                        column: x => x.LinkEstoqueEstoqueId,
                        principalTable: "Estoques",
                        principalColumn: "EstoqueId");
                    table.ForeignKey(
                        name: "FK_Lancamentos_Estoquistas_EstoquistaId",
                        column: x => x.EstoquistaId,
                        principalTable: "Estoquistas",
                        principalColumn: "EstoquistaId");
                    table.ForeignKey(
                        name: "FK_Lancamentos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LancamentoRelatorio",
                columns: table => new
                {
                    LancamentosLancamentoId = table.Column<int>(type: "int", nullable: false),
                    RelatoriosRelatorioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LancamentoRelatorio", x => new { x.LancamentosLancamentoId, x.RelatoriosRelatorioId });
                    table.ForeignKey(
                        name: "FK_LancamentoRelatorio_Lancamentos_LancamentosLancamentoId",
                        column: x => x.LancamentosLancamentoId,
                        principalTable: "Lancamentos",
                        principalColumn: "LancamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LancamentoRelatorio_Relatorios_RelatoriosRelatorioId",
                        column: x => x.RelatoriosRelatorioId,
                        principalTable: "Relatorios",
                        principalColumn: "RelatorioId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "AdminId", "AplicationUserAdminId", "Setor" },
                values: new object[] { "AdminId", null, "Vargas" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AdminId", "ConcurrencyStamp", "Email", "EmailConfirmed", "EstoquistaId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TipoUsuario", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "usuarioAdminRaiz", 0, null, null, "Admins@gmail.com", false, null, false, new DateTimeOffset(new DateTime(2045, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -3, 0, 0, 0)), "ADMIN@GMAIL.COM", "ADMIN", "", "9981998199", true, null, new DateTime(2045, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, false, "Admin" },
                    { "usuarioEstoquistaRaiz", 0, null, null, "estoquista@gmail.com", false, null, false, new DateTimeOffset(new DateTime(2045, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, -3, 0, 0, 0)), "ESTOQUISTA@GMAIL.COM", "ESTOQUISTA", "", "9981998199", true, null, new DateTime(2045, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, false, "Estoquista" }
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CategoriaId", "Nome" },
                values: new object[,]
                {
                    { 1, "Grãos" },
                    { 2, "Em pó" }
                });

            migrationBuilder.InsertData(
                table: "Estoques",
                columns: new[] { "EstoqueId", "Capacidade", "DataCriacao", "EstoqueAdminId", "LinkAdminAdminId", "Local", "Nome" },
                values: new object[,]
                {
                    { 1, 1150.5f, new DateTime(2024, 7, 13, 16, 42, 20, 902, DateTimeKind.Local).AddTicks(1560), null, null, "Vale dos cangurus", "EST - Comestíveis SA" },
                    { 2, 1650.5f, new DateTime(2024, 7, 13, 16, 42, 20, 902, DateTimeKind.Local).AddTicks(1560), null, null, "Vale dos cangurus", "EST - Prod Limpeza SA" }
                });

            migrationBuilder.InsertData(
                table: "Estoquistas",
                columns: new[] { "EstoquistaId", "AplicationUserEstoquistaId", "Celular", "Cpf", "DataInicio", "EstoqueId", "EstoquistaEstoqueId" },
                values: new object[] { "EstoquistaIdRaiz", null, "567456546", "11800909862", new DateTime(2024, 7, 13, 16, 42, 20, 902, DateTimeKind.Local).AddTicks(1560), null, null });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "ProdutoId", "CategoriaId", "DataCadastro", "Descricao", "EstoqueId", "ImagemUrl", "Nome", "Preco", "QuantEstoqueMax", "QuantEstoqueMin", "Saldo" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 7, 13, 16, 42, 20, 902, DateTimeKind.Local).AddTicks(1560), "É o arroz descascado", 1, "algumaimagem.png", "Arroz Integral", 6.4m, 250f, 0f, 0f },
                    { 2, 1, new DateTime(2024, 7, 13, 16, 42, 20, 902, DateTimeKind.Local).AddTicks(1560), "Variedade do feijão comum", 1, "algumaimagem.png", "Feijão carioca", 6.4m, 250f, 0f, 0f },
                    { 3, 2, new DateTime(2024, 7, 13, 16, 42, 20, 902, DateTimeKind.Local).AddTicks(1560), "Farinha de mandioca", 1, "algumaimagem.png", "Farinha Granfind", 6.4m, 250f, 0f, 0f },
                    { 4, 2, new DateTime(2024, 7, 13, 16, 42, 20, 902, DateTimeKind.Local).AddTicks(1560), "Café produzido em Caicó", 1, "algumaimagem.png", "Café Itans", 6.4m, 250f, 0f, 0f },
                    { 5, 2, new DateTime(2024, 7, 13, 16, 42, 20, 902, DateTimeKind.Local).AddTicks(1560), "Açúcar refinado e cristalino", 1, "algumaimagem.png", "Açúcar Cristal", 6.4m, 250f, 0f, 0f }
                });

            migrationBuilder.InsertData(
                table: "Lancamentos",
                columns: new[] { "LancamentoId", "Data", "EstoqueaId", "EstoquistaId", "LinkEstoqueEstoqueId", "ProdutoId", "QuantEntrada", "QuantSaida" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EstoquistaIdRaiz", null, 1, 18f, 20f },
                    { 2, new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EstoquistaIdRaiz", null, 5, 56f, 12f },
                    { 3, new DateTime(2024, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EstoquistaIdRaiz", null, 1, 54f, 4f },
                    { 4, new DateTime(2024, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EstoquistaIdRaiz", null, 5, 66f, 3f },
                    { 5, new DateTime(2024, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EstoquistaIdRaiz", null, 3, 47f, 3f },
                    { 6, new DateTime(2024, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EstoquistaIdRaiz", null, 5, 60f, 1f },
                    { 7, new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EstoquistaIdRaiz", null, 4, 36f, 20f },
                    { 8, new DateTime(2024, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EstoquistaIdRaiz", null, 3, 79f, 28f },
                    { 9, new DateTime(2024, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EstoquistaIdRaiz", null, 4, 36f, 24f },
                    { 10, new DateTime(2024, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EstoquistaIdRaiz", null, 4, 13f, 9f },
                    { 11, new DateTime(2024, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EstoquistaIdRaiz", null, 2, 19f, 5f },
                    { 12, new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EstoquistaIdRaiz", null, 3, 34f, 4f },
                    { 13, new DateTime(2024, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EstoquistaIdRaiz", null, 1, 10f, 7f },
                    { 14, new DateTime(2024, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EstoquistaIdRaiz", null, 5, 12f, 16f },
                    { 15, new DateTime(2024, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EstoquistaIdRaiz", null, 3, 59f, 11f },
                    { 16, new DateTime(2024, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EstoquistaIdRaiz", null, 4, 21f, 10f },
                    { 17, new DateTime(2024, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EstoquistaIdRaiz", null, 1, 26f, 20f },
                    { 18, new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EstoquistaIdRaiz", null, 5, 76f, 9f },
                    { 19, new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EstoquistaIdRaiz", null, 1, 68f, 20f },
                    { 20, new DateTime(2024, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EstoquistaIdRaiz", null, 3, 13f, 20f },
                    { 21, new DateTime(2024, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EstoquistaIdRaiz", null, 1, 19f, 4f },
                    { 22, new DateTime(2024, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EstoquistaIdRaiz", null, 2, 80f, 22f },
                    { 23, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EstoquistaIdRaiz", null, 2, 27f, 18f },
                    { 24, new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EstoquistaIdRaiz", null, 1, 56f, 28f },
                    { 25, new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EstoquistaIdRaiz", null, 2, 66f, 25f },
                    { 26, new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "EstoquistaIdRaiz", null, 2, 32f, 14f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_AplicationUserAdminId",
                table: "Admins",
                column: "AplicationUserAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AdminId",
                table: "AspNetUsers",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EstoquistaId",
                table: "AspNetUsers",
                column: "EstoquistaId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estoques_LinkAdminAdminId",
                table: "Estoques",
                column: "LinkAdminAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoquistas_AplicationUserEstoquistaId",
                table: "Estoquistas",
                column: "AplicationUserEstoquistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoquistas_EstoqueId",
                table: "Estoquistas",
                column: "EstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoquistas_EstoquistaEstoqueId",
                table: "Estoquistas",
                column: "EstoquistaEstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_LancamentoRelatorio_RelatoriosRelatorioId",
                table: "LancamentoRelatorio",
                column: "RelatoriosRelatorioId");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_EstoquistaId",
                table: "Lancamentos",
                column: "EstoquistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_LinkEstoqueEstoqueId",
                table: "Lancamentos",
                column: "LinkEstoqueEstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_ProdutoId",
                table: "Lancamentos",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaId",
                table: "Produtos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_EstoqueId",
                table: "Produtos",
                column: "EstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Relatorios_AdminId",
                table: "Relatorios",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_AspNetUsers_AplicationUserAdminId",
                table: "Admins",
                column: "AplicationUserAdminId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Estoquistas_EstoquistaId",
                table: "AspNetUsers",
                column: "EstoquistaId",
                principalTable: "Estoquistas",
                principalColumn: "EstoquistaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_AspNetUsers_AplicationUserAdminId",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Estoquistas_AspNetUsers_AplicationUserEstoquistaId",
                table: "Estoquistas");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "LancamentoRelatorio");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Lancamentos");

            migrationBuilder.DropTable(
                name: "Relatorios");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Estoquistas");

            migrationBuilder.DropTable(
                name: "Estoques");

            migrationBuilder.DropTable(
                name: "Admins");
        }
    }
}
