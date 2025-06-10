using System;
using System.Collections.Generic;
using UnityEngine;

public class AttendanceManager : MonoBehaviour
{
    public static AttendanceManager Instance;

    [SerializeField] private List<AttendanceSO> _metaDatas;

    private List<Attendance> _attendances;
    public List<AttendanceDTO> Attendances => _attendances.ConvertAll(a => new AttendanceDTO(a));

    private AttendanceRepository _repository;

    public event Action OnDataChanged;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

        Init();
    }

    private void Init()
    {

        _repository = new AttendanceRepository();
        _attendances = new List<Attendance>();

        List<AttendanceDTO> loadedData = _repository.Load(_metaDatas);

        foreach (AttendanceSO data in _metaDatas)
        {
            AttendanceDTO savedData = loadedData?.Find(d => d.ID == data.ID);
            Attendance attendance = new Attendance(data, savedData);
            _attendances.Add(attendance);
        }
    }
    public bool TryCheckInToday(int day)
    {
        Attendance attendance = _attendances.Find(a => a.Day == day);
        if (attendance == null)
            return false;

        if (attendance.TryCheckIn())
        {
            // 보상 지급
            CurrecncyManager.Instance.Add(attendance.RewardCurrencyType, attendance.RewardAmount);

            _repository.Save(Attendances);

            //OnDataChanged?.Invoke();

            return true;
        }

        return false;
    }
    public Attendance GetCurrentAvailableAttendance()
    {
        foreach (var attendance in _attendances)
        {
            if (!attendance.HasCheckedInToday && attendance.GetRemainingTime().TotalSeconds <= 0)
            {
                return attendance;
            }
        }
        return null;
    }
}
