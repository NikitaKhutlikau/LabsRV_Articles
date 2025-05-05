using AutoMapper;
using LabsRV_Articles.Models.Domain;
using LabsRV_Articles.Models.DTO;
using LabsRV_Articles.Repositories;

namespace LabsRV_Articles.Services
{
    public class CommentService : Service<Comment, CommentRequestDto, CommentResponseDto>
    {
        public CommentService(IRepository<Comment> repository, IMapper mapper)
            : base(repository, mapper) { }

        public override void Validate(CommentRequestDto request)
        {
            if (request.ArticleId <= 0)
                throw new ArgumentException("A valid ArticleId is required for a comment.");
            if (string.IsNullOrWhiteSpace(request.Content) || request.Content.Length < 2 || request.Content.Length > 2048)
                throw new ArgumentException("Content must be between 2 and 2048 characters.");
        }
    }
}
