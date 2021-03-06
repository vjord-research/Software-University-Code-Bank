namespace Prestissimo.Web.Areas.Admin.Models.Recordings
{
    using System.ComponentModel.DataAnnotations;

    public class AddFormatRecordingModel
    {
        public int RecordingId { get; set; }

        public int FormatId { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; } = 0;

        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; } = 0.01m;

        // In %
        [Range(0, 100)]
        public double Discount { get; set; } = 0;
    }
}
