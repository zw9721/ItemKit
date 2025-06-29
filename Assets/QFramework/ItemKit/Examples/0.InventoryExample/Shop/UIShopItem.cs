using UnityEngine;
using QFramework;

// 1.请在菜单 编辑器扩展/Namespace Settings 里设置命名空间
// 2.命名空间更改后，生成代码之后，需要把逻辑代码文件（非 Designer）的命名空间手动更改
namespace QFramework.Example
{
	public partial class UIShopItem : ViewController
	{
		void Start()
		{
			// Code Here
		}
		
		public void UpdateBuyPriceText(int currentCoin,int price)
		{
			if (currentCoin >= price)
			{
				BtnBuy.interactable = true;
				BtnBuyText.text = $"购买({price})";
			}
			else
			{
				BtnBuy.interactable = false;
				BtnBuyText.text = $"购买<color=red>({price})</color>";
			}
		}
		public UIShopItem InitWithData(IItem item)
		{
			Icon.sprite = item.GetIcon;
			Description.text = item.GetDescription;
			return this;
		}
	}
}
