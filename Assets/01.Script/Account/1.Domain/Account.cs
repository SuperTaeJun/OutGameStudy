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
        // 규칙을 객체로 캡슐화
        // 캡슐화한 규칙 : 명세

        // 이메일 검증
        var emailSpecification = new AccountEmailSpecification();

        if(!emailSpecification.IsStatisfiedBy(email))
        {
            throw new Exception(emailSpecification.ErrorMessage);
        }

        //닉네임 검증
        var nickNameSpecification = new AccountNicknameSpecification();
        if(!nickNameSpecification.IsStatisfiedBy(nickname))
        {
            throw new Exception(nickNameSpecification.ErrorMessage);
        }


        // 비밀번호 검증

        if (string.IsNullOrEmpty(password))
        {
            throw new Exception("비밀번호는 비어있을 수 없습니다.");
        }




        Email = email;
        Nickname = nickname;
        Password = password;
    }
}