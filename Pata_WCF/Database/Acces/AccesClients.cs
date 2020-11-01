using Base = Database.Acces.Base;

namespace Pata_WCF.Database.Acces
{
	public class AccesClients : Base
	{
		public AccesClients(string sChaineConnexion) : base(sChaineConnexion)
		{
			Table = "Clients";

			_classesBase = new Classes.Client();
		}
	}
}
