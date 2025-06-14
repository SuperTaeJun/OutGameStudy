using UnityEngine;
using System;
using Unity.Tutorials.Core.Editor;
public enum EAchievementCondition
{
    GoldCollect,
    DronKillCount,
    BossKillCount,
    PlayTime,
    Trigger,
}

public class Achievement
{

    // 데이타
    public readonly string ID;
    public readonly string Name;
    public readonly string Description;
    public readonly EAchievementCondition Condition;
    public int GoalValue;
    public ECurrencyType RewardCurrencyType;
    public int RewardAmount;

    // 상태
    private int _currentValue;
    public int CurrentValue => _currentValue;
    private bool _rewardClaimed;
    public bool RewardClamed => _rewardClaimed;



    public Achievement(AchievementSO metaData, AchievementDTO savedData)
    {
        //id가 하나임을 증명하는 코드가 있어야함 -> 이걸 할려면 아이디 관리자가 또필요


        if (string.IsNullOrEmpty(metaData.ID))
        {
            throw new Exception("업적 ID는 비어있을 수 없지요");
        }
        if (string.IsNullOrEmpty(metaData.Name))
        {
            throw new Exception("업적 이름은 비어있을 수 없지요");
        }
        if (string.IsNullOrEmpty(metaData.Description))
        {
            throw new Exception("업적 설명은 비어있을 수 없지요");
        }
        if (metaData.GoalValue <= 0)
        {
            throw new Exception("업적 목표 값은 0보다 커야함");
        }
        if (metaData.RewardAmount <= 0)
        {
            throw new Exception("업적 보상 값은 0보다 커야함");
        }
        ID = metaData.ID;
        Name = metaData.Name;
        Description = metaData.Description;
        Condition = metaData.Condition;
        GoalValue = metaData.GoalValue;
        RewardCurrencyType = metaData.RewardCurrencyType;
        RewardAmount = metaData.RewardAmount;

        //if (savedData.CurrentValue < 0)
        //{
        //    throw new Exception("업적 진행 값은 0보다 커야합니다.");
        //}

        if (savedData != null)
        {
            _currentValue = savedData.CurrentValue;
            _rewardClaimed = savedData.RewardClaimed;
        }
    }

    public void Increase(int value)
    {
        if (value < 0)
        {
            throw new Exception("증가 값은 0보다 커야 한다.");
        }

        _currentValue += value;
    }

    public bool CanClaimReward()
    {
        return _rewardClaimed == false && _currentValue >= GoalValue;
    }
    public bool TryClaimReward()
    {
        if (!CanClaimReward()) return false;

        _rewardClaimed = true;
        return true;
    }
}
