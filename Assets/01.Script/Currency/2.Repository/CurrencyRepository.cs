using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;
public class CurrencyRepository
{
    //Repository : 데이터의 영속성을 보장한다.
    // Save/Load
    private const string SAVEKEY = "CurrencyDatas";

    public void Save(List<CurrencyDTO> dataList)
    {
        CurrencySaveDatas datas = new CurrencySaveDatas();
        datas.DataList = dataList.ConvertAll(data => new CurrencySaveData { Type = data.Type, Value = data.Value });

        string json = JsonUtility.ToJson(datas);
        PlayerPrefs.SetString(SAVEKEY, json);
    }

    public List<CurrencyDTO> Load()
    {
        if (!PlayerPrefs.HasKey(SAVEKEY))
        {
            return null;
        }

        string json = PlayerPrefs.GetString(SAVEKEY);
        CurrencySaveDatas datas = JsonUtility.FromJson<CurrencySaveDatas>(json);

        return datas.DataList.ConvertAll<CurrencyDTO>(data => new CurrencyDTO(data.Type, data.Value));
    }

}

[Serializable]
public struct CurrencySaveData
{
    public ECurrencyType Type;
    public int Value;
}

[Serializable]
public class CurrencySaveDatas
{
    public List<CurrencySaveData> DataList;
}
