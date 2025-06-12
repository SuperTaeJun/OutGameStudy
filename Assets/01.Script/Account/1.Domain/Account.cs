using System;
using System.Text.RegularExpressions;
using UnityEngine;

public class Account
{
    public readonly string Email;
    public readonly string Nickname;
    public readonly string Password;

    public Account(string email, string nickname, string password)
    {
        // ��Ģ�� ��ü�� ĸ��ȭ
        // ĸ��ȭ�� ��Ģ : ��

        // �̸��� ����
        var emailSpecification = new AccountEmailSpecification();

        if(!emailSpecification.IsStatisfiedBy(email))
        {
            throw new Exception(emailSpecification.ErrorMessage);
        }

        //�г��� ����
        var nickNameSpecification = new AccountNicknameSpecification();
        if(!nickNameSpecification.IsStatisfiedBy(nickname))
        {
            throw new Exception(nickNameSpecification.ErrorMessage);
        }


        // ��й�ȣ ����

        if (string.IsNullOrEmpty(password))
        {
            throw new Exception("��й�ȣ�� ������� �� �����ϴ�.");
        }




        Email = email;
        Nickname = nickname;
        Password = password;
    }
}