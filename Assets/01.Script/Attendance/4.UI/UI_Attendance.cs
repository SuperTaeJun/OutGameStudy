using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class UI_Attendance : MonoBehaviour
{
    private List<UI_AttendanceSlot> _slots;

    private void Start()
    {
        
    }

    private void Refresh()
    {
        List<AttendanceDTO> achievements = AttendanceManager.Instance.Attendances;

        for (int i = 0; i < achievements.Count; ++i)
        {
            _slots[i].Refresh(achievements[i]);
        }
    }
}
