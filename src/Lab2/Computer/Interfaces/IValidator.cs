namespace Itmo.ObjectOrientedProgramming.Lab2;

public interface IValidator
{
    public void CheckMotherBoardSocketandCpuSocket();
    public void CheckIsDdrofRamAllowdedInMotherBoard();
    public void CheckListOfSupportedProcessorsOfBios();
    public void CheckSizeofCoolerandCase();
    public void CheckSocketsOfCoolerAndCpu();
    public void CheckIsPowerUnitCapacity();
    public void CheckIsHeatDissipation();
    public void CheckIsFrencyofVideoCardInListOfCpu();
    public void CheckCompatibilityOfVideoCardXmpMotherBoardXmpCpuFrequencies();
    public void CheckFormFactorMotherBoardToComputerCase();
    public void CheckSizeVideoCardToComputerCase();
    public void CheckGraphicCoreInCpuActiveOrVideoCardExistence();
    public bool IsListOfErrorsEmpty();
    public void PrintErrors();
    public void ProcessingTheResult();
}