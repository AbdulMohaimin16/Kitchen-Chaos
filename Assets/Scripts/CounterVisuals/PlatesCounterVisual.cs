using UnityEngine;
using System.Collections.Generic;
using System;

public class PlatesCounterVisual : MonoBehaviour
{
    [SerializeField] private PlatesCounter platesCounter;
    [SerializeField] private Transform platesVisualTransform;
    [SerializeField] private Transform counterTopPoint;


    private List<GameObject> platesVisualGameObjectsList;

    private void Awake()
    {
        platesVisualGameObjectsList = new List<GameObject>();
    }
    private void Start()
    {
        platesCounter.OnPlateSpawned += PlatesCounter_OnPlateSpawned;
        platesCounter.OnPlateRemoved += PlatesCounter_OnPlateRemoved;
    }

    private void PlatesCounter_OnPlateRemoved(object sender, EventArgs e)
    {
        GameObject plateVisualGameObject = platesVisualGameObjectsList[platesVisualGameObjectsList.Count - 1];
        platesVisualGameObjectsList.Remove(plateVisualGameObject);
        Destroy(plateVisualGameObject);
    }

    private void PlatesCounter_OnPlateSpawned(object sender, EventArgs e)
    {
        Transform plateVisualTransform = Instantiate(platesVisualTransform, counterTopPoint);

        float plateOffsetY = 0.1f;
        plateVisualTransform.localPosition = new Vector3(0f, plateOffsetY * platesVisualGameObjectsList.Count, 0f);
        platesVisualGameObjectsList.Add(plateVisualTransform.gameObject);
    }
}
