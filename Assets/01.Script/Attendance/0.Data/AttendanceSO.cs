using UnityEngine;

[CreateAssetMenu(fileName = "AttendanceSO", menuName = "Scriptable Objects/AttendanceSO")]
public class AttendanceSO : ScriptableObject
{
    [Header("기본 정보")]
    [SerializeField] private int _iD;
    [SerializeField] private int _day;

    [Header("보상 정보")]
    [SerializeField] private ECurrencyType _rewardCurrencyType;
    [SerializeField] private int _rewardAmount;


    public int ID => _iD;
    public int Day => _day;
    public ECurrencyType RewardCurrencyType => _rewardCurrencyType;
    public int RewardAmount => _rewardAmount;

}
