using Xunit;
namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public static class Test
{
    [Theory]
    [MemberData(nameof(TestData.Test1BuildingComputerSuccesfullyData), MemberType = typeof(TestData))]
    public static void Test1BuildingComputerSuccesfully(ComputerCase shell, Cooler cooler, Cpu cpu, MotherBoard motherBoard, PowerUnit powerUnit, Ram ram, Bios bios, WiFiAdapter wifiAdapter, XmpProfile xmpProfile, Hsd hsd, Ssd ssd, VideoCard videoCard)
    {
        var computerBuilder = new ComputerBuilder();
        computerBuilder
            .AddAllComponents(shell, cooler, cpu, motherBoard, powerUnit, ram, bios, wifiAdapter, xmpProfile, hsd, ssd, videoCard);
        Computer computer = computerBuilder.Build();
        var errors = new Validator(computer);
        errors.ProcessingTheResult();
        Assert.True(computer is not null);
        Assert.True(errors.IsListOfErrorsEmpty());
        Assert.True(errors.IsGuaranteeActive == true);
    }

    [Theory]
    [MemberData(nameof(TestData.Test2BuildingComputerSuccesfullyButWithWarningData), MemberType = typeof(TestData))]
    public static void Test2BuildingComputerSuccesfullyButWithWarning(ComputerCase shell, Cooler cooler, Cpu cpu, MotherBoard motherBoard, PowerUnit powerUnit, Ram ram, Bios bios, WiFiAdapter wifiAdapter, XmpProfile xmpProfile, Hsd hsd, Ssd ssd, VideoCard videoCard)
    {
        var computerBuilder = new ComputerBuilder();
        computerBuilder
            .AddAllComponents(shell, cooler, cpu, motherBoard, powerUnit, ram, bios, wifiAdapter, xmpProfile, hsd, ssd, videoCard);
        Computer computer = computerBuilder.Build();
        var errors = new Validator(computer);
        errors.ProcessingTheResult();
        Assert.True(errors.IsListOfErrorsEmpty());
        Assert.True(errors.Warning == true);
    }

    [Theory]
    [MemberData(nameof(TestData.Test3BuildingComputerSuccesfullyData), MemberType = typeof(TestData))]
    public static void Test3BuildingComputerSuccesfullyButWithDisclaimerOfWarranty(ComputerCase shell, Cooler cooler, Cpu cpu, MotherBoard motherBoard, PowerUnit powerUnit, Ram ram, Bios bios, WiFiAdapter wifiAdapter, XmpProfile xmpProfile, Hsd hsd, Ssd ssd, VideoCard videoCard)
    {
        var computerBuilder = new ComputerBuilder();
        computerBuilder
            .AddAllComponents(shell, cooler, cpu, motherBoard, powerUnit, ram, bios, wifiAdapter, xmpProfile, hsd, ssd, videoCard);
        Computer computer = computerBuilder.Build();
        var errors = new Validator(computer);
        errors.ProcessingTheResult();
        Assert.True(errors.IsListOfErrorsEmpty());
        Assert.True(errors.IsGuaranteeActive == false);
    }

    [Theory]
    [MemberData(nameof(TestData.Test4BuildingComputerFailedBecauseOfFrequencyOfVideoCardData), MemberType = typeof(TestData))]
    public static void Test4BuildingComputerFailedBecauseOfFrequencyOfVideoCard(ComputerCase shell, Cooler cooler, Cpu cpu, MotherBoard motherBoard, PowerUnit powerUnit, Ram ram, Bios bios, WiFiAdapter wifiAdapter, XmpProfile xmpProfile, Hsd hsd, Ssd ssd, VideoCard videoCard)
    {
        var computerBuilder = new ComputerBuilder();
        computerBuilder
            .AddAllComponents(shell, cooler, cpu, motherBoard, powerUnit, ram, bios, wifiAdapter, xmpProfile, hsd, ssd, videoCard);
        Computer computer = computerBuilder.Build();
        var errors = new Validator(computer);
        errors.ProcessingTheResult();
        errors.PrintErrors();
        Assert.False(errors.IsListOfErrorsEmpty());
    }
}