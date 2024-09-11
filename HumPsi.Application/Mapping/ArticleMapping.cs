using AutoMapper;
using HumPsi.Application.CommandQuery.Article.Commands.CreateArticleCommand;
using HumPsi.Application.CommandQuery.Article.Commands.UpdateArticleCommand;
using HumPsi.Application.CommandQuery.Article.Queries.GetAllArticleQuery;
using HumPsi.Domain.Entities;

namespace HumPsi.Application.Mapping.Section;

public class ArticleMapping : Profile
{
    public ArticleMapping()
    {
        CreateMap<ArticleEntity, GetArticleDtoResponse>()
            .ForMember(des => des.id,
                src => src.MapFrom(a => a.Id))
            .ForMember(des => des.title,
                src => src.MapFrom(a => a.Title))
            .ForMember(des => des.content,
                src => src.MapFrom(a => a.Content))
            .ForMember(des => des.createAt,
                src => src.MapFrom(a => a.CreateAt))
            .ForMember(des => des.photoPath,
                src => src.MapFrom(a => a.PhotoPath));
        
        CreateMap<CreateArticleDtoRequest, ArticleEntity>()
            .ForMember(des => des.Id,
                src => src.MapFrom(a => Guid.NewGuid()))
            .ForMember(des => des.Title,
                src => src.MapFrom(a => a.title))
            .ForMember(des => des.Content,
                src => src.MapFrom(a => a.content))
            .ForMember(des => des.CreateAt,
                src => src.MapFrom(a => DateTime.Now.ToUniversalTime()))
            .ForMember(des => des.HeadlineId,
                src => src.MapFrom(a => a.headlineId));
        
        CreateMap<UpdateArticleDtoRequest, ArticleEntity>()
            .ForMember(des => des.Id,
                src => src.MapFrom(a => a.id))
            .ForMember(des => des.Title,
                src => src.MapFrom(a => a.title))
            .ForMember(des => des.Content,
                src => src.MapFrom(a => a.content))
            .ForMember(des => des.CreateAt,
                src => src.MapFrom(a => DateTime.Now.ToUniversalTime()))
            .ForMember(des => des.HeadlineId,
                src => src.MapFrom(a => a.headlineId));
    }
}