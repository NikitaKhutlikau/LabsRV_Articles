using AutoMapper;
using LabsRV_Articles.Models.Domain;
using LabsRV_Articles.Models.DTO;
using LabsRV_Articles.Repositories;

namespace LabsRV_Articles.Services
{
    public class CommentService : Service<Comment, CommentRequestDto, CommentResponseDto>
    {
        public CommentService(IRepository<Comment> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }

        public override void Validate(CommentRequestDto request)
        {
            if (request.articleId <= 0)
                throw new System.ArgumentException("A valid ArticleId is required for a comment.");
            if (string.IsNullOrWhiteSpace(request.content))
                throw new System.ArgumentException("Content is required for a comment.");
        }
    }
}
