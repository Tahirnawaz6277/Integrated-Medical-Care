namespace imc_web_api.Dtos.AdminDtos.FeedBackDtos
{
    public class FeedBackRequesrDTO
    {
        public string Description { get; set; }
        public decimal Rating { get; set; }

        //public Guid ratedById { get; set; }

        public Guid ratedToId { get; set; }
    }
}