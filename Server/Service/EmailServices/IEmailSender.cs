namespace imc_web_api.Service.EmailServices
{
    public interface IEmailSender
    {
        void SendEmail(string email , string Subject , string description);
    }
}
