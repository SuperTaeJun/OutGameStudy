using System;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public static AchievementManager Instance;

    [SerializeField] private List<AchievementSO> _metaDatas;

    private List<Achievement> _allAchievements;

    public List<AchievementDTO> Achievements => _allAchievements.ConvertAll(achievement => new AchievementDTO(achievement));

    public event Action OnDataChanged;
    public event Action<AchievementDTO> OnNewAchievementReward;
    public event Action<int> OnInitFinished;

    private AchievementRepository  _repository;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

        Init();
    }

    private void Start()
    {
        OnInitFinished.Invoke(_metaDatas.Count); 
    }
    private Achievement FindAchievementByID(string id)
    {
        return _allAchievements.Find(a => a.ID == id);
    }

    private void Init()
    {
        _repository = new AchievementRepository();
        _allAchievements = new List<Achievement>();
        List<AchievementDTO> loadedDatas = _repository.Load();


        foreach (AchievementSO metaData in _metaDatas)
        {
            //중복검사
            Achievement duplicatedAhievement = FindAchievementByID(metaData.ID);
            if(duplicatedAhievement != null)
            {
                throw new Exception($"업적 ID{metaData.ID}가 중복됩니다");
            }

            //데이터 생성
            AchievementDTO savedData = loadedDatas?.Find(a => a.ID == metaData.ID);
            Achievement achievement = new Achievement(metaData, savedData);
            _allAchievements.Add(achievement);
        }
    }
    public void Increase(EAchievementCondition condition, int value)
    {
        foreach (var achivement in _allAchievements)
        {
            if (achivement.Condition == condition)
            {
                bool prevCanClaimReward = achivement.CanClaimReward();
                achivement.Increase(value);

                bool canClaimReward = achivement.CanClaimReward();
                if(canClaimReward)
                {
                    //이대가 새로운 리워드 보상이 가능할대임
                    //여기서 ui기능불러라~
                    OnNewAchievementReward?.Invoke(new AchievementDTO(achivement));
                }
            }
        }

        _repository.Save(Achievements);
        OnDataChanged?.Invoke();

    }

    public bool TryClaimReward(AchievementDTO achievementDTO)
    {
        Achievement achievement = FindAchievementByID(achievementDTO.ID);

        if (achievement == null) return false;


        if(achievement.TryClaimReward())
        {
            CurrecncyManager.Instance.Add(achievement.RewardCurrencyType, achievement.RewardAmount);
            OnDataChanged?.Invoke();
            return true;
        }
        return false;

    }
}
