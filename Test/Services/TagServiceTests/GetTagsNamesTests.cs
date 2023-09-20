using Application.Contracts.Persistence;
using Application.Mapper;
using Application.Models.Responses;
using Application.Services;
using AutoMapper;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Mocks;
using Test.Mocks.Data;

namespace Test.Services.TagServiceTests
{
    public class GetTagsNamesTests : BaseTest
    {
        [Fact]
        public async Task Tag_GetTagsNames()
        {
            var _tagService = new TagService(_tagRepository.Object);

            var response = await _tagService.GetTagsNames();

            response.Success.ShouldBeTrue();
            response.Message.ShouldBeNullOrEmpty();
            response.Data.ShouldNotBeEmpty();
            response.Data.ShouldNotBeNull();
            response.Data.ShouldBeOfType<List<string>>();
        }
    }
}