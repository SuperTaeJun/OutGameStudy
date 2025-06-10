using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;

public class UI_Attendance : MonoBehaviour
{
    private List<UI_AttendanceSlot> _slots;
    [SerializeField] private GameObject SlotPrefab;
    [SerializeField] private Transform ContentTransform;

    private void Start()
    {
        AttendanceManager.Instance.OnDataChanged += Refresh;
        InitSlots();
    }

    private void InitSlots()
    {
        List<AttendanceDTO> attendances = AttendanceManager.Instance.Attendances;

        if (_slots == null) _slots = new List<UI_AttendanceSlot>();

        int toCreate = attendances.Count - _slots.Count;
        for (int i = 0; i < toCreate; i++)
        {
            UI_AttendanceSlot slot = Instantiate(SlotPrefab, ContentTransform).GetComponent<UI_AttendanceSlot>();
            _slots.Add(slot);
        }

        Refresh();
        gameObject.SetActive(false);
    }
    private void Refresh()
    {
        List<AttendanceDTO> attendances = AttendanceManager.Instance.Attendances;

        for (int i = 0; i < attendances.Count; i++)
        {
            _slots[i].Refresh(attendances[i]);
        }
    }

}
