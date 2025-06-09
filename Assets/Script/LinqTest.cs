using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class LinqTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // �л� ����Ʈ
        List<Student> students = new List<Student>()
        {
            new Student() {Name ="������", Age = 28, Gender = "��"},
            new Student() {Name ="�ڼ���", Age = 26, Gender = "��"},
            new Student() {Name ="������", Age = 29, Gender = "��"},
            new Student() {Name ="�̻���", Age = 28, Gender = "��"},
            new Student() {Name ="������", Age = 25, Gender = "��"},
            new Student() {Name ="������", Age = 27, Gender = "��"},
            new Student() {Name ="�ڼ�ȫ", Age = 27, Gender = "��"},
            new Student() {Name ="�缺��", Age = 29, Gender = "��"},

        };

        // �÷��ǿ��� �����͸� ��ȸ �ϴ� ���� ����
        // C#�� �̷� ����� �۾��� ���ϰ� �ϱ� ���� LINQ ������ �������
        // ����(Query) : ���� (�����͸� ��û�ϰų� �˻��ϴ� ��ɹ�)

        // "FROM, IN, SELECT, WHERE"
        // ��� �̷��� �� �Ⱦ�

        var all = students.Where((student) => true);

        foreach (var item in all)
        {
            Debug.Log(item);
        }


        Debug.Log("-------------------------------------");

        //var mans = from Student in students where Student.Gender == "��" select Student;
        var mans = students.Where((student) => student.Gender == "��");

        foreach (var item in mans)
        {
            Debug.Log(item);
        }
        Debug.Log("-------------------------------------");

        //var mans2 = from Student in students where Student.Gender == "��" orderby Student.Age ascending select Student;
        var mans2 = students.Where((student) => student.Gender == "��").OrderBy(Student => Student.Age);
        foreach (var item in mans2)
        {
            Debug.Log(item);
        }


        //���� : ���ϰ� ������������
        //���� : ���������� ������ Ŀ���� ����µ� �̰� �޸𸮸� ������Ŵ �׷��� update���� ����ȵ�

        // Count

        //Sum

        //Average

        // ALL ANY  ����
        bool isAllMan = students.All(student => student.Gender == "��");

        bool is30 = students.Any(student => student.Age >= 30);
    }

}
