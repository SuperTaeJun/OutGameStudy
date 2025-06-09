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
    // ������ Ŭ������ ����:
    // 1. ǥ������ �����Ѵ�. -> ȭ���� ������ �� ��� ǥ���Ҽ�����
    // 2. ���Ἲ�� �����ȴ�.
    // 3. �����Ϳ� �����͸� �ٷ�� ������ �����ִ�. -> �������� ����.

    // �ڱ� �������� �ڵ尡 �ȴ�.(��ȹ���� �ǰ��� �ڵ尡 �ȴ�)
    // ��ȹ�� ������ �Ͼ�� �ڵ忡 �ݿ��ϱ� ����.

    // ȭ�� ������ (������, ����, ����, ��ȹ���� �������� �ۼ��Ѵ�: ��ȹ�ڶ� ���� ���ؾ��Ѵ�.)
    private ECurrencyType _type;
    public ECurrencyType Type => _type;

    private int _value = 0;
    public int Value => _value;

    //�������� '��Ģ'�� �ִ�.
    public Currency(ECurrencyType type, int value)
    {
        if (value < 0)
        {
            throw new Exception("Value�� 0���� ������ ����");
        }

        _type = type;
        _value = value;
    }

    public void Add(int addedValue)
    {
        if (addedValue < 0)
        {
            throw new Exception("�߰� ���� ������ �ɼ� ����");
        }

        _value += addedValue;
    }
    public bool TryBuy(int value)
    {
        if (value < 0 || _value < value)
        {
            throw new Exception("���ǰ��� ���� ������ ���ƿ�");
        }

        _value -= value;
        return true;
    }

}
