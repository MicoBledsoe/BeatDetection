using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateVisualizer : MonoBehaviour
{
    public GameObject SampleCubePrefab; // Prefab for the visualizer cubes
    private GameObject[] _sampleCubes = new GameObject[512]; // Array to hold the cubes
    public float maxScale = 10f; // Maximum scale for the cubes

    public AudioPeer _audioPeer;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 512; i++)
        {
            GameObject instanceSampleCube = (GameObject)Instantiate(SampleCubePrefab);
            instanceSampleCube.transform.position = this.transform.position;
            instanceSampleCube.transform.parent = this.transform;
            instanceSampleCube.name = "SampleCube" + i;
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            instanceSampleCube.transform.position = Vector3.forward * 200;
            _sampleCubes[i] = instanceSampleCube;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 512; i++)
        {
            if (_sampleCubes[i] != null)
            {
                _sampleCubes[i].transform.localScale = new Vector3(10, (AudioPeer._samples[i] * maxScale) + 2, 10);
            }
        }
    }
}
