using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UI_AttendanceSlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI DayText;
    [SerializeField] private TextMeshProUGUI RewardText;
    [SerializeField] private Button CheckInButton;

    private AttendanceDTO _dto;

    public void Refresh(AttendanceDTO attendanceDTO)
    {
        _dto = attendanceDTO;

        DayText.text = $"Day {_dto.Day}";
        RewardText.text = $"{_dto.RewardCurrencyType} {_dto.RewardAmount}";
        CheckInButton.interactable = !_dto.HasCheckedInToday;
    }

    public void OnClick_CheckIn()
    {
        Debug.Log("debug");
        if (_dto.HasCheckedInToday)
            return;

        bool success = AttendanceManager.Instance.TryCheckInToday(_dto.Day);
        if (success)
        {
            Refresh(AttendanceManager.Instance.Attendances.Find(a => a.Day == _dto.Day));
        }
    }




}
