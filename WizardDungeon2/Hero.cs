using System;

namespace WizardDungeon
{
	public class Hero
	{
		//hero's coordinates
		private int x;
		private int y;
		private int lives;
		public Item[] inventory { get; set;}
		private int currentItem;
		public Hero()
		{
			x = 0;
			y = 0;
			currentItem = 0;
			lives = 3;
			inventory = new Item[10];
			for (int i = 0; i < inventory.Length; i++) 
			{
				inventory[i] = new Item();
			}
		}
		public void TakeItem(int i, Item.item newItem, int newDamage, int newReach)
		{
			this.inventory [i].type = newItem;
			this.inventory [i].damage = newDamage;
			this.inventory [i].reach = newReach;
		}

		public int GetX()
		{
			return x;
		}

		public void SetX(int newX)
		{
			
			x = newX;
		}

		public int GetY()
		{
			return y;
		}

		public void SetY(int newY)
		{

			y = newY;
		}

		public int GetCurrentItem()
		{
			return currentItem;
		}

		public void SetCurrentItem(int newCurrent)
		{

			currentItem = newCurrent;
		}

		public int Getlives()
		{
			return lives;
		}

		public void Setlives(int newlives)
		{

			lives = newlives;
		}

		public void PrintLives(Hero k, string simbol)
		{
			for (int i = 0; i < k.Getlives(); i++)
			{
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.Write(simbol);//"\u2665"
			}
		}

		public void Move(Hero enemy)
		{
			ConsoleKey key = Console.ReadKey ().Key;
			switch (key) {
			case ConsoleKey.UpArrow:
				this.SetY (GetY () - 1);
				break;
			case ConsoleKey.LeftArrow:
				this.SetX (GetX () - 1);
				break;
			case ConsoleKey.DownArrow:
				this.SetY (GetY () + 1);
				break;
			case ConsoleKey.RightArrow:
				this.SetX (GetX () + 1);
				break;
			case ConsoleKey.E:
				this.nextItem ();
				break;
			case ConsoleKey.Q:
				this.prevItem ();
				break;
			case ConsoleKey.Y:
				this.AddItem ();
				break;
			case ConsoleKey.S:
				if ((enemy.GetX () == this.GetX ()) && ((enemy.GetY () <= this.GetY () + this.inventory[currentItem].reach) && (enemy.GetY () >= this.GetY ())))
					enemy.Setlives (enemy.Getlives () - this.inventory[currentItem].damage);
				break;
			case ConsoleKey.A:
				if ((enemy.GetY () == this.GetY ()) && ((enemy.GetX () >= this.GetX () - this.inventory[currentItem].reach) && (enemy.GetX () <= this.GetX ())))
					enemy.Setlives (enemy.Getlives () - this.inventory[currentItem].damage);
				break;
			case ConsoleKey.W:
				if ((enemy.GetX () == this.GetX ()) && ((enemy.GetY () >= this.GetY () - this.inventory[currentItem].reach) && (enemy.GetY () <= this.GetY ())))
					enemy.Setlives (enemy.Getlives () - this.inventory[currentItem].damage);
				break;
			case ConsoleKey.D:
				if ((enemy.GetY () == this.GetY ()) && ((enemy.GetX () <= this.GetX () + this.inventory[currentItem].reach) && (enemy.GetX () >= this.GetX ())))
					enemy.Setlives (enemy.Getlives () - this.inventory[currentItem].damage);
				break;
			default:
				break;
			}
		}

		public int nextItem()
		{
			bool useWhile = true;
			// variabile per contare il numero di slot verificati per controllare se sono presenti armi nell'inverntario 
			int slotSwitched = 1;
			while (useWhile) 
			{
				//se siamo nell'ultimo elemento troniamo al primo
				if (this.currentItem == this.inventory.Length-1) 
				{
					this.currentItem = 0;
				} 
				else this.currentItem++; //Altrimenti incrementa la posizione
				//adesso controlliamo se la posizione è valida(è presente un'arma)
				if (this.inventory [currentItem].type != Item.item.Nothing) 
				{
					return this.currentItem;

				}
				else slotSwitched++;//incrementiamo il numero di slot controllati
				if (slotSwitched == inventory.Length+1) //Se il numero si slot PRESENTI è uguale al numero CONTROLLATI non abbiamo più armi
				{
					Console.WriteLine ("Non hai più armi nell'tinventaro");
					return -1;
				}
			}
			return 0;
		}


		public int prevItem()
		{
			bool useWhile = true;
			int slotSwitched = 1;
			while (useWhile) 
			{
				if (this.currentItem == 0) 
				{
					this.currentItem = this.inventory.Length - 1;
				} 
				else this.currentItem--;
				if (this.inventory [this.currentItem].type!= Item.item.Nothing) 
				{
					return this.currentItem;

				}
				else slotSwitched++;
				if (slotSwitched == this.inventory.Length+1) 
				{
					Console.WriteLine ("Non hai piu armi nell'inventario");
					return -1;
				}
			}
			return 0;
		}

		public void PrintInventory()
		{
			Console.WriteLine ();
			Console.WriteLine ("************************");
			for (int i = 0; i < inventory.Length; i++) 
			{
				if(i == this.currentItem)
					Console.ForegroundColor = ConsoleColor.Green;
				this.inventory [i].Print ();
				Console.ForegroundColor = ConsoleColor.Black;
			}
				
			Console.WriteLine ("************************");
		}

		public void AddItem()
		{
			int i = 0;
			while (true)
			{
				if (inventory [i].type == Item.item.Nothing) 
				{
					inventory [i].setNewItem (RandomGenerator.GetRandom(0,3));
					break;
				}
				else i++;

				if (inventory.Length == i) 
				{
					Console.WriteLine ("Inventario Pieno");
					break;
				}
			}
		}
	}
}

