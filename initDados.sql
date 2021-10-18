CREATE TABLE ADCDB.dbo.Pessoa(
	
	[id] bigint PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[cpf] nvarchar(16) NOT NULL,
	[email] nvarchar(80) NOT NULL,
	[senha] nvarchar(30) DEFAULT '12345678',
	[nome] nvarchar(max) NOT NULL,
	[saldo] float default 0)
insert into ADCDB.dbo.Pessoa ([cpf],[email],[nome]) values('53426375892', 'andre@outlook.com', 'andrew silva')
insert into ADCDB.dbo.Pessoa ([cpf],[email],[nome]) values('47358973650', 'lucas@outlook.com', 'lucas reis')
insert into ADCDB.dbo.Pessoa ([cpf],[email],[nome]) values('536.836.937-01', 'joao@outlook.com', 'joao costa')
update ADCDB.dbo.Pessoa set [saldo] = 10 where id in (1,2,3)
CREATE TABLE ADCDB.dbo.Loja(
	[id] bigint PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[cnpj] nvarchar(20)  NOT NULL,
	[email] nvarchar(80) NOT NULL,
	[senha] nvarchar(30) DEFAULT '12345678',
	[nome] nvarchar(max) NOT NULL,
	[saldo] float default 0)
insert into ADCDB.dbo.Loja ([cnpj],[email],[nome]) values('02.463.854/0068-65', 'contato@store.com', 'store')
insert into ADCDB.dbo.Loja ([cnpj],[email],[nome]) values('01.168.268/0023-78', 'contato@mercadinho.com', 'mercadinho')
go