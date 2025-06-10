using UnityEngine;


//런타임중에 불변값을 so로 관리하면:
// - 기획자가 에디터에서 직접 수정이 가능하고 유지보수와 확장성이 증가한다.
// - 도메인 객체는 상태만 관리하면 된다

[CreateAssetMenu(fileName = "AchievementSO", menuName = "Scriptable Objects/AchievementSO")]
public class AchievementSO : ScriptableObject
{
    // ───────────────────── 데이터 정의 ─────────────────────
    [Header("기본 정보")]
    [SerializeField] private string _id;
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private EAchievementCondition _condition;
    [SerializeField] private int _goalValue;

    // ───────────────────── 보상 정보 ─────────────────────
    [Header("보상 정보")]
    [SerializeField] private ECurrencyType _rewardCurrencyType;
    [SerializeField] private int _rewardAmount;

    // ───────────────────── 프로퍼티 ─────────────────────
    public string ID => _id;
    public string Name => _name;
    public string Description => _description;
    public EAchievementCondition Condition => _condition;
    public int GoalValue => _goalValue;
    public ECurrencyType RewardCurrencyType => _rewardCurrencyType;
    public int RewardAmount => _rewardAmount;
}
