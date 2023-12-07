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
ID int not null primary key identity(1,1),
gname varchar(20) not null,
realm varchar(20) not null,
);

create table members(
ID int not null primary key identity(1,1),
memname varchar(15),
class varchar(20),
race varchar(20),
charlevel int,
realm varchar(20),
guild_id int
);

create table raidgroups(
ID int not null primary key identity(1,1),
groupname varchar(10) not null,
difficulty char(1) not null,
);

create table raid_planning(
raidgroupID int,
memberID int,
primary key (raidgroupID, memberID),
foreign key (raidgroupID) references raidgroups(ID),
foreign key (memberID) references members(ID)
);

create table progress(
ID int not null primary key identity(1,1),
readygroup int,
cleardate datetime
);

create table raids(
ID int not null primary key identity(1,1),
raidname varchar(50) not null,
difficulty char(1) not null,
raidgroup_clear int,);

alter table raids add foreign key (raidgroup_clear) references progress(ID);
alter table progress add foreign key (readygroup) references raidgroups(ID);
alter table members add foreign key (guild_id) references guilds(ID);


insert into guilds (gname, realm) values

('Serenity', 'Ragnaros'),
('Requiem', 'Argent Dawn'),
('Go Agane', 'Golemagg'),
('Warrior Gang', 'Golemagg'),
('Wipe Club', 'Ragnaros'),
('Death and Taxes', 'Blackrock');


insert into members (memname, class, race, charlevel, realm, guild_id) values

('Zdenski','Warrior', 'Tauren', '110', 'Golemagg', 4),
('Stormraging', 'Warrior', 'Tauren', '110', 'Golemagg', 4),
('Tankomania', 'Warrior', 'Tauren', '110', 'Golemagg', 4),
('Warorio', 'Warrior', 'Orc', '110', 'Golemagg', 4),
('Cambo', 'Warrior', 'Orc', '110', 'Golemagg', 4),
('Urzuk', 'Death Knight', 'Orc', '110', 'Golemagg', 3),
('Burninated', 'Death Knight', 'Tauren', '110', 'Golemagg', 3),
('Sevenstryx', 'Priest', 'Undead', '110', 'Golemagg', 3),
('Babetina', 'Rogue', 'Undead', '110', 'Golemagg', 3),
('Xenonion', 'Mage', 'Goblin', '110', 'Golemagg', 3),
('Nociel', 'Paladin', 'Blood Elf', '110', 'Ragnaros', 5),
('Bleedmore', 'Warrior', 'Tauren', '110', 'Ragnaros', 5),
('Bazingalord', 'Warlock', 'Undead', '110', 'Ragnaros', 5),
('Romerquele', 'Hunter', 'Troll', '110', 'Ragnaros', 5),
('Dives', 'Warrior', 'Tauren', '110', 'Ragnaros', 5),
('Crushim', 'Rogue', 'Undead', '110', 'Ragnaros', 5),
('Alachas', 'Druid', 'Tauren', '110', 'Ragnaros', 5),
('Gokuu', 'Paladin', 'Blood Elf', '110', 'Argent Dawn', 2),
('Oxhornsfan', 'Warrior', 'Orc', '110', 'Argent Dawn', 2),
('Vladiria', 'Mage', 'Blood Elf', '110', 'Argent Dawn', 2),
('Bonelessboi', 'Priest', 'Undead', '110', 'Argent Dawn', 2),
('Oreotodont', 'Demon Hunter', 'Blood Elf', '110', 'Argent Dawn', 2),
('Gettingpaid', 'Death Knight', 'Undead', '110', 'Argent Dawn', 2),
('Armordilbro', 'Demon Hunter', 'Blood Elf', '110', 'Argent Dawn', 2),
('Childprotserv', 'Priest', 'Blood Elf', '110', 'Ragnaros', 1),
('Pomuzime', 'Shaman', 'Tauren', '110', 'Ragnaros', 1),
('Totemhugger', 'Shaman', 'Orc', '110', 'Ragnaros', 1),
('Milkyyman', 'Shaman', 'Orc', '110', 'Ragnaros', 1),
('Taurgetdummy', 'Demon Hunter', 'Blood Elf', '110', 'Ragnaros', 1),
('Tartufigaming', 'Demon Hunter', 'Blood Elf', '110', 'Ragnaros', 1),
('Sarayurix', 'Priest', 'Tauren', '110', 'Ragnaros', 1),
('Faelina', 'Paladin', 'Blood Elf', '110', 'Ragnaros', 1),
('Corneliuss', 'Mage', 'Undead', '110', 'Blackrock', 6),
('Kungen', 'Warrior', 'Tauren', '110', 'Blackrock', 6),
('Onyx', 'Death Knight', 'Tauren', '110', 'Blackrock', 6),
('Bigbc', 'Rogue', 'Orc', '110', 'Blackrock', 6),
('Thunderfist', 'Shaman', 'Tauren', '110', 'Blackrock', 6),
('Oblutak', 'Shaman', 'Orc', '110', 'Blackrock', 6),
('Moreloot', 'Hunter', 'Troll', '110', 'Blackrock', 6),
('Sussytea', 'Warlock', 'Troll', '110', 'Blackrock', 6),
('Wolfdisco', 'Warrior', 'Undead', '110', 'Blackrock', 6),
('Derutiso', 'Mage', 'Blood Elf', '110', 'Blackrock', 6);


insert into raidgroups (groupname, difficulty) values

('Group1', 'M');


insert into raid_planning (raidgroupID, memberID) values

(1, 1),
(1, 2),
(1, 3),
(1, 4),
(1, 5);
 

insert into progress (readygroup, cleardate) values

(1, '2017-07-16 22:54:00'),
(1, '2016-09-29 21:27:00'),
(1, '2016-11-18 00:12:00'),
(1, '2017-02-04 23:49:00'),
(1, '2017-12-13 17:00:00');


insert into raids (raidname, difficulty, raidgroup_clear) values

('The Emerald Nightmare', 'M', 2),
('The Nighthold', 'M', 3),
('Trial of Valor', 'M', 4),
('Tomb of Sargeras', 'M', 1),
('Antorus, the Burning Throne', 'M', 5);
