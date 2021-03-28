using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectInfo : MonoBehaviour
{
    [SerializeField]
    public string ProjectVersion;
    [SerializeField]
    public Text Version;
    // Start is called before the first frame update
    void Start()
    {
        ProjectVersion = Application.version;
        Version.text = $"Version {ProjectVersion}";
    }
}
