using System;

namespace PasswordGenerator
{
    public interface IPasswordGenerator
    {
        string GeneratePassword(int length);
    }

}