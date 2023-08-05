namespace DXMauiApp1.Models
{
    public class Packag1120UpdateModel
    {
        public long Id { get; set; }

        public string CargoDescription { get; set; }

        public string Location { get; set; }
        
        public List<SizeModel> SizeLs { get; set; } = new List<SizeModel>(); // public string SizeLs { get; set; }

        public decimal? Volume { get; set; }

        public string WaybillNumber { get; set; }
    }
}