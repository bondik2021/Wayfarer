using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowTranser : MonoBehaviour
{
    [SerializeField] private Text[] textsTransfers;
    public enum InfoTransfer {level, Experience, PointExperience, HP, Mana}
    public enum InfoTransferItem {Title, Description}

    public void SetTextsTransfers(UnitStats value)
    {
        textsTransfers[(int)InfoTransfer.level].text = "Уровень: " + value.level.ToString();
        textsTransfers[(int)InfoTransfer.Experience].text = "Опыт: " + value.curExperience.ToString() + " / " + value.maxExperience.ToString();
        textsTransfers[(int)InfoTransfer.PointExperience].text = "Очки опыта: " + value.pointExperience.ToString();
        textsTransfers[(int)InfoTransfer.HP].text = "Здоровье: " + value.curHP.ToString() + " / " + value.maxHP.ToString();
        textsTransfers[(int)InfoTransfer.Mana].text = "Мана: " + value.curMana.ToString() + " / " + value.maxMana.ToString();
    }

    public void SetTextsTransfers(InventoryItem value)
    {
        textsTransfers[(int)InfoTransferItem.Title].text = value.itemData.title;
        textsTransfers[(int)InfoTransferItem.Description].text = value.itemData.description;
    }
}
