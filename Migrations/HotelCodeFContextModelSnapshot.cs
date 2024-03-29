﻿// <auto-generated />
using System;
using HotelEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelEntity.Migrations
{
    [DbContext(typeof(HotelCodeFContext))]
    partial class HotelCodeFContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HotelEntity.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"));

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Endereco")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nacionalidade")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nome")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Telefone")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("IdCliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("HotelEntity.Filial", b =>
                {
                    b.Property<int>("CodFilial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodFilial"));

                    b.Property<bool>("Adaptado")
                        .HasColumnType("bit");

                    b.Property<int>("CodQuarto")
                        .HasColumnType("int");

                    b.Property<string>("Endereco")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nome")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("QuantidadeEstrelas")
                        .HasColumnType("int");

                    b.Property<int?>("QuartoCodQuarto")
                        .HasColumnType("int");

                    b.HasKey("CodFilial");

                    b.HasIndex("QuartoCodQuarto");

                    b.ToTable("Filial");
                });

            modelBuilder.Entity("HotelEntity.Frigobar", b =>
                {
                    b.Property<int>("CodigoItem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodigoItem"));

                    b.Property<string>("Nome")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("CodigoItem");

                    b.ToTable("Frigobar");
                });

            modelBuilder.Entity("HotelEntity.Funcionario", b =>
                {
                    b.Property<int>("IdFuncionario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFuncionario"));

                    b.Property<string>("Nome")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("TipoFuncionario")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.HasKey("IdFuncionario");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("HotelEntity.Lavanderia", b =>
                {
                    b.Property<int>("CodigoLavanderia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodigoLavanderia"));

                    b.Property<string>("Descricao")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("CodigoLavanderia");

                    b.ToTable("Lavanderia");
                });

            modelBuilder.Entity("HotelEntity.NotaFiscal", b =>
                {
                    b.Property<int>("CodNota")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodNota"));

                    b.Property<int>("CodReserva")
                        .HasColumnType("int");

                    b.Property<int?>("ReservaCodReserva")
                        .HasColumnType("int");

                    b.Property<string>("TipoPagamento")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<double>("ValorTotal")
                        .HasMaxLength(100)
                        .HasColumnType("float");

                    b.HasKey("CodNota");

                    b.HasIndex("ReservaCodReserva");

                    b.ToTable("NotaFiscal");
                });

            modelBuilder.Entity("HotelEntity.Pedido", b =>
                {
                    b.Property<int>("CodProduto")
                        .HasColumnType("int");

                    b.Property<int>("CodReserva")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DataPedido")
                        .HasColumnType("date");

                    b.Property<bool>("EntregueQuarto")
                        .HasColumnType("bit");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int?>("RestauranteCodigoProduto")
                        .HasColumnType("int");

                    b.HasKey("CodProduto", "CodReserva", "DataPedido");

                    b.HasIndex("CodReserva");

                    b.HasIndex("RestauranteCodigoProduto");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("HotelEntity.Quartos", b =>
                {
                    b.Property<int>("CodQuarto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodQuarto"));

                    b.Property<bool>("Adaptado")
                        .HasColumnType("bit");

                    b.Property<int>("CapacidadeMaxima")
                        .HasColumnType("int");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("TipoQuarto")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("CodQuarto");

                    b.ToTable("Quartos");
                });

            modelBuilder.Entity("HotelEntity.Reservas", b =>
                {
                    b.Property<int>("CodReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodReserva"));

                    b.Property<bool>("CapacidadeOpcional")
                        .HasColumnType("bit");

                    b.Property<int?>("ClienteIdCliente")
                        .HasColumnType("int");

                    b.Property<int>("CodQuarto")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DTCancelamento")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DTEntrada")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DTSaida")
                        .HasColumnType("date");

                    b.Property<int?>("FuncionarioIdFuncionario")
                        .HasColumnType("int");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdFuncionario")
                        .HasColumnType("int");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<int?>("QuartoCodQuarto")
                        .HasColumnType("int");

                    b.HasKey("CodReserva");

                    b.HasIndex("ClienteIdCliente");

                    b.HasIndex("FuncionarioIdFuncionario");

                    b.HasIndex("QuartoCodQuarto");

                    b.ToTable("Reserva");
                });

            modelBuilder.Entity("HotelEntity.Restaurante", b =>
                {
                    b.Property<int>("CodigoProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodigoProduto"));

                    b.Property<string>("Nome")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("CodigoProduto");

                    b.ToTable("Restaurante");
                });

            modelBuilder.Entity("HotelEntity.ServicoFrigobar", b =>
                {
                    b.Property<int>("CodItem")
                        .HasColumnType("int");

                    b.Property<int>("CodReserva")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DataSolicitacao")
                        .HasColumnType("date");

                    b.Property<int?>("FrigobarCodigoItem")
                        .HasColumnType("int");

                    b.HasKey("CodItem", "CodReserva", "DataSolicitacao");

                    b.HasIndex("CodReserva");

                    b.HasIndex("FrigobarCodigoItem");

                    b.ToTable("ServicoFrigobar");
                });

            modelBuilder.Entity("HotelEntity.ServicoLavanderia", b =>
                {
                    b.Property<int>("CodLavanderia")
                        .HasColumnType("int");

                    b.Property<int>("CodReserva")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DataPrestacao")
                        .HasColumnType("date");

                    b.Property<int?>("LavanderiaCodigoLavanderia")
                        .HasColumnType("int");

                    b.HasKey("CodLavanderia", "CodReserva", "DataPrestacao");

                    b.HasIndex("CodReserva");

                    b.HasIndex("LavanderiaCodigoLavanderia");

                    b.ToTable("ServicoLavanderia");
                });

            modelBuilder.Entity("HotelEntity.Filial", b =>
                {
                    b.HasOne("HotelEntity.Quartos", "Quarto")
                        .WithMany()
                        .HasForeignKey("QuartoCodQuarto");

                    b.Navigation("Quarto");
                });

            modelBuilder.Entity("HotelEntity.NotaFiscal", b =>
                {
                    b.HasOne("HotelEntity.Reservas", "Reserva")
                        .WithMany()
                        .HasForeignKey("ReservaCodReserva");

                    b.Navigation("Reserva");
                });

            modelBuilder.Entity("HotelEntity.Pedido", b =>
                {
                    b.HasOne("HotelEntity.Reservas", "Reserva")
                        .WithMany()
                        .HasForeignKey("CodReserva")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelEntity.Restaurante", "Restaurante")
                        .WithMany()
                        .HasForeignKey("RestauranteCodigoProduto");

                    b.Navigation("Reserva");

                    b.Navigation("Restaurante");
                });

            modelBuilder.Entity("HotelEntity.Reservas", b =>
                {
                    b.HasOne("HotelEntity.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteIdCliente");

                    b.HasOne("HotelEntity.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioIdFuncionario");

                    b.HasOne("HotelEntity.Quartos", "Quarto")
                        .WithMany()
                        .HasForeignKey("QuartoCodQuarto");

                    b.Navigation("Cliente");

                    b.Navigation("Funcionario");

                    b.Navigation("Quarto");
                });

            modelBuilder.Entity("HotelEntity.ServicoFrigobar", b =>
                {
                    b.HasOne("HotelEntity.Reservas", "Reserva")
                        .WithMany()
                        .HasForeignKey("CodReserva")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelEntity.Frigobar", "Frigobar")
                        .WithMany()
                        .HasForeignKey("FrigobarCodigoItem");

                    b.Navigation("Frigobar");

                    b.Navigation("Reserva");
                });

            modelBuilder.Entity("HotelEntity.ServicoLavanderia", b =>
                {
                    b.HasOne("HotelEntity.Reservas", "Reserva")
                        .WithMany()
                        .HasForeignKey("CodReserva")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelEntity.Lavanderia", "Lavanderia")
                        .WithMany()
                        .HasForeignKey("LavanderiaCodigoLavanderia");

                    b.Navigation("Lavanderia");

                    b.Navigation("Reserva");
                });
#pragma warning restore 612, 618
        }
    }
}
