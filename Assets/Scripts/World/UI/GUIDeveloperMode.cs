using UnityEngine;
using System.Collections;

public class GUIDeveloperMode : MonoBehaviour 
{
    private GameObject LightUI;
    private GameObject VoxelUI;
    private GameObject GeometryUI;
    private GameObject StructureUI;
    private GameObject InteractiveUI;
    private GameObject EnemyUI;
    private GameObject EventUI;

    void Awake()
    {
        GameGUI.developerMode = transform.parent.FindChild("Developer Mode").gameObject;
        GameGUI.developerMode.SetActive(true);

        LightUI = transform.parent.FindChild("Developer Mode").FindChild("Light").gameObject;
        VoxelUI = transform.parent.FindChild("Developer Mode").FindChild("Voxel").gameObject;
        GeometryUI = transform.parent.FindChild("Developer Mode").FindChild("Geometry").gameObject;
        StructureUI = transform.parent.FindChild("Developer Mode").FindChild("Structure").gameObject;
        InteractiveUI = transform.parent.FindChild("Developer Mode").FindChild("Interactive").gameObject;
        EnemyUI = transform.parent.FindChild("Developer Mode").FindChild("Enemy").gameObject;
        EventUI = transform.parent.FindChild("Developer Mode").FindChild("Event").gameObject;

        LightUI.SetActive(false);
        VoxelUI.SetActive(false);
        GeometryUI.SetActive(false);
        StructureUI.SetActive(false);
        InteractiveUI.SetActive(false);
        EnemyUI.SetActive(false);
        EventUI.SetActive(false);
    }


    //+ General
    public void LightButton()
    {
        GameFlow.selectedTool = GameFlow.SelectedTool.LIGHT;

        LightUI.SetActive(true);
        VoxelUI.SetActive(false);
        GeometryUI.SetActive(false);
        StructureUI.SetActive(false);
        InteractiveUI.SetActive(false);
        EnemyUI.SetActive(false);
        EventUI.SetActive(false);

        HUD.cubeMarker.SetActive(false);
    }


    public void VoxelButton()
    {
        GameFlow.selectedTool = GameFlow.SelectedTool.VOXEL;

        LightUI.SetActive(false);
        VoxelUI.SetActive(true);
        GeometryUI.SetActive(false);
        StructureUI.SetActive(false);
        InteractiveUI.SetActive(false);
        EnemyUI.SetActive(false);
        EventUI.SetActive(false);

        HUD.cubeMarker.SetActive(true);
    }


    public void GeometryButton()
    {
        GameFlow.selectedTool = GameFlow.SelectedTool.GEOMETRY;

        LightUI.SetActive(false);
        VoxelUI.SetActive(false);
        GeometryUI.SetActive(true);
        StructureUI.SetActive(false);
        InteractiveUI.SetActive(false);
        EnemyUI.SetActive(false);
        EventUI.SetActive(false);

        HUD.cubeMarker.SetActive(false);
    }


    public void StructureButton()
    {
        GameFlow.selectedTool = GameFlow.SelectedTool.STRUCTURE;

        LightUI.SetActive(false);
        VoxelUI.SetActive(false);
        GeometryUI.SetActive(false);
        StructureUI.SetActive(true);
        InteractiveUI.SetActive(false);
        EnemyUI.SetActive(false);
        EventUI.SetActive(false);

        HUD.cubeMarker.SetActive(false);
    }


    public void InteractiveButton()
    {
        GameFlow.selectedTool = GameFlow.SelectedTool.INTERACTIVE;

        LightUI.SetActive(false);
        VoxelUI.SetActive(false);
        GeometryUI.SetActive(false);
        StructureUI.SetActive(false);
        InteractiveUI.SetActive(true);
        EnemyUI.SetActive(false);
        EventUI.SetActive(false);

        HUD.cubeMarker.SetActive(false);
    }


    public void EnemyButton()
    {
        GameFlow.selectedTool = GameFlow.SelectedTool.ENEMY;

        LightUI.SetActive(false);
        VoxelUI.SetActive(false);
        GeometryUI.SetActive(false);
        StructureUI.SetActive(false);
        InteractiveUI.SetActive(false);
        EnemyUI.SetActive(true);
        EventUI.SetActive(false);

        HUD.cubeMarker.SetActive(false);
    }


    public void EventButton()
    {
        GameFlow.selectedTool = GameFlow.SelectedTool.EVENT;

        LightUI.SetActive(false);
        VoxelUI.SetActive(false);
        GeometryUI.SetActive(false);
        StructureUI.SetActive(false);
        InteractiveUI.SetActive(false);
        EnemyUI.SetActive(false);
        EventUI.SetActive(true);

        HUD.cubeMarker.SetActive(false);
    }


    //+ Light
    public void SunRiseButton()
    {
        Global.sun.lightSystemBehaviour.SetSunRise();
    }


    public void MidDayButton()
    {
        Global.sun.lightSystemBehaviour.SetMidDay();
    }


    public void EveningButton()
    {
        Global.sun.lightSystemBehaviour.SetNoon();
    }


    public void NightButton()
    {
        Global.sun.lightSystemBehaviour.SetNight();
    }


    //+ Voxel
    public void SingleVoxelButton()
    {
        GameFlow.developerMineTools = GameFlow.DeveloperMineTools.SINGLE;
    }


    public void OrtoedricVoxelButton()
    {
        GameFlow.developerMineTools = GameFlow.DeveloperMineTools.ORTOEDRIC;
    }
}
