using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2;

public class Validator : IValidator
{
    private readonly Computer computer;
    private List<string> listOfErrors = new List<string>();

    public Validator(Computer computer)
    {
        this.computer = computer;
    }

    public bool IsGuaranteeActive { get; private set; } = true;
    public bool Warning { get; private set; }

    public void CheckMotherBoardSocketandCpuSocket()
    {
        try
        {
            if (computer.MotherBoard?.SocketCpu != computer.Cpu?.SocketCpu) throw new ArgumentException("Mother Socket doesnt match the Cpu Socket");
        }
        catch (ArgumentException)
        {
            listOfErrors.Add("Mother Socket doesnt match the Cpu Socket");
        }
    }

    public void CheckIsDdrofRamAllowdedInMotherBoard()
    {
        try
        {
            if (computer.Ram?.DDRstandardVersion != computer.MotherBoard?.SupportedDDRStandart) throw new ArgumentException("Mother Socket doesnt match the Cpu Socket");
        }
        catch (ArgumentException)
        {
            listOfErrors.Add("DDR of RAM doesn't allowed in Mother Board");
        }
    }

    public void CheckListOfSupportedProcessorsOfBios()
    {
        try
        {
            if (computer.Bios.SupportedProcessors.Contains(computer.Cpu.SocketCpu))
            {
            }
            else
            {
                throw new ArgumentException("BIOS doesnt support CPU");
            }
        }
        catch (ArgumentException)
        {
            listOfErrors.Add("BIOS doesnt support CPU");
        }
    }

    public void CheckSizeofCoolerandCase()
    {
        try
        {
            if (computer.ComputerCase?.Size < computer.Cooler?.Size)
            {
                throw new ArgumentException("Computer case is smaller then Cooler");
            }
        }
        catch (ArgumentException)
        {
            listOfErrors.Add("Computer case is smaller then Cooler");
        }
    }

    public void CheckSocketsOfCoolerAndCpu()
    {
        try
        {
            if (computer.Cooler.SupportedSockets.Contains(computer.Cpu.SocketCpu))
            {
            }
            else
            {
                throw new ArgumentException("Cooler doesnt support Cpu");
            }
        }
        catch (ArgumentException)
        {
            listOfErrors.Add("Cooler doesnt support Cpu");
        }
    }

    public void CheckIsPowerUnitCapacity()
    {
        try
        {
            if (computer.PowerUnit.MaxProductingOfEnergy < computer.SummOfEnergyConsumption())
            {
                throw new ArgumentException("Consumption is bigger than Producting");
            }
        }
        catch (ArgumentException)
        {
            Warning = true;
        }
    }

    public void CheckIsHeatDissipation()
    {
        try
        {
            if (computer.Cooler.MaximumHeatDissipation < computer.SummOfHeatProduction())
            {
                throw new ArgumentException("Heat is bigger than Disspation");
            }
        }
        catch (ArgumentException)
        {
            IsGuaranteeActive = false;
        }
    }

    public void CheckIsFrencyofVideoCardInListOfCpu()
    {
        try
        {
            if (computer.Cpu.SupportedFrequencies.Contains(computer.VideoCard.Frequency))
            {
            }
            else
            {
                throw new ArgumentException("CPU doesnt support frequencies of Videocard");
            }
        }
        catch (ArgumentException)
        {
            listOfErrors.Add("CPU doesnt support frequencies of Videocard");
        }
    }

    public void CheckCompatibilityOfVideoCardXmpMotherBoardXmpCpuFrequencies()
    {
        try
        {
            if (computer.Cpu.SupportedFrequencies.Contains(computer.Ram.AvailableXMPDOСProfile) &&
                computer.MotherBoard.IsSupportingXmp == true)
            {
            }
            else
            {
                throw new ArgumentException("CPU doesnt support frequencies of Ram");
            }
        }
        catch (ArgumentException)
        {
            listOfErrors.Add("CPU doesnt support frequencies of Ram");
        }
    }

    public void CheckFormFactorMotherBoardToComputerCase()
    {
        try
        {
            if (computer.ComputerCase.ListFormFactorOfMotherPlate.Contains(computer.MotherBoard.FormFactor))
            {
            }
            else
            {
                throw new ArgumentException("Computer case case doesnt support Mother Board");
            }
        }
        catch (ArgumentException)
        {
           listOfErrors.Add("Computer case case doesnt support Mother Board");
        }
    }

    public void CheckSizeVideoCardToComputerCase()
    {
        try
        {
            if (computer.ComputerCase.MaxLengthofVideoCard < computer.VideoCard.Length &&
                computer.ComputerCase.MaxWidthofVideoCard < computer.VideoCard.Width)
            {
                throw new ArgumentException("Video card is too big");
            }
        }
        catch (ArgumentException)
        {
            listOfErrors.Add("Video card is too big");
        }
    }

    public void CheckGraphicCoreInCpuActiveOrVideoCardExistence()
    {
        try
        {
            if (computer.Cpu.HasGraphicCore == false && computer.VideoCard is null)
            {
                throw new ArgumentException("Computer cant work correctly without GPU");
            }
        }
        catch (ArgumentException)
        {
            listOfErrors.Add("Computer cant work correctly without GPU");
        }
    }

    public bool IsListOfErrorsEmpty()
    {
        if (listOfErrors.Count == 0)
        {
            return true;
        }

        return false;
    }

    public void PrintErrors()
    {
        foreach (string error in listOfErrors)
        {
            Console.WriteLine(error);
        }
    }

    public void ProcessingTheResult()
    {
        CheckMotherBoardSocketandCpuSocket();
        CheckIsDdrofRamAllowdedInMotherBoard();
        CheckListOfSupportedProcessorsOfBios();
        CheckSizeofCoolerandCase();
        CheckSocketsOfCoolerAndCpu();
        CheckIsPowerUnitCapacity();
        CheckIsHeatDissipation();
        CheckIsFrencyofVideoCardInListOfCpu();
        CheckCompatibilityOfVideoCardXmpMotherBoardXmpCpuFrequencies();
        CheckFormFactorMotherBoardToComputerCase();
        CheckSizeVideoCardToComputerCase();
        CheckGraphicCoreInCpuActiveOrVideoCardExistence();
    }
}