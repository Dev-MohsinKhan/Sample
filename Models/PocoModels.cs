namespace InterviewTask.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation Property
        public ICollection<Wiliyat> Wiliyats { get; set; }
    }


    public class Wiliyat
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Foreign Key
        public int RegionId { get; set; }
        // Navigation Properties
        public Region Region { get; set; }
        public ICollection<Area> Areas { get; set; }
    }

    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Foreign Key
        public int WiliyatId { get; set; }
        // Navigation Properties
        public Wiliyat Wiliyat { get; set; }
        public ICollection<Village> Villages { get; set; }
    }

    public class Village
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Foreign Key
        public int AreaId { get; set; }
        // Navigation Property
        public Area Area { get; set; }
    }

    public class EntityType
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EntityType { get; set; }
        public string EntityTypeName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Region { get; set; }
        public string RegionName { get; set; }
        public int Willaya { get; set; }
        public string WillayaName { get; set; }
        public int Area { get; set; }
        public string AreaName { get; set; }
        public int Village { get; set; }
        public string VillageName { get; set; }
        public string DetailsODE { get; set; }
        public string Remarks { get; set; }

       
    }
}
