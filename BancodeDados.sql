create database ADCDB;

CREATE TABLE ADCDB.dbo.Pessoa(
	
	[id] bigint PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[cpf] nvarchar(16) NOT NULL,
	[email] nvarchar(80) NOT NULL,
	[senha] nvarchar(30) DEFAULT '12345678',
	[nome] nvarchar(max) NOT NULL,
	[saldo] float default 0
)

insert into ADCDB.dbo.Pessoa ([cpf],[email],[nome]) values('53426375892', 'andre@outlook.com', 'andrew silva')
insert into ADCDB.dbo.Pessoa ([cpf],[email],[nome]) values('47358973650', 'lucas@outlook.com', 'lucas reis')
insert into ADCDB.dbo.Pessoa ([cpf],[email],[nome]) values('536.836.937-01', 'joao@outlook.com', 'joao costa')
--select * from ADCDB.dbo.Pessoa

--saldo promocional para pessoas ao criar a conta no in�cio do aplicativo
update ADCDB.dbo.Pessoa set [saldo] = 10 where id in (1,2,3)

CREATE TABLE ADCDB.dbo.Loja(
	
	[id] bigint PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[cnpj] nvarchar(20)  NOT NULL,
	[email] nvarchar(80) NOT NULL,
	[senha] nvarchar(30) DEFAULT '12345678',
	[nome] nvarchar(max) NOT NULL,
	[saldo] float default 0
)

insert into ADCDB.dbo.Loja ([cnpj],[email],[nome]) values('02.463.854/0068-65', 'contato@store.com', 'store')
insert into ADCDB.dbo.Loja ([cnpj],[email],[nome]) values('01.168.268/0023-78', 'contato@mercadinho.com', 'mercadinho')
select * from ADCDB.dbo.Loja


-- proposta de melhoria, (nao implementado) implementa��o de hist�rico de transfer�ncias

-- abordagem 1

--CREATE TABLE ADCDB.dbo.Transferencias(
	
--	[id] bigint IDENTITY(1,1) NOT NULL,
--	[valor] float NOT NULL,
--	[pagador] bigint NOT NULL,
--	[recebedor] bigint NOT NULL,
--	[recebedorTipo] tinyint NOT NULL, --1 para pessoas e 0 para lojas
--	[horario] datetime DEFAULT SYSDATETIME(),
--    PRIMARY KEY (id),
--    FOREIGN KEY ([pagador]) REFERENCES ADCDB.dbo.Pessoa(id),

--)

--insert into ADCDB.dbo.Transferencias ([valor],[pagador],[recebedor]) values(10, 1, 1)
--insert into ADCDB.dbo.Transferencias ([valor],[pagador],[recebedor]) values(25, 2, 2)
--insert into ADCDB.dbo.Transferencias ([valor],[pagador],[recebedor]) values(15, 1, 3)
--select * from ADCDB.dbo.Transferencias

--abordagem 2
-- criar uma tabela compatível com historico para cada classe