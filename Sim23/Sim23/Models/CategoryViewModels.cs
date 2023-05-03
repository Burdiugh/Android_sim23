namespace Sim23.Models
{
    public class CategoryVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }

    public class CategoryCreateVM
    {
        public string Name { get; set; }
        public string ImageBase64 { get; set; }
        public int Priority { get; set; }
        public string Description { get; set; }
    }

    public class CategoryUpdateItemVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageBase64 { get; set; }
        public int Priority { get; set; }
        public string Description { get; set; }
    }
}
