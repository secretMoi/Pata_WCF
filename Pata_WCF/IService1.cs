using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using Pata_WCF.Database.Classes;

namespace Pata_WCF
{
	// REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
	[ServiceContract]
	public interface IService1
	{
		// opérations
		[OperationContract]
		string GetData(int value);

		[OperationContract]
		string HelloWorld();

		[OperationContract]
		bool VerifierIsbn13(string isbn);

		[OperationContract]
		bool VerifierIban(string iban);

		[OperationContract]
		Client GetClient(int id);

		[OperationContract]
		CompositeType GetDataUsingDataContract(CompositeType composite);

		// TODO: ajoutez vos opérations de service ici
	}

	/*[DataContract]
	public class Client
	{
		// données
		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public string Nom { get; set; }

		[DataMember]
		public string Prenom { get; set; }

		[DataMember]
		public DateTime Naissance { get; set; }

		[DataMember]
		public string Mail { get; set; }
	}*/


	// Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
	[DataContract]
	public class CompositeType
	{
		// données
		[DataMember]
		public bool BoolValue { get; set; } = true;

		[DataMember]
		public string StringValue { get; set; } = "Hello ";
	}
}
