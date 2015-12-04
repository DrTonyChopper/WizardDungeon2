using System;

namespace WizardDungeon
{
	public class Item
	{
		public enum item{
			Nothing,
			//Potion,
			Sword,
			Spear,
			Knife,
			//Key,
			//Map,
			//Torch
		}
		public item type { get; set;}
		public int damage { set; get; }
		public int reach { set; get; }


		public Item()
		{
			this.type = item.Nothing;
			this.damage = 0;
			this.reach = 0;
		}

		public void setNewItem(int obj)
		{
			switch (obj) 
			{
			case 0:
				{
					this.type = item.Nothing;
					this.damage = 0;
					this.reach = 0;
					break;
				}
			case 1:
				{
					this.type = item.Sword;
					this.damage = 2;
					this.reach = 2;
					break;	
				}
			case 2:
				{
					this.type = item.Spear;
					this.damage = 1;
					this.reach = 3;
					break;
				}
			case 3:
				{
					this.type = item.Knife;
					this.damage = 3;
					this.reach = 1;
					break;
				}
			}
		}
		public void Print()
		{
			Console.WriteLine ("\nWeapon:"+this.type+"\tDamage:"+this.damage+"\tReach:"+this.reach);
		}
	}
}

