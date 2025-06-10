using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UI_AchievementSlot : MonoBehaviour
{
    public TextMeshProUGUI NameTextUI;
    public TextMeshProUGUI DescriptionTextUI;
    public TextMeshProUGUI RewardCountTextUI;

    public Slider ProgressSlider;
    public TextMeshProUGUI ProgressText;

    public TextMeshProUGUI RewardClaimDate;
    public Button RewardClaimButton;

    private AchievementDTO _achievementDTO;

    public void Refresh(AchievementDTO achievement)
    {
        _achievementDTO = achievement;

        NameTextUI.text = achievement.Name;
        DescriptionTextUI.text = achievement.Description;
        RewardCountTextUI.text = achievement.RewardCurrencyType.ToString()+"\n"+achievement.RewardAmount.ToString();
        ProgressSlider.value = (float)achievement.CurrentValue / achievement.GoalValue;

        RewardClaimButton.interactable = achievement.CanClaimReward();

        ProgressText.text = $"{achievement.CurrentValue} / {achievement.GoalValue}";
    }
    public void ClaimReward()
    {
        if(AchievementManager.Instance.TryClaimReward(_achievementDTO))
        {

        }
        else
        {

        }
        //if (_achievementDTO.RewardClaimed == false && _achievementDTO.CurrentValue >= _achievementDTO.GoalValue)
        //{
        //    AchievementManager.Instance.TryClaimReward(_achievementDTO);
        //}
    }
}
