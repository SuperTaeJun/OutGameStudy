using System;

public class AchievementDTO
{
    // ���������� �Һ� ������ ����������
    public readonly string ID;
    public readonly string Name;
    public readonly string Description;
    public readonly EAchievementCondition Condition;
    public readonly int GoalValue;
    public readonly ECurrencyType RewardCurrencyType;
    public readonly int RewardAmount;

    // ���������� ���� ������ ����������
    public readonly int CurrentValue;
    public readonly bool RewardClaimed;


    // ���̺� �����͸� dto�� ������ ���ؼ�
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

        // RewardClaimed �Ӽ��� RewardClamed�� ��Ÿ �� �ִ� ��� ����
        RewardClaimed = achievement.RewardClamed;
    }

    public bool CanClaimReward()
    {
        return RewardClaimed == false && CurrentValue >= GoalValue;
    }
}
