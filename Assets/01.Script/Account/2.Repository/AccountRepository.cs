using System.Collections.Generic;
using System;
using UnityEngine;

public class AccountRepository : MonoBehaviour
{
    private const string SAVE_PREFIX = "Account_";

    public void Save(AccountDTO accountDTO)
    {
        AccountSaveData data = new AccountSaveData(accountDTO);
        string json = JsonUtility.ToJson(data);

        PlayerPrefs.SetString(SAVE_PREFIX + data.Email, json);
    }

    public AccountSaveData Load(string email)
    {
        if (!PlayerPrefs.HasKey(SAVE_PREFIX + email))
        {
            return null;
        }

        return JsonUtility.FromJson<AccountSaveData>(PlayerPrefs.GetString(SAVE_PREFIX + email));
    }


}
[Serializable]
public class AccountSaveData
{
    public string Email;
    public string Nickname;
    public string Passward;
    public AccountSaveData(AccountDTO accountDTO)
    {
        Email = accountDTO.Email;
        Nickname = accountDTO.Nickname;
        Passward = accountDTO.Password;
    }
}
