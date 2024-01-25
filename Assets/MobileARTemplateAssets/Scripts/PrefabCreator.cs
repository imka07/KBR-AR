using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PrefabCreator : MonoBehaviour
{
    [SerializeField] private GameObject towersPrefab;
    [SerializeField] private Vector3[] towerOffsets;
    [SerializeField] private int numberOfObjects = 1;
    private ARTrackedImageManager arTrackedImageManager;

    private void OnEnable()
    {
        arTrackedImageManager = GetComponent<ARTrackedImageManager>();
        arTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs obj)
    {
        foreach (ARTrackedImage image in obj.added)
        {
            for (int i = 0; i < numberOfObjects; i++)
            {
                Vector3 offset = i < towerOffsets.Length ? towerOffsets[i] : Vector3.zero;
                GameObject tower = Instantiate(towersPrefab, image.transform);
                tower.transform.position += offset;
            }
        }
    }
}



