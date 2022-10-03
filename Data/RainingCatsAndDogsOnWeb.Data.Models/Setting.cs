namespace RainingCatsAndDogsOnWeb.Data.Models
{
    using RainingCatsAndDogsOnWeb.Data.Common.Models;

    public class Setting : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
