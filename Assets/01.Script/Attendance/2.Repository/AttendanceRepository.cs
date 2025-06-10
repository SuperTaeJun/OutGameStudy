using UnityEngine;
using System.Collections.Generic;
using System;
public class AttendanceRepository
{
    private const string SAVE_KEY = "AttendanceSaveData";

    public void Save(List<AttendanceDTO> attendances)
    {
        var saveDataList = new AttendanceSaveDataList
        {
            DataList = attendances.ConvertAll(dto => new AttendanceSaveData
            {
                ID = dto.ID,
                HasCheckedInToday = dto.HasCheckedInToday,
                LastCheckedDate = dto.LastCheckedDate.ToString("o") // ISO 8601 format
            })
        };

        string json = JsonUtility.ToJson(saveDataList);
        PlayerPrefs.SetString(SAVE_KEY, json);
        PlayerPrefs.Save();
    }

    public List<AttendanceDTO> Load(List<AttendanceSO> metaDatas)
    {
        if (!PlayerPrefs.HasKey(SAVE_KEY))
            return null;

        string json = PlayerPrefs.GetString(SAVE_KEY);
        var saveDataList = JsonUtility.FromJson<AttendanceSaveDataList>(json);

        List<AttendanceDTO> loadedDTOs = new List<AttendanceDTO>();

        foreach (var meta in metaDatas)
        {
            var saved = saveDataList.DataList.Find(s => s.ID == meta.ID);
            if (saved != null)
            {
                loadedDTOs.Add(new AttendanceDTO(
                    meta.ID,
                    meta.Day,
                    meta.RewardCurrencyType,
                    meta.RewardAmount,
                    saved.HasCheckedInToday,
                    DateTime.Parse(saved.LastCheckedDate)
                ));
            }
            else
            {
                loadedDTOs.Add(new AttendanceDTO(
                    meta.ID,
                    meta.Day,
                    meta.RewardCurrencyType,
                    meta.RewardAmount,
                    false,
                    DateTime.MinValue
                ));
            }
        }

        return loadedDTOs;
    }
}
[System.Serializable]
public class AttendanceSaveData
{
    public int ID;
    public bool HasCheckedInToday;
    public string LastCheckedDate; // DateTime을 문자열로 저장
}

[System.Serializable]
public struct AttendanceSaveDataList
{
    public List<AttendanceSaveData> DataList;
}