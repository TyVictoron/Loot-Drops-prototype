using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootManager : MonoBehaviour {

    private Player player;
    public GameObject lootModel;
    public Material[] rarityMats;

    [Header("Atributes")]
    public string[] gunTypes = {"AutoRifle","Pistol","HandCannon","MarksmansRifle","BurstRifle","Rocket","Machinegun","Minigun","Sniper", "DirectedEnergyRifle", "SMG"};
    public string[] rarities = { "Common", "Uncommon", "Rare", "Epic", "Legendary" };
    public int[] magazineCapacities = { 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 95, 100 };
    public int[] reservesCapacities = { 100, 150, 200, 250, 300, 350, 400, 450, 500, 550, 600, 650, 700, 750, 800, 950, 1000 };
    public string[] elements = {"Fire", "Void", "Electric", "Ice"};

    [Header("Perks")]
    public string[] slot1Perks = { "X2 Magnification", "X0.5 Magnification", "Quick Zoom", "Iron Sights" };
    public string[] slot2Perks = { "Extra Magazine Capacity", "Rampage", "Quick Zoom", "Extra Reserves Capacity", "Kill Clip", "Firefly" };
    public string[] slot3Perks = { "Extra Magazine Capacity", "Rampage", "Quick Zoom", "Extra Reserves Capacity", "Kill Clip", "Firefly" };
    public string[] traitPerks = { "Extra Magazine and Reserves Capacity", "Explosive Rounds", "Perpetual Radar" };



    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    /*
     * Spawns the loot at (loc) and sets the correct rarity material
     */
    public void SpawnLoot(Transform loc)
    {
        GameObject loot = Instantiate(lootModel, loc.position, loc.rotation);
        Item i = CreateLoot();
        loot.GetComponent<Item>().SetLootInfo(i.r,i.l,i.t,i.mC,i.rC,i.p,i.e);

        if (i.r == "Common") loot.GetComponent<Renderer>().material = rarityMats[0];
        else if (i.r == "Uncommon") loot.GetComponent<Renderer>().material = rarityMats[1];
        else if (i.r == "Rare") loot.GetComponent<Renderer>().material = rarityMats[2];
        else if (i.r == "Epic") loot.GetComponent<Renderer>().material = rarityMats[3];
        else if (i.r == "Legendary") loot.GetComponent<Renderer>().material = rarityMats[4];
    }

    /*
     * Creates randomized loot based on the atributes and perks as well as the rarity based on level
     */
    public Item CreateLoot()
    {
        if (player.level <= 5)
        {
            return new Item(rarities[Random.Range(0, 2)], player.level + Random.Range(0, 2),
                                    gunTypes[Random.Range(0, gunTypes.Length)],
                                    magazineCapacities[Random.Range(0, magazineCapacities.Length)],
                                    reservesCapacities[Random.Range(0, reservesCapacities.Length)],
                                    new string[] {slot1Perks[Random.Range(0,slot1Perks.Length)],
                                    slot2Perks[Random.Range(0, slot2Perks.Length)],
                                    slot3Perks[Random.Range(0, slot3Perks.Length)],
                                    traitPerks[Random.Range(0, traitPerks.Length)]}, 
                                    elements[Random.Range(0,elements.Length)]);
        }
        else if (player.level <= 10)
        {
            return new Item(rarities[Random.Range(1, 3)], player.level + Random.Range(-1, 2),
                                    gunTypes[Random.Range(0, gunTypes.Length)],
                                    magazineCapacities[Random.Range(0, magazineCapacities.Length)],
                                    reservesCapacities[Random.Range(0, reservesCapacities.Length)],
                                    new string[] {slot1Perks[Random.Range(0,slot1Perks.Length)],
                                    slot2Perks[Random.Range(0, slot2Perks.Length)],
                                    slot3Perks[Random.Range(0, slot3Perks.Length)],
                                    traitPerks[Random.Range(0, traitPerks.Length)]},
                                    elements[Random.Range(0, elements.Length)]);
        }
        else if (player.level <= 15)
        {
            return new Item(rarities[Random.Range(2, 4)], player.level + Random.Range(-1, 2),
                                    gunTypes[Random.Range(0, gunTypes.Length)],
                                    magazineCapacities[Random.Range(0, magazineCapacities.Length)],
                                    reservesCapacities[Random.Range(0, reservesCapacities.Length)],
                                    new string[] {slot1Perks[Random.Range(0,slot1Perks.Length)],
                                    slot2Perks[Random.Range(0, slot2Perks.Length)],
                                    slot3Perks[Random.Range(0, slot3Perks.Length)],
                                    traitPerks[Random.Range(0, traitPerks.Length)]},
                                    elements[Random.Range(0, elements.Length)]);
        }
        else if (player.level <= 19)
        {
            return new Item(rarities[Random.Range(3, 5)], player.level + Random.Range(-1, 1),
                                    gunTypes[Random.Range(0, gunTypes.Length)],
                                    magazineCapacities[Random.Range(0, magazineCapacities.Length)],
                                    reservesCapacities[Random.Range(0, reservesCapacities.Length)],
                                    new string[] {slot1Perks[Random.Range(0,slot1Perks.Length)],
                                    slot2Perks[Random.Range(0, slot2Perks.Length)],
                                    slot3Perks[Random.Range(0, slot3Perks.Length)],
                                    traitPerks[Random.Range(0, traitPerks.Length)]},
                                    elements[Random.Range(0, elements.Length)]);
        }
        else if (player.level == 20)
        {
            return new Item(rarities[Random.Range(3, 5)], player.level,
                                    gunTypes[Random.Range(0, gunTypes.Length)],
                                    magazineCapacities[Random.Range(0, magazineCapacities.Length)],
                                    reservesCapacities[Random.Range(0, reservesCapacities.Length)],
                                    new string[] {slot1Perks[Random.Range(0,slot1Perks.Length)],
                                    slot2Perks[Random.Range(0, slot2Perks.Length)],
                                    slot3Perks[Random.Range(0, slot3Perks.Length)],
                                    traitPerks[Random.Range(0, traitPerks.Length)]},
                                    elements[Random.Range(0, elements.Length)]);
        }
        else return null; // should never be reached
    }
}
