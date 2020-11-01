using System;
using System.Text;
using Pata_WCF.Database.Classes;
using Pata_WCF.Database.Gestions;

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

			if (isbn.Length != 13 && long.TryParse(isbn, out _) == false)
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

		public bool VerifierIban(string iban)
		{
			// BE68 5390 0754 7034
			// 539-0075470-34

			// 1 supprime laractères indésirable
			iban = iban.Replace(" ", "").Replace("-", "");

			// 2 déplace les 4 premiers caractères à la fin
			string prefix = iban.Substring(0, 4);
			iban = iban.Remove(0, 4) + prefix;
			
			// 3 remplacer les lettres par des chiffres
			StringBuilder validIban = new StringBuilder();
			foreach (var character in iban)
			{
				if (IsLetter(character))
					validIban.Append((int) character - 55);
				else
					validIban.Append(character);
			}

			long ibanNumber;
			try
			{
				long.TryParse(validIban.ToString(), out ibanNumber);
			}
			catch
			{
				return false;
			}

			return ibanNumber % 97 == 1;
		}

		public Client GetClient(int id)
		{
			Gestion<Client> gestion = new Gestion<Client>(Configuration.Instance.Connexion);

			try
			{
				return gestion.LireId(id);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				return null;
			}
		}

		private bool IsLetter(char c)
		{
			return c >= 'A' && c <= 'Z';
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
