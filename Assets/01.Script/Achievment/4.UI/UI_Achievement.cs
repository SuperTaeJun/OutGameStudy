using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
public class UI_Achievement : MonoBehaviour
{
    [SerializeField] private List<UI_AchievementSlot> _slots;
    [SerializeField] private GameObject SlotPrefab;
    [SerializeField] private Transform ContentTransform;
    private void Start()
    {
        //if(_slots!= null)
        //    Refresh();
        AchievementManager.Instance.OnDataChanged += Refresh;
        AchievementManager.Instance.OnInitFinished += InitSlot;

    }
    private void Refresh()
    {
        List<AchievementDTO> achievements = AchievementManager.Instance.Achievements;

        for (int i = 0; i < achievements.Count; ++i)
        {
            _slots[i].Refresh(achievements[i]);
        }
    }
    private void InitSlot(int num)
    {
        if (_slots == null)
            _slots = new List<UI_AchievementSlot>();

        // 현재 슬롯 개수보다 부족한 경우에만
        int toCreate = num - _slots.Count;

        for (int i = 0; i < toCreate; ++i)
        {
            UI_AchievementSlot slot = Instantiate(SlotPrefab, ContentTransform).GetComponent<UI_AchievementSlot>();
            if (slot != null)
            {
                _slots.Add(slot);
            }
        }

        Refresh();
    }
}
