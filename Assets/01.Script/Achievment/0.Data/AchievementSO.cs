using UnityEngine;


//��Ÿ���߿� �Һ����� so�� �����ϸ�:
// - ��ȹ�ڰ� �����Ϳ��� ���� ������ �����ϰ� ���������� Ȯ�强�� �����Ѵ�.
// - ������ ��ü�� ���¸� �����ϸ� �ȴ�

[CreateAssetMenu(fileName = "AchievementSO", menuName = "Scriptable Objects/AchievementSO")]
public class AchievementSO : ScriptableObject
{
    // ������������������������������������������ ������ ���� ������������������������������������������
    [Header("�⺻ ����")]
    [SerializeField] private string _id;
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private EAchievementCondition _condition;
    [SerializeField] private int _goalValue;

    // ������������������������������������������ ���� ���� ������������������������������������������
    [Header("���� ����")]
    [SerializeField] private ECurrencyType _rewardCurrencyType;
    [SerializeField] private int _rewardAmount;

    // ������������������������������������������ ������Ƽ ������������������������������������������
    public string ID => _id;
    public string Name => _name;
    public string Description => _description;
    public EAchievementCondition Condition => _condition;
    public int GoalValue => _goalValue;
    public ECurrencyType RewardCurrencyType => _rewardCurrencyType;
    public int RewardAmount => _rewardAmount;
}
