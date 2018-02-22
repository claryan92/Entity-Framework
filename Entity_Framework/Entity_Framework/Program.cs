using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var db = new PlayContext())
			{
				Console.Write("Type in a name for new game Player: ");
				var name = Console.ReadLine();

				var player = new Player { Name = name };
				db.Players.Add(player);
				db.SaveChanges();

				var query = from b in db.Players
							orderby b.Name
							select b;

				Console.WriteLine("All players entered into the game: ");
				foreach (var item in query)
				{
					Console.WriteLine(item.Name);
				}

				Console.WriteLine("Press any key to exit...");
				Console.ReadKey();
			}
		}
	}
	public class Player
	{
		public int PlayerId { get; set; }
		public string Name { get; set; }
		public string Race { get; set; }

		public virtual List<Attribute> Attributes { get; set; }
	}

	public class Attribute
	{
		public int AttributeId { get; set; }
		public string Skill { get; set; }
		public string Height { get; set; }
		public string Mana { get; set; }

		public int PlayerId { get; set; }
		public virtual Player Player { get; set; }
	}

	public class PlayContext : DbContext
	{
		public DbSet<Player> Players { get; set; }
		public DbSet<Attribute> Attributes { get; set; }
	}
}
