using AutoMapper;
using NUnit.Framework;
using TodoList.Data.Entities;
using TodoList.Service.Dtos;
using TodoList.Service.Mappings;

namespace TodoList.UnitTests
{
    public class MappingTests
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = _configuration.CreateMapper();
        }

        [Test]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Test]
        public void ShouldSupportMapping()
        {
            var instance = new TodoItem();

            _mapper.Map(instance, typeof(TodoItem), typeof(TodoItemDto));
        }
    }
}