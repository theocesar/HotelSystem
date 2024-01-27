use master;

drop database if exists Hotel;
create database Hotel;

use Hotel;


create table Cliente(
    idCliente int,
    nome varchar(55),
    endereco varchar(100),
    nacionalidade varchar(40),
    email varchar(40),
    telefone char(11)
 
    constraint pk_idCliente primary key(idCliente)
);
 
create table Funcionario(
    idFuncionario int,
    tipoFuncionario varchar(55),
    nome varchar(55)
 
    constraint pk_idFuncionario primary key(idFuncionario)
);
 
create table Quartos(
    codQuarto int,
    numero int,
    capacidadeMaxima int,
    valorQuarto DECIMAL(10, 2) NOT NULL,
    tipoQuarto varchar(55),
    adaptado INT NOT NULL CHECK (adaptado IN (0, 1)),
 
    constraint pk_codQuartos primary key(codQuarto),
);
 
create table Filial(
    codFilial int identity(1,1),
    nome varchar(60),
    codQuarto int,
    endereco varchar(100),
    quantidadeEstrelas int,
 
    constraint pk_codFilial primary key(codFilial),
    constraint fk_codQuarto foreign key(codQuarto) references Quartos(codQuarto)
);
 
create table Reservas(
    codigoReserva int,
    dtEntrada Datetime,
    dtSaida Datetime,
	capacidadeOpcional BIT,
	dtCancelamento Datetime, --Para calcular caso o cliente cancele antes das 24 horas
    idFuncionario int,
    idCliente int,
    numero int,
    codQuarto int,
 
    constraint pk_codigoReserva primary key(codigoReserva),
    constraint fk_idFuncionario foreign key(idFuncionario) references Funcionario(idFuncionario),
    constraint fk_idCliente foreign key(idCliente) references Cliente(idCliente),
    constraint fk_codQuartos foreign key(codQuarto) references Quartos(codQuarto)
);
 
create table NotaFiscal(
    codigoNota int,
    tipoPagamento varchar(55),
    valorTotal DECIMAL(10, 2),
    codReserva int,
 
    constraint pk_codNota primary key(codigoNota),
    constraint fk_codReservaNota foreign key(codReserva) references Reservas(codigoReserva)
);
 
create table Restaurante(
    codProduto int identity(1,1),
    nomeProduto varchar(50),
    valorProduto decimal(10, 2),
 
    constraint pk_codProduto primary key(codProduto)
);
 
create table Pedido(
    codProduto int,
    codReserva int,
    quantidade int,
	dataPedido datetime, -- caso o cliente peca o mesmo item duas vezes distintas no mesmo dia ou em dias separados
    entregueQuarto BIT,
 
    constraint pk_pedido primary key(codProduto, codReserva, dataPedido),
    constraint fk_codProduto foreign key(codProduto) references Restaurante(codProduto),
    constraint fk_codReserva foreign key(codReserva) references Reservas(codigoReserva)
);
 
create table Lavanderia(
    codigoLavanderia int identity(1,1),
    descricao varchar(150),
    valor decimal(10, 2),
 
    constraint pk_codLavanderia primary key(codigoLavanderia)
);
 
create table ServicoLavanderia(
    codigoLavanderia int,
    codReserva int,
	dataPrestacao datetime, -- caso o cliente o mesmo servico duas vezes distintas no mesmo dia ou em dias separados
 
    constraint pk_servico primary key(codigoLavanderia, codReserva, dataPrestacao),
    constraint fk_codigoLavanderia foreign key(codigoLavanderia) references Lavanderia(codigoLavanderia),
    constraint fk_codReservaLavanderia foreign key(codReserva) references Reservas(codigoReserva)
);
 
create table Frigobar(
    codItem int identity(1,1),
    nomeItem varchar(50),
    valorItem decimal(10, 2),
 
    constraint pk_codItem primary key(codItem)
);
 
create table ServicoFrigobar(
    codItem int,
    codReserva int,
	dataSolicitacao datetime, -- caso o cliente o mesmo servico duas vezes distintas no mesmo dia ou em dias separados
 
    constraint pk_servicoFrigobar primary key(codItem, codReserva, dataSolicitacao),
    constraint fk_codigoItem foreign key(codItem) references Frigobar(codItem),
    constraint fk_codReservaFrigobar foreign key(codReserva) references Reservas(codigoReserva)
);


insert into Cliente (idCliente, nome, endereco, nacionalidade, email, telefone)
values
    (1, 'João da Silva', 'Rua das Flores, 123', 'Brasileira', 'joao.silva@email.com', '12345678901'),
    (2, 'Sophie Johnson', '123 Main Street, Apt 45', 'Estrangeira', 'sophie.j@email.com', '98765432109'),
    (3, 'Mariana Oliveira', 'Av. dos Anjos, 789', 'Brasileira', 'mariana.oliveira@email.com', '11122233344');
insert into Funcionario (idFuncionario, tipoFuncionario, nome)
values
    (1, 'Recepcionista', 'Ana Silva'),
    (2, 'Gerente', 'Carlos Oliveira'),
    (3, 'Equipe de Limpeza', 'Mariana Santos');
insert into Quartos (codQuarto, numero, capacidadeMaxima, valorQuarto, tipoQuarto, adaptado)
values
    (1, 101, 2, 150.00, 'Solteiro', 1),
    (2, 201, 4, 250.00, 'Casal', 0),
    (3, 301, 3, 200.00, 'Família', 1),
    (4, 401, 5, 500.00, 'Presidencial', 0);
insert into Filial (nome, codQuarto, endereco, quantidadeEstrelas)
values
    ('Hotel Luxor', 1, 'Rua Luxuosa, 123', 4),
    ('Pousada Charmosa', 2, 'Avenida Elegante, 456', 3),
    ('Resort Paradiso', 4, 'Alameda Exclusiva, 789', 5);
insert into Reservas (codigoReserva, dtEntrada, dtSaida, capacidadeOpcional, dtCancelamento, idFuncionario, idCliente, numero, codQuarto)
values
    (1, '2024-01-26T20:00:00', '2024-01-28T20:00:00', 1, null, 1, 1, 101, 1),
    (2, '2024-02-01T20:00:00', '2024-02-05T20:00:00', 0,null, 2, 2, 201, 2),
    (3, '2024-03-10T20:00:00', '2024-03-15T20:00:00', 1,null, 3, 3, 301, 3);
insert into NotaFiscal (codigoNota, tipoPagamento, valorTotal, codReserva)
values
    (1, 'Cartão', 300.00, 1),
    (2, 'Dinheiro', 500.00, 2),
    (3, 'Transferência', 400.00, 3);
insert into Restaurante (nomeProduto, valorProduto)
values
    ('Filé à Parmegiana', 30.00),
    ('Risoto de Frutos do Mar', 35.00),
    ('Caipirinha de Morango', 8.00);
insert into Pedido (codProduto, codReserva, quantidade, dataPedido,  entregueQuarto)
values
    (1, 1, 2, '2020-06-27T20:00:00', 1),
    (2, 2, 1, '2020-12-24T20:00:00',0),
    (3, 3, 3, '2020-10-24T20:00:00',1),
	(3, 2, 3, '2020-10-24T20:30:00',1),
	(3, 2, 3, '2020-10-24T20:50:00',1);
insert into Lavanderia (descricao, valor)
values
    ('Lavar Roupa', 30.00),
    ('Passar Camisa', 15.00),
    ('Lavar Tênis', 20.00);
insert into ServicoLavanderia (codigoLavanderia, codReserva, dataPrestacao)
values
    (1, 1, '2020-04-16T20:00:00'),
    (2, 2, '2020-03-03T20:00:00'),
    (3, 3, '2020-02-16T20:00:00');
insert into Frigobar (nomeItem, valorItem)
values
    ('Água', 5.00),
    ('Chocolate', 3.50),
    ('Refrigerante', 7.00);
insert into ServicoFrigobar (codItem, codReserva, dataSolicitacao)
values
    (1, 1, '2020-04-16T20:00:00'),
    (2, 2, '2020-03-03T20:00:00'),
    (3, 3, '2020-02-16T20:00:00');

-- Quartos disponíveis (não reservados para o futuro):
SELECT * 
FROM 
	Quartos 
WHERE 
	codQuarto 
	NOT IN (SELECT 
				codQuarto 
			FROM 
				Reservas 
			WHERE 
				dtSaida >= GETDATE());

-- Consulta para obter detalhes de todas as reservas com informações do cliente, funcionário, quarto e datas:
SELECT 
	R.codigoReserva,
	R.dtEntrada,
	R.dtSaida,
	C.nome AS nomeCliente,
	F.nome AS nomeFuncionario,
	Q.numero AS numeroQuarto
FROM 
	Reservas R
	JOIN Cliente C ON R.idCliente = C.idCliente
	JOIN Funcionario F ON R.idFuncionario = F.idFuncionario
	JOIN Quartos Q ON R.codQuarto = Q.codQuarto;


-- Consulta para obter as reservas associadas a um funcionário específico
DECLARE @NomeFuncionario VARCHAR(55) = 'Ana Silva';

SELECT R.codigoReserva, R.dtEntrada, R.dtSaida, C.nome AS nomeCliente, Q.numero AS numeroQuarto
FROM Reservas R
JOIN Cliente C ON R.idCliente = C.idCliente
JOIN Quartos Q ON R.codQuarto = Q.codQuarto
JOIN Funcionario F ON R.idFuncionario = F.idFuncionario
WHERE F.nome = @NomeFuncionario;

-- Consulta para obter o histórico de consumo associado a uma reserva específica
SELECT 
	RF.nomeProduto, 
	R.dtEntrada, 
	R.dtSaida, 
	P.quantidade, 
	P.entregueQuarto, 
	RF.nomeProduto, 
	RF.valorProduto
FROM 
	Pedido P
	JOIN Reservas R ON P.codReserva = R.codigoReserva
	JOIN Restaurante RF ON P.codProduto = RF.codProduto
WHERE 
	P.codReserva = 2;





 


