//Assignment2.cs
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Assignment2
{
	public class Game
	{
		public static Player[] playerArray = Enumerable
				.Range(0,2)
				.Select(i => new Player())
				.ToArray();
		static void Main(string[] args)
		{
			Console.Clear();
			Console.WriteLine("CMP1127M - Programming and Data Structures - Assignment 2 - CRO15592084");
			Console.WriteLine("Welcome to 'Three Or More' Dice Game!");
			Console.WriteLine("Would you like to play against a friend (Enter 1), or on your own (Enter 2)?");
			string userChoice = Console.ReadLine();
			if(userChoice != "1" && userChoice != "2"){
			Console.WriteLine("Invalid input, please try again.");
			userChoice=Console.ReadLine();
			}
			if (userChoice == "1"){
				Console.WriteLine("What is Player 1's name?");
				playerArray[0].name = Console.ReadLine();
				playerArray[0].score = 0;
				Console.WriteLine("What is Player 2's name?");
				playerArray[1].name = Console.ReadLine();
				playerArray[1].score = 0;
				do{
					for (int i = 0; i < 2; i++){
						Player currentPlayer = playerArray[i];
						Console.WriteLine("{0}: it is your turn. Press any key to roll.", currentPlayer.name);
						Console.ReadKey();
						DiceRoller roll = new DiceRoller(i);
						
					}
					if (playerArray[0].score >= 50){
						Console.WriteLine("Game is over as {0} has reached 50 points!", playerArray[0].name);
						Environment.Exit(0);
					break;
					}
					else if (playerArray[1].score >=50){
						Console.WriteLine("Game is over as {0} has reached 50 points!", playerArray[1].name);
						Environment.Exit(0);
					}
				} while (playerArray[0].score < 50);
				  while (playerArray[1].score < 50);
			}
			else if (userChoice == "2"){
				Console.WriteLine("What is your name?");
				playerArray[0].name = Console.ReadLine();
				playerArray[0].score = 0;
				while (playerArray[0].score <50){
				DiceRoller rand = new DiceRoller(0);
				Console.WriteLine("Press any key to continue.");
				Console.ReadKey();
				}
				if (playerArray[0].score > 50){
					Console.WriteLine("You reached a score of 50, you win!");
				}
			}
		}
	}
	public class Player
	{
		public string name = "";
		public int score = 0;
	}
	public class DiceRoller
	{
		private Random rnd = new Random();
		private int[] DieVals = new int[6]; //holds 5 values
		public int OneDice(){
			return rnd.Next(1,7);
		}
		public DiceRoller(int a){
			int i = 0;
			for (i=1;i<6;i++){
				DieVals[i]=OneDice();
			}
			Console.WriteLine("{0}, {1}, {2}, {3}, {4}", DieVals[1], DieVals[2], DieVals[3], DieVals[4], DieVals[5]);
			decimal throwTotal = (decimal)(DieVals[1] + DieVals[2] + DieVals[3] + DieVals[4] + DieVals[5]);
			decimal throwAverage = throwTotal/5;
			Console.WriteLine("Sum of throw is {0}", throwTotal);
			Console.WriteLine("Average of throw is {0}", throwAverage);
			
		Array.Sort(DieVals);
		if (DieVals[1] == DieVals [5]){
			Game.playerArray[a].score +=12;
			Console.WriteLine("Congratulations! You got 5 of a kind! 12 points!");
			
		}
		else if (DieVals[1] == DieVals [4]){
			Game.playerArray[a].score +=6;
			Console.WriteLine("Congratulations! You got 4 of a kind! 6 points!");
		}
		else if (DieVals[2] == DieVals [5]){
			Game.playerArray[a].score +=6;
			Console.WriteLine("Congratulations! You got 4 of a kind! 6 points!");	
		}
		else if (DieVals[1] == DieVals [3]){
			Game.playerArray[a].score +=3;
			Console.WriteLine("Congratulations! You got 3 of a kind! 3 points!");
		}
		else if (DieVals[2] == DieVals [4]){
			Game.playerArray[a].score +=3;
			Console.WriteLine("Congratulations! You got 3 of a kind! 3 points!");
		}
		else if (DieVals[3] == DieVals [5]){
			Game.playerArray[a].score +=3;
			Console.WriteLine("Congratulations! You got 3 of a kind! 3 points!");
		}
		else if (DieVals[1] == DieVals [2]){
			Console.WriteLine("You have a pair, which means you can roll the other 3 dice again. Press any key to roll.");
			Console.ReadKey();
			DieVals[3] = OneDice();
			DieVals[4] = OneDice();
			DieVals[5] = OneDice();
			Array.Sort(DieVals);
			Console.WriteLine("{0}, {1}, {2}, {3}, {4}",DieVals[1], DieVals[2], DieVals[3], DieVals[4], DieVals[5]);
			if (DieVals[1] == DieVals[5]){
				Console.WriteLine("5 of a kind! 12 points!");
				Game.playerArray[a].score +=12;
			}
			else if (DieVals[1] == DieVals[4] || DieVals[2] == DieVals[5]){
				Console.WriteLine("4 of a kind! 6 points!");
				Game.playerArray[a].score+=6;
			}
			else if (DieVals[1] == DieVals[3] || DieVals[2] == DieVals [4] || DieVals[3] == DieVals [5]){
				Console.WriteLine("3 of a kind! 3 points!");
				Game.playerArray[a].score +=3;
			}
			else{
				Console.WriteLine("No matches.");
			}
		}
		else if (DieVals[2] == DieVals [3]){
			Console.WriteLine("You have a pair, which means you can roll the other 3 dice again. Press any key to roll.");
			Console.ReadKey();
			DieVals[1] = OneDice();
			DieVals[4] = OneDice();
			DieVals[5] = OneDice();
			Array.Sort(DieVals);
			Console.WriteLine("{0}, {1}, {2}, {3}, {4}",DieVals[1], DieVals[2], DieVals[3], DieVals[4], DieVals[5]);
			if (DieVals[1] == DieVals[5]){
				Console.WriteLine("5 of a kind! 12 points!");
				Game.playerArray[a].score +=12;
			}
			else if (DieVals[1] == DieVals[4] || DieVals[2] == DieVals[5]){
				Console.WriteLine("4 of a kind! 6 points!");
				Game.playerArray[a].score+=6;
			}
			else if (DieVals[1] == DieVals[3] || DieVals[2] == DieVals [4] || DieVals[3] == DieVals [5]){
				Console.WriteLine("3 of a kind! 3 points!");
				Game.playerArray[a].score +=3;
			}
			else{
				Console.WriteLine("No matches.");
			}
		}
		else if (DieVals[3] == DieVals [4]){
			Console.WriteLine("You have a pair, which means you can roll the other 3 dice again. Press any key to roll.");
			Console.ReadKey();
			DieVals[1] = OneDice();
			DieVals[2] = OneDice();
			DieVals[5] = OneDice();
			Array.Sort(DieVals);
			Console.WriteLine("{0}, {1}, {2}, {3}, {4}",DieVals[1], DieVals[2], DieVals[3], DieVals[4], DieVals[5]);
			if (DieVals[1] == DieVals[5]){
				Console.WriteLine("5 of a kind! 12 points!");
				Game.playerArray[a].score +=12;
			}
			else if (DieVals[1] == DieVals[4] || DieVals[2] == DieVals[5]){
				Console.WriteLine("4 of a kind! 6 points!");
				Game.playerArray[a].score+=6;
			}
			else if (DieVals[1] == DieVals[3] || DieVals[2] == DieVals [4] || DieVals[3] == DieVals [5]){
				Console.WriteLine("3 of a kind! 3 points!");
				Game.playerArray[a].score +=3;
			}
			else{
				Console.WriteLine("No matches.");
			}
		}
		else if (DieVals[4] == DieVals [5]){
			Console.WriteLine("You have a pair, which means you can roll the other 3 dice again. Press any key to roll.");
			Console.ReadKey();
			DieVals[1] = OneDice();
			DieVals[2] = OneDice();
			DieVals[3] = OneDice();
			Array.Sort(DieVals);
			Console.WriteLine("{0}, {1}, {2}, {3}, {4}",DieVals[1], DieVals[2], DieVals[3], DieVals[4], DieVals[5]);
			if (DieVals[1] == DieVals[5]){
				Console.WriteLine("5 of a kind! 12 points!");
				Game.playerArray[a].score +=12;
			}
			else if (DieVals[1] == DieVals[4] || DieVals[2] == DieVals[5]){
				Console.WriteLine("4 of a kind! 6 points!");
				Game.playerArray[a].score+=6;
			}
			else if (DieVals[1] == DieVals[3] || DieVals[2] == DieVals [4] || DieVals[3] == DieVals [5]){
				Console.WriteLine("3 of a kind! 3 points!");
				Game.playerArray[a].score +=3;
			}
			else{
				Console.WriteLine("No matches.");
			}
		}
		else{
			Console.WriteLine("You have no matches.");
		}
		Console.WriteLine("{0}'s Score: {1}", Game.playerArray[a].name, Game.playerArray[a].score);
		}		
	}
}