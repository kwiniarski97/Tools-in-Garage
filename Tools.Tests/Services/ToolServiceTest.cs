using System;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Tools.Core.Domain;
using Tools.Core.Repositories;
using Tools.Infrastructure.Services.Implementations;
using Xunit;

namespace Tools.Tests.Services
{
    public class ToolServiceTest
    {
        [Fact]
        public async Task calling_addasync_should_add_one_tool_to_tool_repository_and_should_be_invoked_once()
        {
            var toolRepositoryMock = new Mock<IToolRepository>();
            var toolService = GetToolService(toolRepositoryMock);
            
            await toolService.AddAsync(Guid.NewGuid(), "test model", "test brand", "test type", 1);

            toolRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Tool>()), Times.Once());
        }

        [Fact]
        public async Task calling_getasync_should_get_tool_and_be_invoked_just_once()
        {
            var toolRepositoryMock = new Mock<IToolRepository>();
            var toolService = GetToolService(toolRepositoryMock);

            await toolService.GetAsync("string model");

            toolRepositoryMock.Verify(x => x.GetAsyncId(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task calling_getallasync_should_be_invoked_once()
        {
            var toolRepositoryMock = new Mock<IToolRepository>();
            var toolService = GetToolService(toolRepositoryMock);

            await toolService.GetAllAsync();

            toolRepositoryMock.Verify(x => x.GetAllAsync(), Times.Once());
        }

        [Fact]
        public async Task calling_delete_async_should_be_invoked_once()
        {
            var toolRepositoryMock = new Mock<IToolRepository>();
            var toolService = GetToolService(toolRepositoryMock);
            var id = Guid.NewGuid();

            await toolService.DeleteAsync(id);
            
            toolRepositoryMock.Verify(x=>x.DeleteAsync(It.IsAny<Guid>()),Times.Once);
        }

        [Fact]
        public async Task calling_update_async_should_be_invoked_once()
        {
            var toolRepositoryMock = new Mock<IToolRepository>();
            var toolService = GetToolService(toolRepositoryMock);
            var tool = new Tool(Guid.NewGuid(), "test model", "test brand", "test type", 1);

            await toolService.UpdateAsync(tool);
            
            toolRepositoryMock.Verify(x=> x.UpdateAsync(It.IsAny<Tool>()),Times.Once);
        }
        
        private static ToolService GetToolService(IMock<IToolRepository> toolRepositoryMock)
        {
            var mapperMock = new Mock<IMapper>();
            var toolService = new ToolService(toolRepositoryMock.Object, mapperMock.Object);
            return toolService;
        }
    }
}