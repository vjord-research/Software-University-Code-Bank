namespace Prestissimo.Services.Admin.Models.Labels
{
    using Common.Mapping;
    using Data.Models;

    public class AdminLabelBasicServiceModel : IMapFrom<Label>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
