using Refactoring.Commands.Interfaces;
using Refactoring.Factories.Interfaces;
using Refactoring.Services;
using Refactoring.Services.Interfaces;

namespace Refactoring.UnitTest.Services;

public class StateMachineServiceTests
{
    [Theory]
    [AutoDomainData]
    public void Go_HappyFlow(
        [Frozen] Mock<ICommandFactory> commandFactoryMock,
        [Frozen] Mock<IDisplayService> displayServiceMock,
        StateMachineService sut)
    {
        displayServiceMock.SetupSequence(x => x.ReadLine())
            .Returns("commando pinkelen")
            .Returns("commando hol")
            .Returns("commando bol")
            .Returns("commando plat");

        commandFactoryMock.Setup(x => x.GetCommand(It.Is<string[]>(
            x => x.Count() == 2 && x[0] == "commando" && x[1] == "plat")))
            .Returns((ICommand)null);

        //Act
        sut.Go();

        //Assert
        commandFactoryMock.Verify(x => x.GetCommand(It.IsAny<string[]>()), Times.Exactly(4));
    }
}
