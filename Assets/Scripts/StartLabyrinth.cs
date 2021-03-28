using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartLabyrinth : MonoBehaviour
{
    [SerializeField]
    InputField SizeIF;
    [SerializeField]
    InputField SeedIF;
    [SerializeField]
    Text MessageText;
    [SerializeField]
    Toggle Is3DToggle;
    [SerializeField]
    Toggle HasLoopToggle;
    private static System.Random random = new System.Random(Guid.NewGuid().GetHashCode());
    private static readonly List<string> NickSeeds = new List<string>
    {
        "Rederick Asher",
        "Morigun",
        "Sage",
        "CCC",
        "Inoy",
        "Nemo"
    };
    private static readonly List<string> StarsSeeds = new List<string>
    {
        "Альфа Центавра",
        "Бета Центавра",
        "Альферац",
        "Андромеда",
        "Мирах",
        "Аламак",
        "Грумбридж 34",
        "Поллукс",
        "Кастор A",
        "Альхена",
        "Алиот",
        "Дубхе",
        "Бенетнаш",
        "Мицар",
        "Мерак",
        "Фекда",
        "Мегрец",
        "Домбай",
        "Сириус",
        "Адара",
        "Везен",
        "Мирцам",
        "Алудра",
        "Глизе 581",
        "Садалсууд",
        "Садалмелик",
        "Капелла",
        "GD 66",
        "Волк-TR-3",
        "Арктур",
        "HAT-P-4",
        "LHS2520",
        "Альфард",
        "Спика",
        "WASP-2",
        "Струве 2398 A",
        "Звезда Пласкетта",
        "Росс 614",
        "Глизе 674",
        "Альнаир",
        "Глизе 832",
        "Арнеб",
        "Нихал",
        "Росалиядекастро",
        "COROT-6",
        "Глизе 710",
        "R136a1",
        "WASP-46",
        "Канопус",
        "Дифда",
        "Менкар",
        "Мира",
        "Денеб Альгенуби",
        "Каффальджидхма",
        "Шемали",
        "Батен Кайтос",
        "Глизе 785",
        "Денеб",
        "Альбирео A",
        "HAT-P-7",
        "Регул",
        "Альгиеба",
        "Денебола",
        "Зосма",
        "Альгиеба",
        "Вега",
        "Шелиак",
        "HIP 91373",
        "PY Vul",
        "Полярная звезда",
        "Кохаб",
        "Калвера",
        "Процион",
        "Гомейса",
        "Альтаир",
        "W50",
        "Ригель",
        "Бетельгейзе",
        "Беллатрикс",
        "Альнилам",
        "Саиф",
        "Минтака",
        "Наир Аль Саиф",
        "Табит",
        "Алголь",
        "XO-4",
        "Антарес",
        "Шаула",
        "V1036 Sco",
        "Louna202",
        "Альдебаран",
        "Электра",
        "Майя",
        "Меропа",
        "Тайгета",
        "Плейона",
        "Целено",
        "Астеропа",
        "Анкаа",
        "Альдерамин",
        "Эрраи",
        "Альфирк",
        "Крюгер 60",
        "Ахернар",
        "Курса",
        "Акамар",
        "Заурак",
        "Рана",
        "Тееним",
        "Скип",
        "Азха",
        "Бейд",
        "Зибаль",
        "Фомальгаут",
        "Бекрукс",
        "Акрукс",
        "Гакрукс",
        "Декрукс"
    };
    private static readonly List<string> ITSeeds = new List<string>
    {
        "C#",
        "C++",
        "Java",
        "Python",
        "VBS",
        "Ada",
        "Prolog",
        "Lisp",
        "JS",
        "PHP",
        "HTML",
        "HTTP",
        "Go",
        "Brainfuck",
        "3D",
        "Unity",
        "MSSQL",
        "Postgrsql",
        "Assembler",
        "OpenGL",
        "Android",
        "Git",
        "Proteus",
        "Qt",
        "UE4",
        "sPlan",
        "Linux",
        "Gentoo",
        "F#",
        "Xamarin",
        "Lua",
        "Ruby",
        "Scala",
        "PL/SQL",
        "UML",
        "Json",
        "XML",
        "Xaml",
        "ООП",
        "ИИТ"
    };
    private static readonly List<string> OtherSeeds = new List<string>
    {
        "Чипотле",
        DateTime.UtcNow.ToString("ddMMyyyy"),
        DateTime.Now.ToString("ddMMyyyy"),
        DateTime.Now.ToString("HHmmss"),
        "Маффин 3 шоколада",
        "Монки Д. Луффи",
        "Кеничи",
        "Дом в котором",
        "Root"
    };
    private static string RandomString(int length) => new string(Enumerable.Repeat("АБВГДЕЁЖЗИКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯABCDEFGHIJKLMNOPQRSTUVWXYZабвгдеёжзиклмнопрстуфхцчшщъыьэюяabcdefghijklmnopqrstuvwxyz0123456789", length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    private static Dictionary<int, string> RandomStrings = new Dictionary<int, string>
    {
        { 0, NickSeeds[random.Next(0, NickSeeds.Count)] },
        { 1, StarsSeeds[random.Next(0, StarsSeeds.Count)] },
        { 2, ITSeeds[random.Next(0, ITSeeds.Count)] },
        { 3, OtherSeeds[random.Next(0, OtherSeeds.Count)] },
        { 4, RandomString(15) }
    };

    void Start()
    {
        SeedIF.text = RandomStrings[random.Next(0, RandomStrings.Count)];
    }

    public void RunLabyrinth()
    {
        if (SizeIF != null)
        {
            if (int.TryParse(SizeIF.text, out int size))
            {
                if (size <= 10000 && size > 1)
                {
                    string seed = Guid.NewGuid().ToString();
                    if (SeedIF != null)
                        seed = SeedIF.text;
                    LabGenV2.OutSize = size;
                    LabGenV2.OutSeed = seed;
                    LabGenV2.Is3D = Is3DToggle.isOn;
                    LabGenV2.HasLoop = HasLoopToggle.isOn;
                    SceneManager.LoadScene(1);
                }
                else
                {
                    MessageText.text = "Не верно указан размер, укажите число не более 10000 и не менее 1.";
                    SizeIF.text = "10000";
                }
            }
            else
            {
                MessageText.text = "Не верно указан размер, укажите число не более 10000 и не менее 1.";
                SizeIF.text = "10";
            }
        }
    }
}
