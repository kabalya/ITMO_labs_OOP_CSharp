using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public static class TestData
{
    public static IEnumerable<object[]> Test1BuildingComputerSuccesfullyData()
    {
        yield return new object[]
        {
            new ComputerCase(20, 10, 20, new List<string>() { "АTX", "Mini-ATX", "Micro-ATX" }, 200),
            new Cooler(2, new List<string>() { "Intel 1250", "Intel 1000", "Intel LGA 775", "Intel LGA 1700" }, 100),
            new Cpu("Intel i5 2030", 3000, 3, "Intel LGA 775", true, new List<string>() { "3000", "1000", "2000" }, 20, 10),
            new MotherBoard("Intel LGA 775", 10, 9, new List<string>() { "3000", "1000", "2000" }, true, "DDR 4", 4, "АTX", "Legasy", "BIOS	American Megatrends International, LLC. E17L4IMS.10E, 22.06.2022"),
            new PowerUnit(357),
            new Ram(3, new List<string>() { "130", "110", "120", "310", "170", "1000" }, "1000", "DIMM", "DDR 4", 10),
            new Bios("Legasy", "BIOS	American Megatrends International, LLC. E17L4IMS.10E, 22.06.2022", new List<string>() { "Intel LGA 775", "Intel LGA 675", "Intel LGA 575" }),
            new WiFiAdapter("45v28ffA", true, "V25w47B", 2),
            new XmpProfile("10-20-10-60", 7, 1000),
            new Hsd(64, 280, 5),
            new Ssd(true, 128, 320, 5),
            new VideoCard(5, 2, "V25w47B", "1000", 1),
        };
    }

    public static IEnumerable<object[]> Test2BuildingComputerSuccesfullyButWithWarningData()
    {
        yield return new object[]
        {
            new ComputerCase(20, 10, 20, new List<string>() { "АTX", "Mini-ATX", "Micro-ATX" }, 200),
            new Cooler(2, new List<string>() { "Intel 1250", "Intel 1000", "Intel LGA 775", "Intel LGA 1700" }, 100),
            new Cpu("Intel i5 2030", 3000, 3, "Intel LGA 775", true, new List<string>() { "3000", "1000", "2000" }, 200, 10),
            new MotherBoard("Intel LGA 775", 10, 9, new List<string>() { "3000", "1000", "2000" }, true, "DDR 4", 4, "АTX", "Legasy", "BIOS	American Megatrends International, LLC. E17L4IMS.10E, 22.06.2022"),
            new PowerUnit(357),
            new Ram(3, new List<string>() { "130", "110", "120", "310", "170", "1000" }, "1000", "DIMM", "DDR 4", 10),
            new Bios("Legasy", "BIOS	American Megatrends International, LLC. E17L4IMS.10E, 22.06.2022", new List<string>() { "Intel LGA 775", "Intel LGA 675", "Intel LGA 575" }),
            new WiFiAdapter("45v28ffA", true, "V25w47B", 200),
            new XmpProfile("10-20-10-60", 7, 1000),
            new Hsd(64, 280, 55),
            new Ssd(true, 128, 320, 50),
            new VideoCard(5, 2, "V25w47B", "1000", 200),
        };
    }

    public static IEnumerable<object[]> Test3BuildingComputerSuccesfullyData()
    {
        yield return new object[]
        {
            new ComputerCase(20, 10, 20, new List<string>() { "АTX", "Mini-ATX", "Micro-ATX" }, 200),
            new Cooler(2, new List<string>() { "Intel 1250", "Intel 1000", "Intel LGA 775", "Intel LGA 1700" }, 100),
            new Cpu("Intel i5 2030", 3000, 3, "Intel LGA 775", true, new List<string>() { "3000", "1000", "2000" }, 101, 10),
            new MotherBoard("Intel LGA 775", 10, 9, new List<string>() { "3000", "1000", "2000" }, true, "DDR 4", 4, "АTX", "Legasy", "BIOS	American Megatrends International, LLC. E17L4IMS.10E, 22.06.2022"),
            new PowerUnit(357),
            new Ram(3, new List<string>() { "130", "110", "120", "310", "170", "1000" }, "1000", "DIMM", "DDR 4", 10),
            new Bios("Legasy", "BIOS	American Megatrends International, LLC. E17L4IMS.10E, 22.06.2022", new List<string>() { "Intel LGA 775", "Intel LGA 675", "Intel LGA 575" }),
            new WiFiAdapter("45v28ffA", true, "V25w47B", 2),
            new XmpProfile("10-20-10-60", 7, 1000),
            new Hsd(64, 280, 5),
            new Ssd(true, 128, 320, 5),
            new VideoCard(5, 2, "V25w47B", "1000", 1),
        };
    }

    public static IEnumerable<object[]> Test4BuildingComputerFailedBecauseOfFrequencyOfVideoCardData()
    {
        yield return new object[]
        {
            new ComputerCase(20, 10, 20, new List<string>() { "АTX", "Mini-ATX", "Micro-ATX" }, 200),
            new Cooler(2, new List<string>() { "Intel 1250", "Intel 1000", "Intel LGA 775", "Intel LGA 1700" }, 100),
            new Cpu("Intel i5 2030", 3000, 3, "Intel LGA 775", true, new List<string>() { "3000", "1000", "2000" }, 101, 10),
            new MotherBoard("Intel LGA 775", 10, 9, new List<string>() { "3000", "1000", "2000" }, true, "DDR 4", 4, "АTX", "Legasy", "BIOS	American Megatrends International, LLC. E17L4IMS.10E, 22.06.2022"),
            new PowerUnit(357),
            new Ram(3, new List<string>() { "130", "110", "120", "310", "170", "1000" }, "1000", "DIMM", "DDR 4", 10),
            new Bios("Legasy", "BIOS	American Megatrends International, LLC. E17L4IMS.10E, 22.06.2022", new List<string>() { "Intel LGA 775", "Intel LGA 675", "Intel LGA 575" }),
            new WiFiAdapter("45v28ffA", true, "V25w47B", 2),
            new XmpProfile("10-20-10-60", 7, 1000),
            new Hsd(64, 280, 5),
            new Ssd(true, 128, 320, 5),
            new VideoCard(5, 2, "V25w47B", "100000", 1),
        };
    }
}