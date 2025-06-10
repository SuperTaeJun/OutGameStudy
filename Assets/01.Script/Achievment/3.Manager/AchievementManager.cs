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
            //�ߺ��˻�
            Achievement duplicatedAhievement = FindAchievementByID(metaData.ID);
            if(duplicatedAhievement != null)
            {
                throw new Exception($"���� ID{metaData.ID}�� �ߺ��˴ϴ�");
            }

            //������ ����
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
                    //�̴밡 ���ο� ������ ������ �����Ҵ���
                    //���⼭ ui��ɺҷ���~
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
