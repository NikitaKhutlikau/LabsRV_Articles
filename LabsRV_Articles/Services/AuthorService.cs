using AutoMapper;
using LabsRV_Articles.Models.Domain;
using LabsRV_Articles.Models.DTO;
using LabsRV_Articles.Repositories;

namespace LabsRV_Articles.Services
{
    public class AuthorService : Service<Author, AuthorRequestDto, AuthorResponseDto>
    {
        public AuthorService(IRepository<Author> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }

        public override void Validate(AuthorRequestDto request)
        {
            if (string.IsNullOrWhiteSpace(request.login))
                throw new System.ArgumentException("Login is required.");
            if (string.IsNullOrWhiteSpace(request.password))
                throw new System.ArgumentException("Password is required.");
            if (string.IsNullOrWhiteSpace(request.firstname))
                throw new System.ArgumentException("FirstName is required.");
            if (string.IsNullOrWhiteSpace(request.lastname))
                throw new System.ArgumentException("LastName is required.");
        }
    }
}