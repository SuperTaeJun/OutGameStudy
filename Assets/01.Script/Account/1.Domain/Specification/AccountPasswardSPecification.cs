using System;
using UnityEngine;

public class AccountPasswardSPecification : ISpecification<string>
{
    public string ErrorMessage { get; private set; }

    public bool IsStatisfiedBy(string value)
    {

        if (value.Length < 6 || value.Length > 12)
        {
            ErrorMessage = "비밀번호는 6자 이상 12자 이하이어야 합니다.";
            return false;

        }
        return true;
    }

}
