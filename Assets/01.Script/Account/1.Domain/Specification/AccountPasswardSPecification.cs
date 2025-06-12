using System;
using UnityEngine;

public class AccountPasswardSPecification : ISpecification<string>
{
    public string ErrorMessage { get; private set; }

    public bool IsStatisfiedBy(string value)
    {

        if (value.Length < 6 || value.Length > 12)
        {
            ErrorMessage = "��й�ȣ�� 6�� �̻� 12�� �����̾�� �մϴ�.";
            return false;

        }
        return true;
    }

}
