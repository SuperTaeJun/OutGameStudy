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
    public Attendance(AttendanceSO attendanceSO, AttendanceDTO savedData = null)
    {
        ID = attendanceSO.ID;
        Day = attendanceSO.Day;
        RewardCurrencyType = attendanceSO.RewardCurrencyType;
        RewardAmount = attendanceSO.RewardAmount;

        if (savedData != null)
        {
            _hasCheckedInToday = savedData.HasCheckedInToday;
            _lastCheckedDate = savedData.LastCheckedDate;
        }
        else
        {
            _hasCheckedInToday = false;
            _lastCheckedDate = DateTime.MinValue;
        }
    }

    public void MarkCheckedIn()
    {
        _lastCheckedDate = DateTime.UtcNow;
    }

    public bool TryCheckIn()
    {
        DateTime now = DateTime.UtcNow;

        TimeSpan diff = now - _lastCheckedDate;

        if (diff.TotalMinutes < 1)
            return false; // 1분 안 지났으면 출석 불가

        _lastCheckedDate = now;
        _hasCheckedInToday = true;
        return true;
    }
    public TimeSpan GetRemainingTime()
    {
        TimeSpan interval = TimeSpan.FromMinutes(1);
        return DateTime.UtcNow - _lastCheckedDate >= interval
            ? TimeSpan.Zero
            : (_lastCheckedDate + interval - DateTime.UtcNow);
    }
}
