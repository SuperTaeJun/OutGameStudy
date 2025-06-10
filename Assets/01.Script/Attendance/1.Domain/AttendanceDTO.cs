using System;
using UnityEngine;

public class AttendanceDTO 
{
    public readonly int ID;
    public readonly int Day;
    public readonly ECurrencyType RewardCurrencyType;
    public readonly int RewardAmount;
    public readonly bool HasCheckedInToday;
    public readonly DateTime LastCheckedDate;

    public AttendanceDTO(int id, int day, ECurrencyType rewardCurrencyType, int rewardAmount, bool hasCheckedInToday, DateTime lastCheckedDate)
    {
        ID = id;
        Day = day;
        RewardCurrencyType = rewardCurrencyType;
        RewardAmount = rewardAmount;
        HasCheckedInToday = hasCheckedInToday;
        LastCheckedDate = lastCheckedDate;
    }

    public AttendanceDTO(Attendance attendance)
    {
        ID = attendance.ID;
        Day = attendance.Day;
        RewardCurrencyType = attendance.RewardCurrencyType;
        RewardAmount = attendance.RewardAmount;
        HasCheckedInToday = attendance.HasCheckedInToday;
        LastCheckedDate = attendance.LastCheckedDate; // 접근자 필요
    }
}
