using LabyrinthGenerator;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LabGenV2 : MonoBehaviour
{
    [SerializeField]
    public GameObject Floor;
    [SerializeField]
    public GameObject HorizontalSide;
    [SerializeField]
    public GameObject VerticalSide;
    [SerializeField]
    public int Size = 10;
    [SerializeField]
    public GameObject Player;
    [SerializeField]
    public GameObject Light;
    [SerializeField]
    public GameObject StartLight;
    [SerializeField]
    public GameObject EndLight;
    public static int OutSize = 10;
    public static string OutSeed = "ff1aa383-92eb-42b1-883f-c104d68c7456";//Guid.NewGuid().ToString();
    // Start is called before the first frame update
    void Start()
    {
        Generator generator = new Generator(OutSize, OutSeed, false, false, 15, true);
        generator.Generate();
        for (int l = 0; l < generator.Labyrinth.Levels; l++)
        {
            for (int i = 0; i < generator.Labyrinth.LenSide; i++)
            {
                for (int j = 0; j < generator.Labyrinth.LenSide; j++)
                {
                    var room = generator.Labyrinth.Rooms[i, j, l];
                    if (room.Start)
                    {
                        Player.transform.Translate(new Vector3(room.Coordinate.X * 6, room.Coordinate.Y * 6, room.Coordinate.Z * 6));
                        Instantiate(StartLight, gameObject.transform).transform.Translate(new Vector3((room.Coordinate.X * 6), (room.Coordinate.Y * 6) + 3, room.Coordinate.Z * 6));
                    }
                    else if (room.End)
                    {
                        Instantiate(EndLight, gameObject.transform).transform.Translate(new Vector3((room.Coordinate.X * 6), (room.Coordinate.Y * 6) + 3, room.Coordinate.Z * 6));
                    }
                    else
                        Instantiate(Light, gameObject.transform).transform.Translate(new Vector3((room.Coordinate.X * 6), (room.Coordinate.Y * 6) + 3, room.Coordinate.Z * 6));
                    if (!room[0]) // Отсутствует Север
                        Instantiate(HorizontalSide, gameObject.transform).transform.Translate(new Vector3(room.Coordinate.X * 6, room.Coordinate.Y * 6, room.Coordinate.Z * 6));
                    if (!room[2]) // Отсутствует Юг
                        Instantiate(HorizontalSide, gameObject.transform).transform.Translate(new Vector3(room.Coordinate.X * 6, room.Coordinate.Y * 6, (room.Coordinate.Z * 6) - 6));
                    if (!room[3]) // Отсутствует Запад
                        Instantiate(VerticalSide, gameObject.transform).transform.Translate(new Vector3(room.Coordinate.X * 6, room.Coordinate.Y * 6, room.Coordinate.Z * 6));
                    if (!room[1]) // Отсутствует Восток
                        Instantiate(VerticalSide, gameObject.transform).transform.Translate(new Vector3((room.Coordinate.X * 6) + 6, room.Coordinate.Y * 6, room.Coordinate.Z * 6));
                    if (!room[4]) // Отсутствует Верх
                        Instantiate(Floor, gameObject.transform).transform.Translate(new Vector3(room.Coordinate.X * 6, (room.Coordinate.Y * 6) + 6, room.Coordinate.Z * 6));
                    if (!room[5]) // Отсутствует Низ
                        Instantiate(Floor, gameObject.transform).transform.Translate(new Vector3(room.Coordinate.X * 6, room.Coordinate.Y * 6, room.Coordinate.Z * 6));
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
