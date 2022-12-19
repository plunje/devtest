using Refactoring.Commands;
using Refactoring.Constants;
using Refactoring.Factories;

namespace Refactoring.UnitTest.Factories;

public class CommandFactoryTests
{
    [Theory]
    [InlineAutoDomainData(CommandTexts.Create)]
    [InlineAutoDomainData(CommandTexts.Sum)]
    [InlineAutoDomainData(CommandTexts.Reset)]
    [InlineAutoDomainData(CommandTexts.Print)]
    [InlineAutoDomainData(CommandTexts.Questionmark)]
    public void GetCommand_CreateCommand_HappyFlow(
        string command,
        [Frozen] Mock<IServiceProvider> serviceProviderMock,
        CommandFactory sut,
        Mock<CreateCommand> createCommand,
        Mock<SumCommand> sumCommand,
        Mock<ResetCommand> resetCommand,
        Mock<PrintCommand> printCommand,
        Mock<ShowCommandsCommand> showCommandsCommand,
        string[] args)
    {
        //Arrange
        args[0] = command.ToUpper();

        serviceProviderMock.Setup(x => x.GetService(typeof(CreateCommand))).Returns(createCommand.Object);
        serviceProviderMock.Setup(x => x.GetService(typeof(SumCommand))).Returns(sumCommand.Object);
        serviceProviderMock.Setup(x => x.GetService(typeof(ResetCommand))).Returns(resetCommand.Object);
        serviceProviderMock.Setup(x => x.GetService(typeof(PrintCommand))).Returns(printCommand.Object);
        serviceProviderMock.Setup(x => x.GetService(typeof(ShowCommandsCommand))).Returns(showCommandsCommand.Object);

        //Act
        var result = sut.GetCommand(args);

        //Assert
        result.Should().NotBeNull();
    }

    [Theory]
    [AutoDomainData]
    public void GetCommand_Exit_ReturnsNull(
        CommandFactory sut,
        string[] args)
    {
        //Arrange
        args[0] = CommandTexts.Exit;

        //Act
        var result = sut.GetCommand(args);

        //Assert
        result.Should().BeNull();
    }

    [Theory]
    [AutoDomainData]
    public void GetCommand_InputNotSupported_ThrowsNotSupportedException(
        CommandFactory sut,
        string[] args)
    {
        //Arrange
        args[0] = "Something else";

        //Act
        Action act = () => sut.GetCommand(args);

        //Assert
        act.Should().ThrowExactly<NotSupportedException>()
            .WithMessage($"Unknown command '{args[0]}'");
    }

    [Theory]
    [AutoDomainData]
    public void GetCommand_InputNull_ThrowsArgumentException(
        CommandFactory sut)
    {
        //Act
        Action act = () => sut.GetCommand(null);

        //Assert
        act.Should().ThrowExactly<ArgumentNullException>()
            .WithParameterName("args");
    }

    [Theory]
    [AutoDomainData]
    public void GetCommand_InvalidArgumentCount_ThrowsArgumentException(
        CommandFactory sut)
    {
        var fixture = new Helpers.AutoFixture();
        var args = Array.Empty<string>();

        //Act
        Action act = () => sut.GetCommand(args);

        //Assert
        act.Should().ThrowExactly<ArgumentException>()
            .WithMessage($"1 elements or more were expected, but found 0 (Parameter 'args')");
    }
}
