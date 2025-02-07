using System;
namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract class JumpEngineA
{
    public virtual bool CanJump(int lengthOfJump)
    {
        if (lengthOfJump < 0)
        {
            throw new InvalidOperationException("Length Can not be -Value");
        }
        else if (lengthOfJump > 3)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}