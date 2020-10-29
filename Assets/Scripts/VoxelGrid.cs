using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelGrid : MonoBehaviour
{
    [SerializeField]
    private Vector3Int GridDimension = new Vector3Int(10, 20, 5);

    private Voxel[,,] _voxels;
    private GameObject _goVoxelPrefab;
    // Start is called before the first frame update
    void Start()
    {
        _goVoxelPrefab = Resources.Load("Prefabs/VoxelCube") as GameObject;
        CreateVoxelGrid();

        /*Dog barry = new Dog("Barry", "Kevin's dog");
        Dog tobias = new Dog("Tobias", "Ghanem's dog");

        barry.Bark(6);
        tobias.Bark(3);*/
    }

    private void CreateVoxelGrid()
    {
        _voxels = new Voxel[GridDimension.x, GridDimension.y, GridDimension.z];

        for (int x = 0; x < GridDimension.x; x++)
        {
            for (int y = 0; y < GridDimension.y; y++)
            {
                for (int z = 0; z < GridDimension.z; z++)
                {
                    _voxels[x, y, z] = new Voxel(new Vector3Int(x, y, z), _goVoxelPrefab);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            HandleRaycast();
        }
    }

    private void HandleRaycast()
    {
        Debug.Log("Clicked");

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Transform objectHit = hit.transform;

            if (objectHit.CompareTag("Voxel"))
            {
                objectHit.gameObject.GetComponent<VoxelTrigger>().TriggerVoxel.Status = VoxelState.Dead;
            }
        }
    }
}
