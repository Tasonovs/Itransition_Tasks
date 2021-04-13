using Bogus;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace N4
{
	class DataGenerator
	{
		public List<Person> GeneratePeople(int count, string locale)
		{
			var personFaker = new Faker<Person>(locale)
				.RuleFor(x => x.FullName, x => x.Name.FullName())
				.RuleFor(x => x.Phone, x => x.Phone.PhoneNumber())
				.RuleFor(x => x.Address, x => x.Address.FullAddress());

			List<Person> persons = new List<Person>();
			int parallelThreads = Environment.ProcessorCount;
			Parallel.For(1, parallelThreads, (i) => { persons.AddRange(personFaker.Generate((int)count / parallelThreads)); });

			return persons;
		}
	}
}
