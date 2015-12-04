using System;

namespace WizardDungeon
{
  class MainClass
   {
	public static void Main(string[] args)
	{
		Hero mage	= new Hero ();
		Hero enemy = new Hero ();
		Dungeon dungeon = new Dungeon (); 


		//enemy's coordinates
			enemy.SetX(14);
			enemy.SetY(5);
			enemy.Setlives (10);
		//hero's coordinates
			mage.SetX(dungeon.GetSaveX());
			mage.SetY(dungeon.GetSaveY());

			//mage.inventory [0].setNewItem (1);
			//mage.inventory [1].setNewItem (2);
			//mage.inventory [2].setNewItem (3);



		bool isGameRunning = true;
		while (isGameRunning)
		{
			dungeon.ClearScreen();
			//print the player's lives
			mage.PrintInventory();
			mage.PrintLives(mage, "\u2665");
			Console.WriteLine();
			enemy.PrintLives(enemy, "\u2620");
			Console.WriteLine();	
			Console.BackgroundColor = ConsoleColor.Yellow;
			Console.ForegroundColor = ConsoleColor.Black;
			//update and redraw
			dungeon.Print(mage, enemy);
			//input
			int oldHeroX = mage.GetX();
			int oldHeroY = mage.GetY();
			//controls for move the player
				mage.Move(enemy);
			//if the Player is over the Enemy
				dungeon.Test(mage, enemy, ref oldHeroX, ref oldHeroY, ref isGameRunning);
		}

			if (mage.Getlives() > 0)
				dungeon.GameOver (true);
			else
				dungeon.GameOver (false);
      }
	}
}
