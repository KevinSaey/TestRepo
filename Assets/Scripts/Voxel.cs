using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VoxelState { Dead, Alive }
public class Voxel
{
    private Vector3Int _index;
    private GameObject _goVoxel;
    private VoxelState _status = VoxelState.Alive;
    public VoxelState Status
    {
        get
        {
            return _status;
        }
        set
        {
            _goVoxel.SetActive(value == VoxelState.Alive);
            _status = value;
        }
    }

    public Voxel(Vector3Int index, GameObject goVoxelPrefab)
    {
        _index = index;
        _goVoxel = GameObject.Instantiate(goVoxelPrefab, _index, Quaternion.identity);
        _goVoxel.GetComponent<VoxelTrigger>().TriggerVoxel = this;
        
    }
    /*
    /// <summary>
    /// Changing the status of the Voxel and it's gameobject
    /// </summary>
    /// <param name="status">The voxel status</param>
    public void ChangeStatus(VoxelState status)
    {
        if (status == VoxelState.Alive)
        {
            _goVoxel.SetActive(status == VoxelState.Alive);
        }
        _status = status;
    }
    */
}
