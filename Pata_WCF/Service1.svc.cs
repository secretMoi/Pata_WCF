using System;

namespace Pata_WCF
{
	// REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
	// REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
	public class Service1 : IService1
	{
		public string GetData(int value)
		{
			return $"You entered: {value}";
		}

		public string HelloWorld()
		{
			return "Hello World";
		}

		public bool VerifierIsbn13(string isbn)
		{
			// 978-2-8688-9006-1
			isbn = isbn.Replace("-", "").Replace(" ", ""); // supprime les tirets

			if (isbn.Length != 13 && long.TryParse(isbn, out long tmp) == false)
				return false;

			int somme = 0;
			int verif = 0;

			for (int i = 0; i < 12; i++)
			{
				if (i % 2 == 0)
					somme += int.Parse(isbn[i].ToString());
				else
					somme += 3 * int.Parse(isbn[i].ToString());

				if (somme % 10 != 0)
					verif = 10 - somme % 10;
			}

			return isbn[12].ToString() == verif.ToString();
		}

		public CompositeType GetDataUsingDataContract(CompositeType composite)
		{
			if (composite == null)
			{
				throw new ArgumentNullException("composite");
			}
			if (composite.BoolValue)
			{
				composite.StringValue += "Suffix";
			}
			return composite;
		}
	}
}
