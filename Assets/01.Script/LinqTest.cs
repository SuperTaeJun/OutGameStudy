using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class LinqTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 학생 리스트
        List<Student> students = new List<Student>()
        {
            new Student() {Name ="허정범", Age = 28, Gender = "남"},
            new Student() {Name ="박수현", Age = 26, Gender = "여"},
            new Student() {Name ="박진혁", Age = 29, Gender = "남"},
            new Student() {Name ="이상진", Age = 28, Gender = "남"},
            new Student() {Name ="서민주", Age = 25, Gender = "여"},
            new Student() {Name ="전태준", Age = 27, Gender = "남"},
            new Student() {Name ="박순홍", Age = 27, Gender = "남"},
            new Student() {Name ="양성일", Age = 29, Gender = "남"},

        };

        // 컬렉션에서 데이터를 조회 하는 일이 많다
        // C#은 이런 빈번한 작업을 편하게 하기 위해 LINQ 문법을 만들었따
        // 쿼리(Query) : 질의 (데이터를 요청하거나 검색하는 명령문)

        // "FROM, IN, SELECT, WHERE"
        // 사실 이렇게 잘 안씀

        var all = students.Where((student) => true);

        foreach (var item in all)
        {
            Debug.Log(item);
        }


        Debug.Log("-------------------------------------");

        //var mans = from Student in students where Student.Gender == "남" select Student;
        var mans = students.Where((student) => student.Gender == "남");

        foreach (var item in mans)
        {
            Debug.Log(item);
        }
        Debug.Log("-------------------------------------");

        //var mans2 = from Student in students where Student.Gender == "남" orderby Student.Age ascending select Student;
        var mans2 = students.Where((student) => student.Gender == "남").OrderBy(Student => Student.Age);
        foreach (var item in mans2)
        {
            Debug.Log(item);
        }


        //장점 : 편리하고 가독성이좋음
        //단점 : 성능적으로 안좋음 커서를 만드는데 이게 메모리를 증가시킴 그래서 update에서 쓰면안됨

        // Count

        //Sum

        //Average

        // ALL ANY  조건
        bool isAllMan = students.All(student => student.Gender == "남");

        bool is30 = students.Any(student => student.Age >= 30);
    }

}
