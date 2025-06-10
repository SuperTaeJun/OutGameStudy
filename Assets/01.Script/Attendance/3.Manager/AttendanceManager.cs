using System.Collections.Generic;
using UnityEngine;

public class AttendanceManager : MonoBehaviour
{
    public static AttendanceManager Instance;

    [SerializeField] private List<AttendanceSO> _metaDatas;

    private List<Attendance> _attendances;
    public List<AttendanceDTO> Attendances => _attendances.ConvertAll(a => new AttendanceDTO(a));

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
        _attendances = new List<Attendance>();

        foreach(AttendanceSO data in _metaDatas)
        {
            Attendance attendance = new Attendance(data);
            _attendances.Add(attendance);
        }
    }
}
