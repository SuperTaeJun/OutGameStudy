using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Collections;

public class UI_Notification : MonoBehaviour
{
    [SerializeField] private GameObject _notification;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _reward;

    //연속으로 업적이 달성될수도 있음
    private Queue<AchievementDTO> _notificationQueue = new Queue<AchievementDTO>();
    private bool _isShowing = false;

    private void Start()
    {
        AchievementManager.Instance.OnNewAchievementReward += EnqueueNotification;
    }

    private void EnqueueNotification(AchievementDTO achievement)
    {
        _notificationQueue.Enqueue(achievement);

        if (!_isShowing)
        {
            StartCoroutine(ProcessQueue());
        }
    }

    private IEnumerator ProcessQueue()
    {
        _isShowing = true;

        while (_notificationQueue.Count > 0)
        {
            var achievement = _notificationQueue.Dequeue();
            SetNotification(achievement);
            _notification.SetActive(true);

            yield return new WaitForSeconds(2f);

            _notification.SetActive(false);
        }

        _isShowing = false;
    }

    private void SetNotification(AchievementDTO achievement)
    {
        _name.text = achievement.Name;
        _reward.text = $"{achievement.RewardCurrencyType} {achievement.RewardAmount} 획득 가능~!";
    }

}
