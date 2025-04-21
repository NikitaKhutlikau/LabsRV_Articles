using AutoMapper;
using LabsRV_Articles.Models.Domain;
using LabsRV_Articles.Models.DTO;
using LabsRV_Articles.Repositories;

namespace LabsRV_Articles.Services
{
    public class ArticleService : Service<Article, ArticleRequestDto, ArticleResponseDto>
    {
        public ArticleService(IRepository<Article> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }

        public override void Validate(ArticleRequestDto request)
        {
            if (request.authorId <= 0)
                throw new System.ArgumentException("A valid AuthorId is required.");
            if (string.IsNullOrWhiteSpace(request.title))
                throw new System.ArgumentException("Title is required.");
            if (string.IsNullOrWhiteSpace(request.content))
                throw new System.ArgumentException("Content is required.");
        }
    }
}
