using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CurrecncyManager : MonoBehaviour
{
    public static CurrecncyManager Instance;

    private Dictionary<ECurrencyType, Currency> _currencies;

    public event Action OnDataChanged;

    private CurrencyRepository _repository;

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

    private void Init()
    {
        _repository = new CurrencyRepository();

        List<CurrencyDTO> loadedCurrencies = _repository.Load();
        _currencies = new Dictionary<ECurrencyType, Currency>((int)ECurrencyType.Count);

        if (loadedCurrencies == null)
        {
            // 생성
            for (int i = 0; i < (int)ECurrencyType.Count; ++i)
            {
                ECurrencyType type = (ECurrencyType)i;

                // 재화를 생성하고 0값으로 초기화
                Currency currency = new Currency(type, 0);

                // 딕셔너리에 추가
                _currencies.Add(type, currency);
            }
        }
        else
        {
            foreach(var data in loadedCurrencies)
            {
                Currency currency = new Currency(data.Type, data.Value);
                _currencies.Add(currency.Type,currency);
            }
        }
    }
    private List<CurrencyDTO> ToDtoList()
    {
        return _currencies.ToList().ConvertAll(currency => new CurrencyDTO(currency.Value));
    }

    public void Add(ECurrencyType type, int value)
    {
        _currencies[type].Add(value);

        _repository.Save(ToDtoList());

        AchievementManager.Instance.Increase(EAchievementCondition.GoldCollect, value);
        OnDataChanged?.Invoke();
    }
    public bool TryBuy(ECurrencyType type, int value)
    {
        if (_currencies[type].TryBuy(value))
        {
            _repository.Save(ToDtoList());

            OnDataChanged?.Invoke();
            return true;
        }
        return false;
    }

    public CurrencyDTO Get(ECurrencyType type)
    {
        return new CurrencyDTO(_currencies[type]);
    }
}
