using System;
using System.Collections.Generic;
using STRINGS;
using TUNING;
using UnityEngine;

public class DirtTileConfig : IBuildingConfig
{
    public const string ID = "DirtTile";
    public const string DisplayName = "Dirt Tile";
    public static string Description = $"Fill that hole you dug out back in with {UI.FormatAsLink("Dirt", "DIRT")}.";
    public static string Effect = $"Fills a block in the world with {UI.FormatAsLink("Dirt", "DIRT")}.";

	public static readonly int BlockTileConnectorID = Hash.SDBMLower("dirt_tile_block");

	public override BuildingDef CreateBuildingDef()
	{
		string id = "DirtTile";
		int width = 1;
		int height = 1;
		string anim = "dirt_tile_kanim";
		int hitpoints = 100;
		float construction_time = BuildableDirtTile.BuildableDirtTilePatches.Settings.BuildSpeed;
		float[] tier = new float[] { BuildableDirtTile.BuildableDirtTilePatches.Settings.BuildMass };  // 50kg
		string[] raw_MINERALS = new string[] {SimHashes.Dirt.ToString()}; // only buildable with Dirt
		float melting_point = 1600f;
		BuildLocationRule build_location_rule = BuildLocationRule.Anywhere;
		EffectorValues none = NOISE_POLLUTION.NONE;
		BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, raw_MINERALS, melting_point, build_location_rule, TUNING.BUILDINGS.DECOR.BONUS.TIER0, none, 0.2f);
		// BuildingTemplates.CreateFoundationTileDef(buildingDef);
		// buildingDef.Floodable = false;
		// buildingDef.Entombable = false;
		// buildingDef.Overheatable = false;
		// buildingDef.ForegroundLayer = Grid.SceneLayer.BuildingBack;
		// buildingDef.AudioCategory = "HollowMetal";
		// buildingDef.AudioSize = "small";
		// buildingDef.BaseTimeUntilRepair = -1f;
		// buildingDef.SceneLayer = Grid.SceneLayer.TileMain;
		// buildingDef.ConstructionOffsetFilter = BuildingDef.ConstructionOffsetFilter_OneDown;
		// buildingDef.isSolidTile = false;
		// buildingDef.DragBuild = true;
		// buildingDef.ObjectLayer = ObjectLayer.Building;
		return buildingDef;
	}

	public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
	{
		GeneratedBuildings.MakeBuildingAlwaysOperational(go);
		BuildingConfigManager.Instance.IgnoreDefaultKComponent(typeof(RequiresFoundation), prefab_tag);
	}

	public override void DoPostConfigureComplete(GameObject go)
	{
		GeneratedBuildings.RemoveLoopingSounds(go);
		go.GetComponent<KPrefabID>().AddTag(GameTags.FloorTiles, false);
	}

	public override void DoPostConfigureUnderConstruction(GameObject go)
	{
		base.DoPostConfigureUnderConstruction(go);
	}
}
