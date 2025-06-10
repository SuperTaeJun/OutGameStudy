using UnityEngine;

[CreateAssetMenu(fileName = "AttendanceSO", menuName = "Scriptable Objects/AttendanceSO")]
public class AttendanceSO : ScriptableObject
{
    [Header("�⺻ ����")]
    [SerializeField] private readonly int _iD;
    [SerializeField] private readonly int _day;

    [Header("���� ����")]
    [SerializeField] private readonly ECurrencyType _rewardCurrencyType;
    [SerializeField] private readonly int _rewardAmount;


    public int ID => _iD;
    public int Day => _day;
    public ECurrencyType RewardCurrencyType => _rewardCurrencyType;
    public int RewardAmount => _rewardAmount;

}
