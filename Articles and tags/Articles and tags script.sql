create table dbo.Articles
(
    Id     bigint        not null identity(1,1) primary key
  , Topic  nvarchar(256) not null
  , Author nvarchar(50)  not null
);
go

create table dbo.Tags
(
    Id  int          not null identity(1,1) primary key
  , Tag nvarchar(50) not null
);
go

create table dbo.ArticleTagLinks
(
    Id        bigint not null identity(1,1) primary key
  , ArticleId bigint not null
  , TagId     int    not null
);
go

create nonclustered index nix_Links_ArticleId on dbo.ArticleTagLinks (ArticleId);
create nonclustered index nix_Links_TagId on dbo.ArticleTagLinks (TagId);
go

insert into dbo.Articles(Topic, Author)
select N'Topic with one tag' , N'Peter I'       -- Id = 1
union all 
select N'Topic with few tags', N'Nickolay II'   -- Id = 2
union all 
select N'Topic with no tag'  , N'Alexander III' -- Id = 3

insert into dbo.Tags(Tag)
select N'Not used tag'   -- Id = 1
union all
select N'Used once tag'  -- Id = 2
union all
select N'Used twice tag' -- Id = 3

insert into dbo.ArticleTagLinks(ArticleId, TagId)
select 1,3
union all 
select 2,2
union all 
select 2,3

go

select a.Topic
     , t.Tag
from dbo.Articles               a 
  left join dbo.ArticleTagLinks l on a.Id = l.ArticleId
  left join dbo.Tags            t on l.TagId = t.Id  

