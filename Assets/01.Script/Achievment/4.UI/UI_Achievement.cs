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
        //Refresh();
        AchievementManager.Instance.OnDataChanged += Refresh;
        AchievementManager.Instance.OnInitFinished += SetSlot;
    }
    private void Refresh()
    {
        List<AchievementDTO> achievements = AchievementManager.Instance.Achievements;

        for (int i = 0; i < achievements.Count; ++i)
        {
            _slots[i].Refresh(achievements[i]);
        }
    }

    private void SetSlot(int num)
    {
        _slots = new List<UI_AchievementSlot>();

        for (int i = 0; i < num; ++i)
        {
            UI_AchievementSlot slot = Instantiate(SlotPrefab, ContentTransform).GetComponent<UI_AchievementSlot>();
            _slots.Add(slot);
        }
        Refresh();

        gameObject.SetActive(false);
    }
}
