using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UI_AttendanceSlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI DayText;
    [SerializeField] private TextMeshProUGUI RewardText;


    public void Refresh(AttendanceDTO attendanceDTO)
    {
        DayText.text = attendanceDTO.Day.ToString();
        RewardText.text = attendanceDTO.RewardCurrencyType.ToString() + attendanceDTO.RewardAmount.ToString();

    }






}
