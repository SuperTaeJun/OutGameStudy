using System;
using UnityEngine;

public class Attendance 
{
    public readonly int ID;
    public readonly int Day;

    public readonly ECurrencyType RewardCurrencyType;
    public readonly int RewardAmount;

    private bool _hasCheckedInToday;
    public bool HasCheckedInToday => _hasCheckedInToday;
    private DateTime _lastCheckedDate;
    public DateTime LastCheckedDate => _lastCheckedDate;
    public Attendance(AttendanceSO attendanceSO)
    {
        ID = attendanceSO.ID;
        Day = attendanceSO.Day;
        RewardCurrencyType = attendanceSO.RewardCurrencyType;
        RewardAmount = attendanceSO.RewardAmount;

        _hasCheckedInToday = false;
        _lastCheckedDate = DateTime.MinValue;
    }

    public void MarkCheckedIn()
    {
        _lastCheckedDate = DateTime.UtcNow;
    }
}
