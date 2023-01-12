namespace ClinicService.Models.Request
{
    public class UpdatePetRequest
    {
       

        public int PetId { get; set; }

        public int ClientId { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }
        public int ConsultationId { get; internal set; }
        public DateTime ConsultationDate { get; internal set; }
        public string Description { get; internal set; }
    }
}
