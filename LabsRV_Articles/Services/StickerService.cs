using AutoMapper;
using LabsRV_Articles.Models.Domain;
using LabsRV_Articles.Models.DTO;
using LabsRV_Articles.Repositories;

namespace LabsRV_Articles.Services
{
    public class StickerService : Service<Sticker, StickerRequestDto, StickerResponseDto>
    {
        public StickerService(IRepository<Sticker> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }

        public override void Validate(StickerRequestDto request)
        {
            if (string.IsNullOrWhiteSpace(request.name))
                throw new System.ArgumentException("Name is required for a sticker.");
        }
    }
}
