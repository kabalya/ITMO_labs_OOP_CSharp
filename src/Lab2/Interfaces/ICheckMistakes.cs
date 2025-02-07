namespace Itmo.ObjectOrientedProgramming.Lab2;

public interface ICheckMistakes
{
    public bool CheckMotherBoardSocketandCPUSocket();
    public bool CheckIsDDRofRamAllowdedInMotherBoard();
    public bool CheckListOfSupportedProcessorsOfBIOS();
    public bool CheckSizeofCoolerandCase();
    public bool CheckSocketsOfCoolerAndCPU();
    public bool CheckIsPowerUnitCapacity();
    public bool CheckIsHeatDissipation();
    public bool CheckIsFrencyofVideoCardInListOfCPU();
    public bool CheckCompatibilityOfVideoCardXMPMotherBoardXMPCPUFrequencies();
    public bool CheckFormFactorMotherBoardToComputerCase();
    public bool CheckSizeVideoCardToComputerCase();
    public bool CheckGraphicCoreInCPUActiveOrVideoCardExistence();
}