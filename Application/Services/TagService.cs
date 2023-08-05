using Application.Contracts.Persistence;
using Application.Models.Enums;
using Application.Models;
using Application.Models.Responses;
using Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<BaseResponse<List<string>>> GetTagsNames()
        {
            var tags = await _tagRepository.GetAllDistinctByName();

            if (tags == null || !tags.Any())
            {
                return new BaseResponse<List<string>>(false);
            }

            return new BaseResponse<List<string>>(tags.Select(x => x.Name).ToList());
        }
    }
}
