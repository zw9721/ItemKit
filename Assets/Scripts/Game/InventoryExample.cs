using System.Collections.Generic;
using UnityEngine;
using QFramework;

namespace QFramework.Example1
{
	public partial class InventoryExample : ViewController
	{	
		public class Item 
		{
			public string Name;
			public string Key;

			public Item(string key, string name)
			{
				Name = name;
				Key = key;
			}
		}

		public class Slot
		{
			public int Count;
			public Item Item;

			public Slot(Item item, int count)
			{
				Item = item;
				Count = count;
			}
		}
		

		public Item Item1 = new Item("item 1", "物品1");
		public Item Item2 = new Item("item 2", "物品2");
		public Item Item3 = new Item("item 3", "物品3");
		public Item Item4 = new Item("item 4", "物品4");
		public Item Item5 = new Item("item 5", "物品5");
		public Item Item6 = new Item("item 6", "物品6");
		public Item Item7 = new Item("item 7", "物品7");

		private List<Slot> mSlots = null;

		private Dictionary<string, Item> mItemDict = null;

		void Awake() {
			mSlots = new List<Slot>()
			{
				new Slot(Item1, 10),
				new Slot(Item2, 10),
				new Slot(Item3, 10),
				new Slot(Item4, 10),
				new Slot(Item5, 10),
			};

			mItemDict = new Dictionary<string, Item>()
			{
				{Item1.Key, Item1},
				{Item2.Key, Item2},
				{Item3.Key, Item3},
				{Item4.Key, Item4},
				{Item5.Key, Item5},
				{Item6.Key, Item6},
				{Item7.Key, Item7},
			};
		}

		private void OnGUI()
		{
			IMGUIHelper.SetDesignResolution(960,540);

			for (int i = 0; i < mSlots.Count; i++)
			{
				GUILayout.BeginHorizontal("box");
				if (mSlots[i].Count > 0)
				{
					GUILayout.Label($"格子{i+1}：{mSlots[i].Item.Name} x {mSlots[i].Count}");
				}
				else
				{
					GUILayout.Label($"格子{i+1}：空");
				}
				GUILayout.EndHorizontal();
			}

			GUILayout.BeginHorizontal();
			GUILayout.Label("物品1");
			if (GUILayout.Button("+")){if(!AddItem("item 1"))Debug.Log("物品栏已满");}
			if (GUILayout.Button("-"))SubItem("item 1");
			GUILayout.EndHorizontal();

			GUILayout.BeginHorizontal();
			GUILayout.Label("物品2");
			if (GUILayout.Button("+")){if(!AddItem("item 2"))Debug.Log("物品栏已满");}
			if (GUILayout.Button("-"))SubItem("item 2");
			GUILayout.EndHorizontal();

			GUILayout.BeginHorizontal();
			GUILayout.Label("物品3");
			if (GUILayout.Button("+")){if(!AddItem("item 3"))Debug.Log("物品栏已满");}
			if (GUILayout.Button("-"))SubItem("item 3");
			GUILayout.EndHorizontal();

			GUILayout.BeginHorizontal();
			GUILayout.Label("物品4");
			if (GUILayout.Button("+")){if(!AddItem("item 4"))Debug.Log("物品栏已满");}
			if (GUILayout.Button("-"))SubItem("item 4");
			GUILayout.EndHorizontal();

			GUILayout.BeginHorizontal();
			GUILayout.Label("物品5");
			if (GUILayout.Button("+")){if(!AddItem("item 5"))Debug.Log("物品栏已满");}
			if (GUILayout.Button("-"))SubItem("item 5");
			GUILayout.EndHorizontal();

			GUILayout.BeginHorizontal();
			GUILayout.Label("物品6");
			if (GUILayout.Button("+")){if(!AddItem("item 6"))Debug.Log("物品栏已满");}
			if (GUILayout.Button("-"))SubItem("item 6");
			GUILayout.EndHorizontal();

			GUILayout.BeginHorizontal();
			GUILayout.Label("物品7");
			if (GUILayout.Button("+")){if(!AddItem("item 7"))Debug.Log("物品栏已满");}
			if (GUILayout.Button("-"))SubItem("item 7");
			GUILayout.EndHorizontal();
		
		}
		Slot FindSlotByKey(string key)
		{
			return mSlots.Find(slot => slot != null && slot.Item.Key == key && slot.Count > 0);
		}

		Slot FindEmptySlot()
		{
			return mSlots.Find(slot => slot != null && slot.Count == 0);
		}

		Slot FindAddableSlot(string itemKey)
		{
			var slot = FindSlotByKey(itemKey);

			if(slot == null)
			{
				slot = FindEmptySlot();

				if(slot != null)
				{
					slot.Item = mItemDict[itemKey];
				}
			}

			return slot;
		}

		bool AddItem(string itemKey, int addCount = 1) {
			var slot = FindAddableSlot(itemKey);

			if(slot == null) {
				return false;
			}

			slot.Count += addCount;
			return true;
		}

		bool SubItem(string itemKey, int subCount = 1) {
			var slot = FindSlotByKey(itemKey);

			if(slot != null) {
				slot.Count -= subCount;
				return true;
			}

			return false;
		}
		
	}
}
