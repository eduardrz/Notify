using System;
using System.Collections.Generic;

namespace DrawerLayout_V7_Tutorial
{
	public static class ListArchive
	{
		public static IEnumerable<Archive> GetArchiveData()
		{
			return new[] {
				new Archive { Name = "Alaskan Malamute", ImageUrl = "images/dogs/alaskan_malamute.jpg" },
				new Archive { Name = "Australian Cattle Dog", ImageUrl = "images/dogs/australian_cattle_dog.jpg" },
				new Archive { Name = "Canaan Dog", ImageUrl = "images/dogs/canaan_dog.jpg" },
				new Archive { Name = "Dalmatian", ImageUrl = "images/dogs/dalmatian.jpg" },
				new Archive { Name = "English Foxhound", ImageUrl = "images/dogs/english_foxhound.jpg" },
				new Archive { Name = "German Shepherd", ImageUrl = "images/dogs/german_shepherd.jpg" },
				new Archive { Name = "Golden Retriever", ImageUrl = "images/dogs/golden_retriever.jpg" },
				new Archive { Name = "Pomeranian", ImageUrl = "images/dogs/pomeranian.jpg" },
				new Archive { Name = "Rhodesian Ridgeback", ImageUrl = "images/dogs/rhodesian_ridgeback.jpg" },
				new Archive { Name = "Rottweiler", ImageUrl = "images/dogs/rottweiler.jpg" },
				new Archive { Name = "Russell Terrier", ImageUrl = "images/dogs/russell_terrier.jpg" },
				new Archive { Name = "Saint Bernard", ImageUrl = "images/dogs/saint_bernard.jpg" },
				new Archive { Name = "Scottish Deerhound", ImageUrl = "images/dogs/scottish_deerhound.jpg" },
				new Archive { Name = "Shiba Inu", ImageUrl = "images/dogs/shiba_inu.jpg" },
				new Archive { Name = "Siberian Husky", ImageUrl = "images/dogs/siberian_husky.jpg" },
				new Archive { Name = "Weimaraner", ImageUrl = "images/dogs/weimaraner.jpg" }
			};
		}
	}
}
