using UnityEngine;
using System;


public enum ECurrencyType
{
    Gold,
    Diamond,

    Count
}

public class Currency
{
    // 도메인 클래스의 장점:
    // 1. 표현력이 증가한다. -> 화폐의 종류와 값 모두 표현할수이음
    // 2. 무결성이 유지된다.
    // 3. 데이터와 데이터를 다루는 로직이 뭉쳐있다. -> 응집도가 높다.

    // 자기 서술적인 코드가 된다.(기획서에 의거한 코드가 된다)
    // 기획서 변경이 일어나면 코드에 반영하기 쉽다.

    // 화폐 도메인 (콘텐츠, 지식, 문제, 기획서를 바탕으로 작성한다: 기획자랑 말이 통해야한다.)
    private ECurrencyType _type;
    public ECurrencyType Type => _type;

    private int _value = 0;
    public int Value => _value;

    //도메인은 '규칙'이 있다.
    public Currency(ECurrencyType type, int value)
    {
        if (value < 0)
        {
            throw new Exception("Value는 0보다 작을수 없다");
        }

        _type = type;
        _value = value;
    }

    public void Add(int addedValue)
    {
        if (addedValue < 0)
        {
            throw new Exception("추가 값은 음수가 될수 없다");
        }

        _value += addedValue;
    }
    public bool TryBuy(int value)
    {
        if (value < 0 || _value < value)
        {
            throw new Exception("물건값이 가진 돈보다 많아요");
        }

        _value -= value;
        return true;
    }

}
