using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;
public class AchievementRepository
{
    private const string SAVE_KEY = "Achevement";

    public void Save(List<AchievementDTO> achivements)
    {
        AchievementSaveDataList datas = new AchievementSaveDataList();

        datas.DataList = achivements.ConvertAll(ahievement => new AchievementSaveData
        {
            ID = ahievement.ID,
            CurrentValue = ahievement.CurrentValue,
            RewardClaimed = ahievement.RewardClaimed
        });

        string json = JsonUtility.ToJson(datas);
        PlayerPrefs.SetString(SAVE_KEY, json);
    }

    public List<AchievementDTO> Load()
    {
        if(!PlayerPrefs.HasKey(SAVE_KEY))
        {
            return null;
        }


        string json = PlayerPrefs.GetString(SAVE_KEY);
        AchievementSaveDataList datas = JsonUtility.FromJson<AchievementSaveDataList>(json);

        return datas.DataList.ConvertAll<AchievementDTO>((a) => new AchievementDTO(a.ID,a.CurrentValue,a.RewardClaimed));
    }

}

[Serializable]
public class AchievementSaveData
{
    public string ID;
    public int CurrentValue;
    public bool RewardClaimed;
}


[Serializable]
public struct AchievementSaveDataList
{
    public List<AchievementSaveData> DataList;
}
