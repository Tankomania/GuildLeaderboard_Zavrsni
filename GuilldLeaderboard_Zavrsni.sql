use master;
go
drop database if exists GuildLeaderboard_Zavrsni;
go

create database GuildLeaderboard_Zavrsni;
go
alter database GuildLeaderboard_Zavrsni collate Croatian_CI_AS;
go
use GuildLeaderboard_Zavrsni;

create table guilds(
sifra int not null primary key identity(1,1),
naziv varchar(10) not null,
realm varchar(20) not null,
members int
);

create table members(
sifra int not null primary key identity(1,1),
ime varchar(15),
class varchar(20),
race varchar(20),
charlevel int,
realm varchar(20)
);

create table raidgroup(
cleardate int not null primary key identity(1,1),
members int,
);

create table raids(
sifra int not null primary key identity(1,1),
ime varchar(50),
difficulty char(1),
cleardate int,
completion varchar(100)
);

alter table guilds add foreign key (members) references members(sifra);
alter table raidgroup add foreign key (members) references members(sifra);
alter table raids add foreign key (cleardate) references raidgroup(cleardate);

