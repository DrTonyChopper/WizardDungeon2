using System;

namespace WizardDungeon
{
	public class Dungeon
	{

		// dungeon's dimensions
		private const int dungeonWight = 30;
		private const int dungeonHeight = 20;

		// SaveZone's coordinates, the SaveZone is a point of dungeon where the player can spown
		private const int saveZoneX = 2;
		private const int saveZoneY = dungeonHeight / 2;

		//teleport's coordinates
		private const int teleportX = 18;
		private const int teleportY = 2;


		private int spownWeaponX;
		private int spownWeaponY;


		public Dungeon()
		{
			spownWeaponX	= RandomGenerator.GetRandom(1, dungeonWight-1);
			spownWeaponY	= RandomGenerator.GetRandom(1, dungeonHeight-1);
		}

		public int GetSpownWeaponX()
		{
			return spownWeaponX;
		}

		public int GetSpownWeaponY()
		{
			return spownWeaponY;
		}
		public void SetSpownWeaponX(int newX)
		{
			spownWeaponX = newX;
		}

		public void SetSpownWeaponY(int newY)
		{
			spownWeaponY = newY;
		}
		public int GetWight()
		{
			return dungeonWight;
		}

		public int GetHeight()
		{
			return dungeonHeight;
		}

		public int GetSaveX()
		{
			return saveZoneX;
		}

		public int GetSaveY()
		{
			return saveZoneY;
		}

		public int GetTeleportX()
		{
			return teleportX;
		}

		public int GetTeleportY()
		{
			return teleportY;
		}

		public void ClearScreen()
		{
			Console.BackgroundColor = ConsoleColor.Blue;
			Console.ForegroundColor = ConsoleColor.Black;
			Console.Clear();
			Console.WriteLine();
		}

		public void GameOver(bool risultato)
		{
			Console.BackgroundColor = ConsoleColor.DarkRed;
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine();
			Console.WriteLine();
			if (risultato == true)
				Console.WriteLine ("WIN");
			else
				Console.WriteLine ("GAME OVER");
			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.White;
		}
		public void Test(Hero mage, Hero enemy, ref int oldHeroX, ref int oldHeroY, ref bool isGameRunning)
		{
			if (mage.GetX () == enemy.GetX () && mage.GetY () == enemy.GetY ()) 
			{
				mage.Setlives (mage.Getlives () - 1);
				if (mage.Getlives () <= 0)
					isGameRunning = false;
				mage.SetX (GetSaveX ());
				mage.SetY (GetSaveY ());
			}
			//if the Player is over the Teleport
			if (mage.GetX () == GetTeleportX () && mage.GetY () == GetTeleportY ()) 
			{
				mage.SetX (GetSaveX ());
				mage.SetY (GetSaveY ());
			}
			if(mage.GetX () == GetSpownWeaponX () && mage.GetY () == GetSpownWeaponY())
			{
				mage.AddItem ();
				spownWeaponX	= RandomGenerator.GetRandom(1, dungeonWight-1);
				spownWeaponY	= RandomGenerator.GetRandom(1, dungeonHeight-1);
			}
			//if the Hero 
			if (mage.GetY () == 0 || mage.GetX () == 0 || mage.GetX () == GetWight () - 1 || mage.GetY () == GetHeight () - 1) 
			{
				mage.SetX (oldHeroX);
				mage.SetY (oldHeroY);
			}
			if (enemy.Getlives () <= 0)
				isGameRunning = false;
		}

		public void Print(Hero mage, Hero enemy)
		{
			for (int dungeonY = 0; dungeonY < GetHeight(); dungeonY++)
			{
				for (int dungeonX = 0; dungeonX < GetWight(); dungeonX++)
				{
					//print the edge of the dungeon
					if (dungeonX == 0 || dungeonX == GetWight() - 1 || dungeonY == 0 || dungeonY == 0 || dungeonY == GetHeight()- 1)
					{
						Console.BackgroundColor = ConsoleColor.DarkRed;
						Console.Write(" ");
					}
					// print the player
					else if (dungeonX == mage.GetX() && dungeonY == mage.GetY())
					{
						Console.BackgroundColor = ConsoleColor.Yellow;
						Console.Write("\u235F");
					}
					//print the enemy
					else if (dungeonX == enemy.GetX() && dungeonY == enemy.GetY())
					{
						Console.BackgroundColor = ConsoleColor.Yellow;
						Console.Write("\u26A1");
					}
					//print the teleport
					else if (dungeonX == GetTeleportX() && dungeonY == GetTeleportY())
					{
						Console.BackgroundColor = ConsoleColor.Yellow;
						Console.Write("⚛");
					}
					//print the Save Zone
					else if (dungeonX == GetSaveX() && dungeonY == GetSaveY())
					{
						Console.BackgroundColor = ConsoleColor.Gray;
						Console.Write("\u269A");
					}
					else if(dungeonX == GetSpownWeaponX() && dungeonY == GetSpownWeaponY())
					{
						Console.BackgroundColor = ConsoleColor.Yellow;
						Console.Write("⚔");
					}
					//print the inside of the dungeon
					else
					{
						Console.BackgroundColor = ConsoleColor.DarkGreen;
						Console.Write(" ");
					}
				}
				Console.WriteLine();
			}
		}
	}
}

