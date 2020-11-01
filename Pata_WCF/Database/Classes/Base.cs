using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Pata_WCF.Database.Classes
{
	[DataContract]
	public abstract class Base
	{
		protected readonly List<(string, Type)> _champs = new List<(string, Type)>();

		public abstract List<(string, Type)> GetChamps(); // liste des champs de la classe
		public abstract Type GetAcces(); // lien vers la couche d'accès
	}
}
