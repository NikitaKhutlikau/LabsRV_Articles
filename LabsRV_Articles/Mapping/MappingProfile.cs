using AutoMapper;
using LabsRV_Articles.Models.Domain;
using LabsRV_Articles.Models.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LabsRV_Articles.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Маппинг для авторов с обязательным заполнением списка ArticleIds
            CreateMap<Author, AuthorResponseDto>()
                .ForMember(dest => dest.ArticleIds, opt => opt.MapFrom(src => src.Articles.Select(a => a.Id).ToList()));
            CreateMap<AuthorRequestDto, Author>();

            // Маппинг для статей
            CreateMap<Article, ArticleResponseDto>();
            CreateMap<ArticleRequestDto, Article>();

            // Маппинг для комментариев
            CreateMap<Comment, CommentResponseDto>();
            CreateMap<CommentRequestDto, Comment>();

            // Маппинг для стикеров
            CreateMap<Sticker, StickerResponseDto>();
            CreateMap<StickerRequestDto, Sticker>();
        }
    }
}
