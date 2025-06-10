using System;

public class AchievementDTO
{
    // ───── 불변 데이터 ─────
    public readonly string ID;
    public readonly string Name;
    public readonly string Description;
    public readonly EAchievementCondition Condition;
    public readonly int GoalValue;
    public readonly ECurrencyType RewardCurrencyType;
    public readonly int RewardAmount;

    // ───── 상태 데이터 ─────
    public readonly int CurrentValue;
    public readonly bool RewardClaimed;


    // 세이브 데이터를 dto로 보내기 위해서
    public AchievementDTO(string id, int currentValue, bool rewardClaimed)
    {
        ID = id;
        CurrentValue = currentValue;
        RewardClaimed = rewardClaimed;
    }

    public AchievementDTO(Achievement achievement)
    {
        if (achievement == null)
            throw new ArgumentNullException(nameof(achievement));

        ID = achievement.ID;
        Name = achievement.Name;
        Description = achievement.Description;
        Condition = achievement.Condition;
        GoalValue = achievement.GoalValue;
        RewardCurrencyType = achievement.RewardCurrencyType;
        RewardAmount = achievement.RewardAmount;
        CurrentValue = achievement.CurrentValue;

        // RewardClaimed 속성이 RewardClamed로 오타 나 있는 경우 대응
        RewardClaimed = achievement.RewardClamed;
    }

    public bool CanClaimReward()
    {
        return RewardClaimed == false && CurrentValue >= GoalValue;
    }
}
