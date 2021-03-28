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
        "����� ��������",
        "���� ��������",
        "��������",
        "���������",
        "�����",
        "������",
        "��������� 34",
        "�������",
        "������ A",
        "�������",
        "�����",
        "�����",
        "��������",
        "�����",
        "�����",
        "�����",
        "������",
        "������",
        "������",
        "�����",
        "�����",
        "������",
        "������",
        "����� 581",
        "���������",
        "����������",
        "�������",
        "GD 66",
        "����-TR-3",
        "������",
        "HAT-P-4",
        "LHS2520",
        "�������",
        "�����",
        "WASP-2",
        "������ 2398 A",
        "������ ���������",
        "���� 614",
        "����� 674",
        "�������",
        "����� 832",
        "�����",
        "�����",
        "���������������",
        "COROT-6",
        "����� 710",
        "R136a1",
        "WASP-46",
        "�������",
        "�����",
        "������",
        "����",
        "����� ���������",
        "��������������",
        "������",
        "����� ������",
        "����� 785",
        "�����",
        "�������� A",
        "HAT-P-7",
        "�����",
        "��������",
        "��������",
        "�����",
        "��������",
        "����",
        "������",
        "HIP 91373",
        "PY Vul",
        "�������� ������",
        "�����",
        "�������",
        "�������",
        "�������",
        "�������",
        "W50",
        "������",
        "�����������",
        "����������",
        "��������",
        "����",
        "�������",
        "���� ��� ����",
        "�����",
        "������",
        "XO-4",
        "�������",
        "�����",
        "V1036 Sco",
        "Louna202",
        "����������",
        "�������",
        "����",
        "������",
        "�������",
        "�������",
        "������",
        "��������",
        "�����",
        "����������",
        "�����",
        "�������",
        "������ 60",
        "�������",
        "�����",
        "������",
        "������",
        "����",
        "������",
        "����",
        "����",
        "����",
        "������",
        "����������",
        "�������",
        "������",
        "�������",
        "�������"
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
        "���",
        "���"
    };
    private static readonly List<string> OtherSeeds = new List<string>
    {
        "�������",
        DateTime.UtcNow.ToString("ddMMyyyy"),
        DateTime.Now.ToString("ddMMyyyy"),
        DateTime.Now.ToString("HHmmss"),
        "������ 3 ��������",
        "����� �. �����",
        "������",
        "��� � �������",
        "Root"
    };
    private static string RandomString(int length) => new string(Enumerable.Repeat("�����Ũ�������������������������ABCDEFGHIJKLMNOPQRSTUVWXYZ�������������������������������abcdefghijklmnopqrstuvwxyz0123456789", length)
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
                    MessageText.text = "�� ����� ������ ������, ������� ����� �� ����� 10000 � �� ����� 1.";
                    SizeIF.text = "10000";
                }
            }
            else
            {
                MessageText.text = "�� ����� ������ ������, ������� ����� �� ����� 10000 � �� ����� 1.";
                SizeIF.text = "10";
            }
        }
    }
}
